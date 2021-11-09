namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 玩家数据代理接口。
    /// </summary>
    public interface IPlayerDataAgent
    {
        /// <summary>
        /// 是否本地保存。
        /// </summary>
        bool Local { get; }

        /// <summary>
        /// 加载数据后回调。
        /// </summary>
        bool Load();

        /// <summary>
        /// 保存数据前回调。
        /// </summary>
        bool Save();
    }
}