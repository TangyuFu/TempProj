using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架 MVC 组件。
    /// 提供 UIForm Entity 的 MVC 功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/MVC")]
    public sealed partial class MVCComponent : CustomGameFrameworkComponent
    {
        private const string AssemblyName = "Assembly-CSharp";

        [Tooltip("Enable CSharp MVC, not hot fix.")] [SerializeField]
        private bool m_EnableCSharp = true;

        private readonly Dictionary<int, Type> m_UIFormPresenterTypes = new Dictionary<int, Type>();

        private readonly Dictionary<int, IUIFormPresenter> m_UIFormPresenters = new Dictionary<int, IUIFormPresenter>();

        private readonly Dictionary<int, Type> m_EntityPresenterTypes = new Dictionary<int, Type>();

        private readonly Dictionary<int, IEntityPresenter> m_EntityPresenters = new Dictionary<int, IEntityPresenter>();

        private readonly List<IEntityList> m_EntityLists = new List<IEntityList>();

        /// <summary>
        /// 初始化 MVC 组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            if (!m_EnableCSharp)
            {
                Log.Info("You have enabled hot fix, CSharp mvc shutdown automatically.");
                return;
            }

            try
            {
                Assembly assembly = Assembly.Load(AssemblyName);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (typeof(IUIFormPresenter).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        IdentityAttribute identityAttribute = null;
                        foreach (var attribute in type.GetCustomAttributes())
                        {
                            if (attribute is IdentityAttribute presenterAttr)
                            {
                                if (identityAttribute == null)
                                {
                                    identityAttribute = presenterAttr;
                                }
                                else
                                {
                                    Log.Error($"UI form has more than one '{typeof(IdentityAttribute)}'");
                                }
                            }
                        }

                        if (identityAttribute == null)
                        {
                            Log.Error($"UI form has no '{typeof(IdentityAttribute)}'");
                            continue;
                        }

                        int formId = identityAttribute.Id;
                        if (m_UIFormPresenterTypes.ContainsKey(formId))
                        {
                            Log.Error(
                                $"Duplicate ui form id between '{type.FullName}' and '{m_UIFormPresenterTypes[formId].FullName}'.");
                            break;
                        }

                        m_UIFormPresenterTypes.Add(formId, type);
                    }

                    if (typeof(IEntityPresenter).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        IdentityAttribute identityAttribute = null;
                        foreach (var attribute in type.GetCustomAttributes())
                        {
                            if (attribute is IdentityAttribute presenterAttr)
                            {
                                if (identityAttribute == null)
                                {
                                    identityAttribute = presenterAttr;
                                }
                                else
                                {
                                    Log.Error($"Entity has more than one '{typeof(IdentityAttribute)}'");
                                }
                            }
                        }

                        if (identityAttribute == null)
                        {
                            Log.Error($"Entity has no '{typeof(IdentityAttribute)}'");
                            continue;
                        }

                        int entityTypeId = identityAttribute.Id;
                        if (m_EntityPresenterTypes.ContainsKey(entityTypeId))
                        {
                            Log.Error(
                                $"Duplicate entity type id between '{type.FullName}' and '{m_EntityPresenterTypes[entityTypeId].FullName}'.");
                            break;
                        }

                        m_EntityPresenterTypes.Add(entityTypeId, type);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error($"Failed to create ui form and entity presenter collection with exception '{e}'");
                return;
            }
        }

        private IEnumerator Start()
        {
            if (!m_EnableCSharp)
            {
                yield return null;
            }

            yield return new WaitForEndOfFrame();
            // 注册 UIForm 事件。
            Entry.Event.Subscribe(UIFormInitEventArgs.EventId, OnUIFormInit);
            Entry.Event.Subscribe(UIFormDeinitEventArgs.EventId, OnUIFormDeinit);
            Entry.Event.Subscribe(UIFormRecycleEventArgs.EventId, OnUIFormRecycle);
            Entry.Event.Subscribe(UIFormOpenEventArgs.EventId, OnUIFormOpen);
            Entry.Event.Subscribe(UIFormCloseEventArgs.EventId, OnUIFormClose);
            Entry.Event.Subscribe(UIFormPauseEventArgs.EventId, OnUIFormPause);
            Entry.Event.Subscribe(UIFormResumeEventArgs.EventId, OnUIFormResume);
            Entry.Event.Subscribe(UIFormCoverEventArgs.EventId, OnUIFormCover);
            Entry.Event.Subscribe(UIFormRevealEventArgs.EventId, OnUIFormReveal);
            Entry.Event.Subscribe(UIFormRefocusEventArgs.EventId, OnUIFormRefocus);
            Entry.Event.Subscribe(UIFormUpdateEventArgs.EventId, OnUIFormUpdate);
            Entry.Event.Subscribe(UIFormDepthChangedEventArgs.EventId, OnUIFormDepthChanged);
            // 注册 Entity 内部事件。
            Entry.Event.Subscribe(EntityInitEventArgs.EventId, OnEntityInit);
            Entry.Event.Subscribe(EntityDeinitEventArgs.EventId, OnEntityDeinit);
            Entry.Event.Subscribe(EntityRecycleEventArgs.EventId, OnEntityRecycle);
            Entry.Event.Subscribe(EntityShowEventArgs.EventId, OnEntityShow);
            Entry.Event.Subscribe(EntityHideEventArgs.EventId, OnEntityHide);
            Entry.Event.Subscribe(EntityAttachedEventArgs.EventId, OnEntityAttached);
            Entry.Event.Subscribe(EntityDetachedEventArgs.EventId, OnEntityDetached);
            Entry.Event.Subscribe(EntityAttachToEventArgs.EventId, OnEntityAttachTo);
            Entry.Event.Subscribe(EntityDetachFromEventArgs.EventId, OnEntityDetachFrom);
            Entry.Event.Subscribe(EntityUpdateEventArgs.EventId, OnEntityUpdate);
            // // 注册 Entity 外部事件。
            // Entry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            // Entry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
            // Entry.Event.Subscribe(HideEntityCompleteEventArgs.EventId, OnHideEntityComplete);
        }

        /// <summary>
        /// 注册实体列表，不使用时需反注册。
        /// </summary>
        /// <param name="entityList">实体列表。</param>
        public void RegisterEntityList(IEntityList entityList)
        {
            m_EntityLists.Add(entityList);
        }

        /// <summary>
        /// 反注册实体列表。
        /// </summary>
        /// <param name="entityList">实体列表。</param>
        public void UnRegisterEntityList(IEntityList entityList)
        {
            m_EntityLists.Remove(entityList);
        }

        // private void OnShowEntitySuccess(object sender, GameEventArgs eventArgs)
        // {
        //     if (eventArgs is ShowEntitySuccessEventArgs showEntitySuccessEventArgs)
        //     {
        //         int serialId = 0;
        //     }
        // }
        //
        // private void OnShowEntityFailure(object sender, GameEventArgs eventArgs)
        // {
        //     if (eventArgs is ShowEntityFailureEventArgs showEntityFailureEventArgs)
        //     {
        //     }
        // }
        //
        // private void OnHideEntityComplete(object sender, GameEventArgs eventArgs)
        // {
        //     if (eventArgs is HideEntityCompleteEventArgs hideEntityCompleteEventArgs)
        //     {
        //     }
        // }

        private void OnUIFormInit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormInitEventArgs uiFormInitEventArgs)
            {
                int uniqueId = uiFormInitEventArgs.UniqueId;
                int formId = uiFormInitEventArgs.FormId;
                if (!m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    if (m_UIFormPresenterTypes.TryGetValue(formId, out var presenterType))
                    {
                        presenter = Activator.CreateInstance(presenterType) as IUIFormPresenter;

                        if (presenter == null)
                        {
                            Log.Error($"Failed to create ui form presenter '{presenterType}'.");
                            return;
                        }

                        m_UIFormPresenters.Add(uniqueId, presenter);
                    }
                    else
                    {
                        Log.Error($"Have no ui form presenter with attribute form id '{formId}'");
                        return;
                    }
                }
                else
                {
                    Log.Error(
                        $"UI form unique id '{uniqueId}' form id '{formId}' has not deinit.");
                    return;
                }

                presenter.OnInit(uiFormInitEventArgs.UniqueId, uiFormInitEventArgs.FormId, uiFormInitEventArgs.UIForm,
                    uiFormInitEventArgs.Root, uiFormInitEventArgs.UserData);
            }
        }

        private void OnUIFormDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormDeinitEventArgs uiFormDeinitEventArgs)
            {
                int uniqueId = uiFormDeinitEventArgs.UniqueId;
                int formId = uiFormDeinitEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDeinit();
                    m_UIFormPresenters.Remove(uniqueId);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormRecycle(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRecycleEventArgs uiFormRecycleEventArgs)
            {
                int uniqueId = uiFormRecycleEventArgs.UniqueId;
                int formId = uiFormRecycleEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnRecycle();
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormOpen(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormOpenEventArgs uiFormOpenEventArgs)
            {
                int uniqueId = uiFormOpenEventArgs.UniqueId;
                int formId = uiFormOpenEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnOpen(uiFormOpenEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormClose(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormCloseEventArgs uiFormCloseEventArgs)
            {
                int uniqueId = uiFormCloseEventArgs.UniqueId;
                int formId = uiFormCloseEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnClose(uiFormCloseEventArgs.IsShutdown, uiFormCloseEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormPause(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormPauseEventArgs uiFormPauseEventArgs)
            {
                int uniqueId = uiFormPauseEventArgs.UniqueId;
                int formId = uiFormPauseEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnPause();
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormResume(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormResumeEventArgs uiFormResumeEventArgs)
            {
                int uniqueId = uiFormResumeEventArgs.UniqueId;
                int formId = uiFormResumeEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnResume();
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormCover(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormCoverEventArgs uiFormCoverEventArgs)
            {
                int uniqueId = uiFormCoverEventArgs.UniqueId;
                int formId = uiFormCoverEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnCover();
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormReveal(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRevealEventArgs uiFormRevealEventArgs)
            {
                int uniqueId = uiFormRevealEventArgs.UniqueId;
                int formId = uiFormRevealEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnReveal();
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormRefocus(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRefocusEventArgs uiFormRefocusEventArgs)
            {
                int uniqueId = uiFormRefocusEventArgs.UniqueId;
                int formId = uiFormRefocusEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnRefocus(uiFormRefocusEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormUpdate(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormUpdateEventArgs uiFormUpdateEventArgs)
            {
                int uniqueId = uiFormUpdateEventArgs.UniqueId;
                int formId = uiFormUpdateEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnUpdate(uiFormUpdateEventArgs.ElapseSeconds, uiFormUpdateEventArgs.RealElapseSeconds);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnUIFormDepthChanged(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormDepthChangedEventArgs uiFormDepthChangedEventArgs)
            {
                int uniqueId = uiFormDepthChangedEventArgs.UniqueId;
                int formId = uiFormDepthChangedEventArgs.FormId;
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDepthChanged(uiFormDepthChangedEventArgs.UIGroupDepth,
                        uiFormDepthChangedEventArgs.DepthInUIGroup);
                }
                else
                {
                    Log.Error(
                        $"Has no ui form unique id '{uniqueId}' form id '{formId}'.");
                }
            }
        }

        private void OnEntityInit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityInitEventArgs entityInitEventArgs)
            {
                int uniqueId = entityInitEventArgs.UniqueId;
                int entityTypeId = entityInitEventArgs.EntityTypeId;
                if (!m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    if (m_EntityPresenterTypes.TryGetValue(entityTypeId, out var presenterType))
                    {
                        presenter = Activator.CreateInstance(presenterType) as IEntityPresenter;

                        if (presenter == null)
                        {
                            Log.Error($"Failed to create entity presenter '{presenterType}'.");
                            return;
                        }

                        m_EntityPresenters.Add(uniqueId, presenter);
                    }
                    else
                    {
                        Log.Error($"Have no entity presenter with attribute form id '{entityTypeId}'");
                        return;
                    }
                }
                else
                {
                    Log.Error(
                        $"Entity unique id '{uniqueId}' type id '{entityTypeId}' has not deinit.");
                    return;
                }

                presenter.OnInit(entityInitEventArgs.UniqueId, entityInitEventArgs.EntityId, entityInitEventArgs.Entity,
                    entityInitEventArgs.Root, entityInitEventArgs.UserData);
            }
        }

        private void OnEntityDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityDeinitEventArgs entityDeinitEventArgs)
            {
                int uniqueId = entityDeinitEventArgs.UniqueId;
                int entityId = entityDeinitEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDeinit();
                    m_EntityPresenters.Remove(uniqueId);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityRecycle(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityRecycleEventArgs entityRecycleEventArgs)
            {
                int uniqueId = entityRecycleEventArgs.UniqueId;
                int entityId = entityRecycleEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnRecycle();
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityShow(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityShowEventArgs entityShowEventArgs)
            {
                int uniqueId = entityShowEventArgs.UniqueId;
                int entityId = entityShowEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnShow(entityShowEventArgs.EntityId, entityShowEventArgs.UserData);

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnShow(entityShowEventArgs.EntityId, presenter);
                    }
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityHide(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityHideEventArgs entityHideEventArgs)
            {
                int uniqueId = entityHideEventArgs.UniqueId;
                int entityId = entityHideEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnHide(entityHideEventArgs.IsShutdown, entityHideEventArgs.UserData);

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnHide(entityHideEventArgs.EntityId, presenter);
                    }
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityAttached(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachedEventArgs entityAttachedEventArgs)
            {
                int uniqueId = entityAttachedEventArgs.UniqueId;
                int entityId = entityAttachedEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttached(entityAttachedEventArgs.ChildEntity, entityAttachedEventArgs.ParentTransform,
                        entityAttachedEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityDetached(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityDetachedEventArgs entityDetachedEventArgs)
            {
                int uniqueId = entityDetachedEventArgs.UniqueId;
                int entityId = entityDetachedEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDetached(entityDetachedEventArgs.ChildEntity, entityDetachedEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityAttachTo(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachToEventArgs entityAttachToEventArgs)
            {
                int uniqueId = entityAttachToEventArgs.UniqueId;
                int entityId = entityAttachToEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentEntity, entityAttachToEventArgs.ParentTransform,
                        entityAttachToEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityDetachFrom(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachToEventArgs entityAttachToEventArgs)
            {
                int uniqueId = entityAttachToEventArgs.UniqueId;
                int entityId = entityAttachToEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentEntity, entityAttachToEventArgs.ParentTransform,
                        entityAttachToEventArgs.UserData);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityUpdate(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityUpdateEventArgs entityUpdateEventArgs)
            {
                int uniqueId = entityUpdateEventArgs.UniqueId;
                int entityId = entityUpdateEventArgs.EntityId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnUpdate(entityUpdateEventArgs.ElapseSeconds, entityUpdateEventArgs.RealElapseSeconds);
                }
                else
                {
                    Log.Error(
                        $"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        /// <summary>
        /// MVC 组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.MVC;

        /// <summary>
        /// MVC 组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理 MVC 组件。
        /// </summary>
        internal override void Shutdown()
        {
            if (!m_EnableCSharp)
            {
                return;
            }

            // 反注册 UIForm 事件。
            Entry.Event.Unsubscribe(UIFormInitEventArgs.EventId, OnUIFormInit);
            Entry.Event.Unsubscribe(UIFormDeinitEventArgs.EventId, OnUIFormDeinit);
            Entry.Event.Unsubscribe(UIFormRecycleEventArgs.EventId, OnUIFormRecycle);
            Entry.Event.Unsubscribe(UIFormOpenEventArgs.EventId, OnUIFormOpen);
            Entry.Event.Unsubscribe(UIFormCloseEventArgs.EventId, OnUIFormClose);
            Entry.Event.Unsubscribe(UIFormPauseEventArgs.EventId, OnUIFormPause);
            Entry.Event.Unsubscribe(UIFormResumeEventArgs.EventId, OnUIFormResume);
            Entry.Event.Unsubscribe(UIFormCoverEventArgs.EventId, OnUIFormCover);
            Entry.Event.Unsubscribe(UIFormRevealEventArgs.EventId, OnUIFormReveal);
            Entry.Event.Unsubscribe(UIFormRefocusEventArgs.EventId, OnUIFormRefocus);
            Entry.Event.Unsubscribe(UIFormUpdateEventArgs.EventId, OnUIFormUpdate);
            Entry.Event.Unsubscribe(UIFormDepthChangedEventArgs.EventId, OnUIFormDepthChanged);
            // 反注册 Entity 内部事件。
            Entry.Event.Unsubscribe(EntityInitEventArgs.EventId, OnEntityInit);
            Entry.Event.Unsubscribe(EntityDeinitEventArgs.EventId, OnEntityDeinit);
            Entry.Event.Unsubscribe(EntityRecycleEventArgs.EventId, OnEntityRecycle);
            Entry.Event.Unsubscribe(EntityShowEventArgs.EventId, OnEntityShow);
            Entry.Event.Unsubscribe(EntityHideEventArgs.EventId, OnEntityHide);
            Entry.Event.Unsubscribe(EntityAttachedEventArgs.EventId, OnEntityAttached);
            Entry.Event.Unsubscribe(EntityDetachedEventArgs.EventId, OnEntityDetached);
            Entry.Event.Unsubscribe(EntityAttachToEventArgs.EventId, OnEntityAttachTo);
            Entry.Event.Unsubscribe(EntityDetachFromEventArgs.EventId, OnEntityDetachFrom);
            Entry.Event.Unsubscribe(EntityUpdateEventArgs.EventId, OnEntityUpdate);
            // // 反注册 Entity 外部事件。
            // Entry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            // Entry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
            // Entry.Event.Subscribe(HideEntityCompleteEventArgs.EventId, OnHideEntityComplete);
        }
    }
}