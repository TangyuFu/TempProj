namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class Entry
    {
        /// <summary>
        /// 获取玩家数据组件。
        /// </summary>
        public static PlayerDataComponent PlayerData { get; private set; }

        /// <summary>
        /// 获取摄像机组件。
        /// </summary>
        public static CameraComponent Camera { get; private set; }

        /// <summary>
        /// 获取脚本组件。
        /// </summary>
        public static ScriptComponent Script { get; private set; }

        /// <summary>
        /// 获取视频组件。
        /// </summary>
        public static VideoComponent Video { get; private set; }

        /// <summary>
        /// 获取内置数据组件。
        /// </summary>
        public static BuiltinDataComponent BuiltinData { get; private set; }

        /// <summary>
        /// 获取 MVC 组件。
        /// </summary>
        public static MVCComponent MVC { get; private set; }

        /// <summary>
        /// 获取 R 组件。
        /// </summary>
        public static RComponent R { get; private set; }

        /// <summary>
        /// 获取 GM 组件。
        /// </summary>
        public static GMComponent GM { get; private set; }

        /// <summary>
        /// 获取时间组件。
        /// </summary>
        public static TimeComponent Time { get; private set; }

        /// <summary>
        /// 获取时间组件。
        /// </summary>
        // public static ConditionComponent Condition { get; private set; }
        private static void InitCustomComponents()
        {
            PlayerData = CustomGameFrameworkEntry.GetComponent<PlayerDataComponent>();
            Camera = CustomGameFrameworkEntry.GetComponent<CameraComponent>();
            Script = CustomGameFrameworkEntry.GetComponent<ScriptComponent>();
            Video = CustomGameFrameworkEntry.GetComponent<VideoComponent>();
            BuiltinData = CustomGameFrameworkEntry.GetComponent<BuiltinDataComponent>();
            MVC = CustomGameFrameworkEntry.GetComponent<MVCComponent>();
            R = CustomGameFrameworkEntry.GetComponent<RComponent>();
            GM = CustomGameFrameworkEntry.GetComponent<GMComponent>();
            Time = CustomGameFrameworkEntry.GetComponent<TimeComponent>();
        }
    }
}