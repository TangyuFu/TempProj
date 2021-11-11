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
                int formHash = uiFormInitEventArgs.UniqueId;
                int formId = uiFormInitEventArgs.FormId;
                if (!m_UIFormPresenters.TryGetValue(formHash, out var presenter))
                {
                    if (m_UIFormPresenterTypes.TryGetValue(formId, out var presenterType))
                    {
                        presenter = Activator.CreateInstance(presenterType) as IUIFormPresenter;

                        if (presenter == null)
                        {
                            Log.Error($"Failed to create ui form presenter '{presenterType}'.");
                            return;
                        }

                        m_UIFormPresenters.Add(formHash, presenter);
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
                        $"UI form hash '{formHash}' id '{formId}' has not deinit.");
                }

                presenter.OnInit(uiFormInitEventArgs.UniqueId, uiFormInitEventArgs.FormId, uiFormInitEventArgs.UIForm,
                    uiFormInitEventArgs.Root, uiFormInitEventArgs.UserData);
            }
        }

        private void OnUIFormDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormDeinitEventArgs uiFormDeinitEventArgs)
            {
                int formHash = uiFormDeinitEventArgs.UniqueId;
                if (m_UIFormPresenters.TryGetValue(formHash, out var presenter))
                {
                    presenter.OnDeinit();
                    m_UIFormPresenters.Remove(formHash);
                }
            }
        }

        private void OnUIFormRecycle(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRecycleEventArgs uiFormRecycleEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormRecycleEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnRecycle();
                }
            }
        }

        private void OnUIFormOpen(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormOpenEventArgs uiFormOpenEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormOpenEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnOpen(uiFormOpenEventArgs.UserData);
                }
            }
        }

        private void OnUIFormClose(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormCloseEventArgs uiFormCloseEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormCloseEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnClose(uiFormCloseEventArgs.IsShutdown, uiFormCloseEventArgs.UserData);
                }
            }
        }

        private void OnUIFormPause(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormPauseEventArgs uiFormPauseEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormPauseEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnPause();
                }
            }
        }

        private void OnUIFormResume(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormResumeEventArgs uiFormResumeEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormResumeEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnResume();
                }
            }
        }

        private void OnUIFormCover(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormCoverEventArgs uiFormCoverEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormCoverEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnCover();
                }
            }
        }

        private void OnUIFormReveal(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRevealEventArgs uiFormRevealEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormRevealEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnReveal();
                }
            }
        }

        private void OnUIFormRefocus(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormRefocusEventArgs uiFormRefocusEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormRefocusEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnRefocus(uiFormRefocusEventArgs.UserData);
                }
            }
        }

        private void OnUIFormUpdate(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormUpdateEventArgs uiFormUpdateEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormUpdateEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnUpdate(uiFormUpdateEventArgs.ElapseSeconds, uiFormUpdateEventArgs.RealElapseSeconds);
                }
            }
        }

        private void OnUIFormDepthChanged(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormDepthChangedEventArgs uiFormDepthChangedEventArgs)
            {
                if (m_UIFormPresenters.TryGetValue(uiFormDepthChangedEventArgs.UniqueId, out var presenter))
                {
                    presenter.OnDepthChanged(uiFormDepthChangedEventArgs.UIGroupDepth,
                        uiFormDepthChangedEventArgs.DepthInUIGroup);
                }
            }
        }

        private void OnEntityInit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityInitEventArgs entityInitEventArgs)
            {
                int entityHash = entityInitEventArgs.UniqueId;
                int entityTypeId = entityInitEventArgs.EntityTypeId;
                if (!m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    if (m_EntityPresenterTypes.TryGetValue(entityTypeId, out var presenterType))
                    {
                        presenter = Activator.CreateInstance(presenterType) as IEntityPresenter;

                        if (presenter == null)
                        {
                            Log.Error($"Failed to create entity presenter '{presenterType}'.");
                            return;
                        }

                        m_EntityPresenters.Add(entityHash, presenter);
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
                        $"Entity hash '{entityHash}' type id '{entityTypeId}' has not deinit.");
                }

                presenter.OnInit(entityInitEventArgs.UniqueId, entityInitEventArgs.EntityId, entityInitEventArgs.Entity,
                    entityInitEventArgs.Root, entityInitEventArgs.UserData);
            }
        }

        private void OnEntityDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityDeinitEventArgs entityDeinitEventArgs)
            {
                int entityHash = entityDeinitEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnDeinit();
                    m_EntityPresenters.Remove(entityHash);
                }
            }
        }

        private void OnEntityRecycle(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityRecycleEventArgs entityRecycleEventArgs)
            {
                int entityHash = entityRecycleEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnRecycle();
                }
            }
        }

        private void OnEntityShow(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityShowEventArgs entityShowEventArgs)
            {
                int entityHash = entityShowEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnShow(entityShowEventArgs.EntityId, entityShowEventArgs.UserData);

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnShow(entityShowEventArgs.EntityId, presenter);
                    }
                }
            }
        }

        private void OnEntityHide(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityHideEventArgs entityHideEventArgs)
            {
                int entityHash = entityHideEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnHide(entityHideEventArgs.IsShutdown, entityHideEventArgs.UserData);

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnHide(entityHideEventArgs.EntityId, presenter);
                    }
                }
            }
        }

        private void OnEntityAttached(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachedEventArgs entityAttachedEventArgs)
            {
                int entityHash = entityAttachedEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnAttached(entityAttachedEventArgs.ChildEntity, entityAttachedEventArgs.ParentTransform,
                        entityAttachedEventArgs.UserData);
                }
            }
        }

        private void OnEntityDetached(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityDetachedEventArgs entityDetachedEventArgs)
            {
                int entityHash = entityDetachedEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnDetached(entityDetachedEventArgs.ChildEntity, entityDetachedEventArgs.UserData);
                }
            }
        }

        private void OnEntityAttachTo(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachToEventArgs entityAttachToEventArgs)
            {
                int entityHash = entityAttachToEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentEntity, entityAttachToEventArgs.ParentTransform,
                        entityAttachToEventArgs.UserData);
                }
            }
        }

        private void OnEntityDetachFrom(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityAttachToEventArgs entityAttachToEventArgs)
            {
                int entityHash = entityAttachToEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentEntity, entityAttachToEventArgs.ParentTransform,
                        entityAttachToEventArgs.UserData);
                }
            }
        }

        private void OnEntityUpdate(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityUpdateEventArgs entityUpdateEventArgs)
            {
                int entityHash = entityUpdateEventArgs.UniqueId;
                if (m_EntityPresenters.TryGetValue(entityHash, out var presenter))
                {
                    presenter.OnUpdate(entityUpdateEventArgs.ElapseSeconds, entityUpdateEventArgs.RealElapseSeconds);
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