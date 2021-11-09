using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UIForm 代表者；
    /// </summary>
    public interface IUIFormPresenter
    {
        /// <summary>
        /// 初始化时调用。
        /// </summary>
        /// <param name="target">目标游戏物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnInit(GameObject target, object userData);

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
    }
}