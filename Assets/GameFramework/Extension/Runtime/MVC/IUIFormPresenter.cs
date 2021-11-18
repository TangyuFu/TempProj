using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UIForm 代表者接口；
    /// </summary>
    public interface IUIFormPresenter
    {
        /// <summary>
        /// 界面唯一标识符。
        /// </summary>
        int UniqueId { get; }

        /// <summary>
        /// 界面 ID 。
        /// </summary>
        int FormId { get; }

        /// <summary>
        /// 界面根物体。
        /// </summary>
        Transform Root { get; }

        /// <summary>
        /// 获取界面。
        /// </summary>
        CustomUIFormLogic Logic { get; }

        /// <summary>
        /// 初始化时调用。
        /// </summary>
        /// <param name="uniqueId">界面唯一标识符。</param>
        /// <param name="formId">界面 ID 。</param>
        /// <param name="customUIFormLogic">界面。</param>
        /// <param name="root">界面根物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnInit(int uniqueId, int formId, CustomUIFormLogic customUIFormLogic, Transform root,
            object userData);

        /// <summary>
        /// 反初始化时调用。
        /// </summary>
        void OnDeinit();

        /// <summary>
        /// 对象池回收时调用，使用 OnDeinit 作为反初始化。
        /// </summary>
        void OnRecycle();

        /// <summary>
        /// 打开时调用。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        void OnOpen(object userData);

        /// <summary>
        /// 关闭时调用
        /// </summary>
        /// <param name="isShutdown">是否关闭对象池。</param>
        /// <param name="userData"></param>
        void OnClose(bool isShutdown, object userData);

        /// <summary>
        /// 暂停时调用。
        /// </summary>
        void OnPause();

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        void OnResume();

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        void OnCover();

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        void OnReveal();

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        void OnRefocus(object userData);

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        void OnUpdate(float elapseSeconds, float realElapseSeconds);

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        void OnDepthChanged(int uiGroupDepth, int depthInUIGroup);

        /// <summary>
        /// 隐藏当前界面。
        /// </summary>
        void Close();
    }
}