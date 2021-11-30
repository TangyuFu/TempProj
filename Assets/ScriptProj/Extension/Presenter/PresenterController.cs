using System;
using System.Collections.Generic;
using System.Reflection;
using GameFramework;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// Presenter 控制器，接收分发 UIForm Entity 事件。
    /// </summary>
    public sealed class PresenterController : Singleton<PresenterController>
    {
        private const string AssemblyName = "Assembly-CSharp";

        /// <summary>
        /// UIForm Presenter 类型的 ID - UIForm Presenter 类型
        /// </summary>
        private readonly Dictionary<int, Type> m_UIFormPresenterTypes = new();

        /// <summary>
        /// UIForm Presenter 实例 UID - UIForm Presenter 实例
        /// </summary>
        private readonly Dictionary<int, IUIFormPresenter> m_UIFormPresenters = new();

        /// <summary>
        /// Entity Presenter 类型的 ID - Entity Presenter 类型
        /// </summary>
        private readonly Dictionary<int, Type> m_EntityPresenterTypes = new();

        /// <summary>
        /// Entity Presenter 实例 UID - Entity Presenter 实例
        /// </summary>
        private readonly Dictionary<int, IEntityPresenter> m_EntityPresenters = new();

        /// <summary>
        /// Entity 列表
        /// </summary>
        private readonly List<IEntityList> m_EntityLists = new();

        /// <summary>
        /// 初始化。
        /// </summary>
        public override void OnCreate()
        {
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
            if (eventArgs is UIFormInitEventArgs formInitEventArgs)
            {
                int uniqueId = formInitEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(formInitEventArgs.Logic.UIForm.UIFormAssetName);
                if (m_UIFormPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    Log.Error(
                        $"UI form unique id '{uniqueId}' form id '{formId}' has not deinit.");
                    presenter.OnDeinit();
                    m_UIFormPresenters.Remove(uniqueId);
                }
                else
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
                        presenter.OnInit(formInitEventArgs.Logic.UniqueId, formId,
                            formInitEventArgs.Logic,
                            formInitEventArgs.Logic.Root, formInitEventArgs.UserData);
                    }
                    else
                    {
                        Log.Error($"Have no ui form presenter with attribute form id '{formId}'");
                    }
                }
            }
        }

        private void OnUIFormDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is UIFormDeinitEventArgs uiFormDeinitEventArgs)
            {
                int uniqueId = uiFormDeinitEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormDeinitEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormRecycleEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormRecycleEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormOpenEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormOpenEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormCloseEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormCloseEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormPauseEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormPauseEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormResumeEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormResumeEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormCoverEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormCoverEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormRevealEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormRevealEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormRefocusEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormRefocusEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormUpdateEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormUpdateEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = uiFormDepthChangedEventArgs.Logic.UniqueId;
                int formId = UIExtension.GetFormId(uiFormDepthChangedEventArgs.Logic.UIForm.UIFormAssetName);
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
                int uniqueId = entityInitEventArgs.Logic.UniqueId;
                if (entityInitEventArgs.UserData is EntityData entityData)
                {
                    int entityTypeId = entityData.TypeId;
                    if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                    {
                        Log.Error($"Entity unique id '{uniqueId}' type id '{entityTypeId}' has not deinit.");
                        presenter.OnDeinit();
                        m_EntityPresenters.Remove(uniqueId);
                    }
                    else
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
                            presenter.OnInit(entityInitEventArgs.Logic, entityInitEventArgs.Logic.Root,
                                entityInitEventArgs.UserData);
                        }
                        else
                        {
                            Log.Error($"Have no entity presenter with attribute form id '{entityTypeId}'");
                        }
                    }
                }
                else
                {
                    Log.Error($"Invalid entity data, should not subscribe event.");
                }
            }
        }

        private void OnEntityDeinit(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityDeinitEventArgs entityDeinitEventArgs)
            {
                int uniqueId = entityDeinitEventArgs.Logic.UniqueId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDeinit();
                    m_EntityPresenters.Remove(uniqueId);
                }
                else
                {
                    Log.Error($"Has no entity unique id '{uniqueId}'.");
                }
            }
        }

        private void OnEntityRecycle(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityRecycleEventArgs entityRecycleEventArgs)
            {
                int uniqueId = entityRecycleEventArgs.Logic.UniqueId;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnRecycle();
                }
                else
                {
                    Log.Error($"Has no entity unique id '{uniqueId}'.");
                }
            }
        }

        private void OnEntityShow(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityShowEventArgs entityShowEventArgs)
            {
                int uniqueId = entityShowEventArgs.Logic.UniqueId;
                int entityId = entityShowEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    if (entityShowEventArgs.UserData is EntityData entityData)
                    {
                        presenter.OnShow(entityShowEventArgs.UserData);
                        // Release entity data, do not keep reference of entity data.
                        ReferencePool.Release(entityData);
                    }

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnShow(entityId, presenter);
                    }
                }
                else
                {
                    Log.Error($"Has no entity unique id '{uniqueId}' entity id '{entityId}'.");
                }
            }
        }

        private void OnEntityHide(object sender, GameEventArgs eventArgs)
        {
            if (eventArgs is EntityHideEventArgs entityHideEventArgs)
            {
                int uniqueId = entityHideEventArgs.Logic.UniqueId;
                int entityId = entityHideEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnHide(entityHideEventArgs.IsShutdown, entityHideEventArgs.UserData);

                    foreach (var entityList in m_EntityLists)
                    {
                        entityList.OnHide(entityId, presenter);
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
                int uniqueId = entityAttachedEventArgs.Logic.UniqueId;
                int entityId = entityAttachedEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttached(entityAttachedEventArgs.ChildLogic, entityAttachedEventArgs.ParentTransform,
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
                int uniqueId = entityDetachedEventArgs.Logic.UniqueId;
                int entityId = entityDetachedEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnDetached(entityDetachedEventArgs.ChildLogic, entityDetachedEventArgs.UserData);
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
                int uniqueId = entityAttachToEventArgs.Logic.UniqueId;
                int entityId = entityAttachToEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentLogic, entityAttachToEventArgs.ParentTransform,
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
                int uniqueId = entityAttachToEventArgs.Logic.UniqueId;
                int entityId = entityAttachToEventArgs.Logic.Entity.Id;
                if (m_EntityPresenters.TryGetValue(uniqueId, out var presenter))
                {
                    presenter.OnAttachTo(entityAttachToEventArgs.ParentLogic, entityAttachToEventArgs.ParentTransform,
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
                int uniqueId = entityUpdateEventArgs.Logic.UniqueId;
                int entityId = entityUpdateEventArgs.Logic.Entity.Id;
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
        /// 关闭并清理 MVC 组件。
        /// </summary>
        public override void OnDestroy()
        {
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