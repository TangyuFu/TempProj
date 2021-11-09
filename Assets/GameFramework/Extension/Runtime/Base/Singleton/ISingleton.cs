namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 单例接口。
    /// </summary>
    public interface ISingleton
    {
        /// <summary>
        /// 初始化单例。
        /// </summary>
        void OnCreate();

        /// <summary>
        /// 反初始化单例。
        /// </summary>
        void OnDestroy();
    }
}