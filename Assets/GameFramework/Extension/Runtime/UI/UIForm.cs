using GameFramework.DataTable;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义界面基类。
    /// </summary>
    public sealed class UIForm : UIFormLogic
    {
        private int m_UniqueId;

        private int m_FormId;

        private GameObject m_Root;

        private CanvasRenderSorter m_Sorter;

        /// <summary>
        /// 界面唯一标识符。
        /// </summary>
        public int UniqueId => m_UniqueId;

        /// <summary>
        /// 界面 ID 。
        /// </summary>
        private int FormId => m_FormId;

        /// <summary>
        /// 界面根物体。
        /// </summary>
        public GameObject Root => m_Root;

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Root = gameObject;
            m_UniqueId = GetHashCode();
            m_FormId = UIExtension.GetFormId(UIForm.UIFormAssetName);

            GraphicRaycaster graphicRaycaster = m_Root.GetOrAddComponent<GraphicRaycaster>();
            Canvas canvas = m_Root.GetOrAddComponent<Canvas>();
            canvas.overrideSorting = true;
            m_Sorter = m_Root.GetOrAddComponent<CanvasRenderSorter>();
            m_Sorter.RenderSorterMode = RenderSorterMode.Relative;

            UIExtension.SetTransformFont(m_Root);

            IDataTable<DRUIForm> dtUIForm = Entry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(m_FormId);
            if (drUIForm.IsLocked)
            {
                Entry.UI.SetUIFormInstanceLocked(UIForm, true);
            }

            Entry.Event.FireNow(UIFormInitEventArgs.EventId,
                UIFormInitEventArgs.Create(m_UniqueId, m_FormId, this, m_Root, userData));
        }

        /// <summary>
        /// 界面反初始化是调用。
        /// </summary>
        public void OnDeinit()
        {
            Entry.Event.FireNow(UIFormDeinitEventArgs.EventId,
                UIFormDeinitEventArgs.Create(m_UniqueId, m_FormId, null));
        }

        /// <summary>
        /// 界面回收。
        /// </summary>
        protected override void OnRecycle()
        {
            Entry.Event.FireNow(UIFormRecycleEventArgs.EventId,
                UIFormRecycleEventArgs.Create(m_UniqueId, m_FormId, null));

            base.OnRecycle();
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            Entry.Event.FireNow(UIFormOpenEventArgs.EventId,
                UIFormOpenEventArgs.Create(m_UniqueId, m_FormId, userData));
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(bool isShutdown, object userData)
        {
            Entry.Event.FireNow(UIFormCloseEventArgs.EventId,
                UIFormCloseEventArgs.Create(m_UniqueId, m_FormId, isShutdown, userData));

            base.OnClose(isShutdown, userData);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();

            Entry.Event.FireNow(UIFormPauseEventArgs.EventId, UIFormPauseEventArgs.Create(m_UniqueId, m_FormId, null));
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            Entry.Event.FireNow(UIFormResumeEventArgs.EventId,
                UIFormResumeEventArgs.Create(m_UniqueId, m_FormId, null));
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();

            Entry.Event.FireNow(UIFormCoverEventArgs.EventId, UIFormCoverEventArgs.Create(m_UniqueId, m_FormId, null));
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();

            Entry.Event.FireNow(UIFormRevealEventArgs.EventId,
                UIFormRevealEventArgs.Create(m_UniqueId, m_FormId, null));
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);

            Entry.Event.FireNow(UIFormRefocusEventArgs.EventId,
                UIFormRefocusEventArgs.Create(m_UniqueId, m_FormId, userData));
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            // Entry.Event.FireNow(UIFormUpdateEventArgs.EventId,
            //     UIFormUpdateEventArgs.Create(m_FormHash, m_FormId, elapseSeconds, realElapseSeconds, null));
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);

            m_Sorter.RenderSorterOrder = depthInUIGroup;

            // Entry.Event.FireNow(UIFormDepthChangedEventArgs.EventId,
            //     UIFormDepthChangedEventArgs.Create(m_FormHash, m_FormId, uiGroupDepth, depthInUIGroup, null));
        }
    }
}