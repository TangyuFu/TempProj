using UnityEngine;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义界面基类。
    /// </summary>
    public sealed class CustomUIFormLogic : UIFormLogic
    {
        private CanvasRenderSorter m_Sorter;

        /// <summary>
        /// 界面唯一标识符。
        /// </summary>
        public int UniqueId { get; private set; }

        /// <summary>
        /// 界面根物体。
        /// </summary>
        public Transform Root { get; private set; }

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            Root = transform;
            // Initialize TMP_Text if it is not empty.
            UIExtension.SetTransformFont(Root);
            UniqueId = GetHashCode();

            // Initialize canvas.
            GraphicRaycaster graphicRaycaster = gameObject.GetOrAddComponent<GraphicRaycaster>();
            Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
            canvas.overrideSorting = true;
            m_Sorter = gameObject.GetOrAddComponent<CanvasRenderSorter>();
            m_Sorter.RenderSorterMode = RenderSorterMode.Relative;

            Entry.Event.FireNow(UIFormInitEventArgs.EventId, UIFormInitEventArgs.Create(this, userData));
        }

        /// <summary>
        /// 界面反初始化是调用。
        /// </summary>
        public void OnDeinit()
        {
            Entry.Event.FireNow(UIFormDeinitEventArgs.EventId, UIFormDeinitEventArgs.Create(this, null));
        }

        /// <summary>
        /// 界面回收。
        /// </summary>
        protected override void OnRecycle()
        {
            Entry.Event.FireNow(UIFormRecycleEventArgs.EventId, UIFormRecycleEventArgs.Create(this, null));

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
                UIFormOpenEventArgs.Create(this, userData));
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(bool isShutdown, object userData)
        {
            Entry.Event.FireNow(UIFormCloseEventArgs.EventId, UIFormCloseEventArgs.Create(this, isShutdown, userData));

            base.OnClose(isShutdown, userData);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();

            Entry.Event.FireNow(UIFormPauseEventArgs.EventId, UIFormPauseEventArgs.Create(this, null));
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            Entry.Event.FireNow(UIFormResumeEventArgs.EventId, UIFormResumeEventArgs.Create(this, null));
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();

            Entry.Event.FireNow(UIFormCoverEventArgs.EventId, UIFormCoverEventArgs.Create(this, null));
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();

            Entry.Event.FireNow(UIFormRevealEventArgs.EventId, UIFormRevealEventArgs.Create(this, null));
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);

            Entry.Event.FireNow(UIFormRefocusEventArgs.EventId, UIFormRefocusEventArgs.Create(this, userData));
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
            //     UIFormUpdateEventArgs.Create(this, elapseSeconds, realElapseSeconds, null));
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
            //     UIFormDepthChangedEventArgs.Create(this, uiGroupDepth, depthInUIGroup, null));
        }
    }
}