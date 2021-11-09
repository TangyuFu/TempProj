namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 渲染排序模式
    /// </summary>
    public enum RenderSorterMode
    {
        /// <summary>
        /// 绝对模式，以当前渲染为根，进行子物体渲染
        /// </summary>
        Absolute,

        /// <summary>
        /// 相对模式，父物体会对子物体进行以此渲染
        /// </summary>
        Relative,
    }
}