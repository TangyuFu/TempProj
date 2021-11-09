namespace UnityGameFramework.Editor.Extension.UI
{
    /// <summary>
    /// 界面配置。
    /// </summary>
    public static class UIFormSettings
    {
        /// <summary>
        /// 对比工具的 Unity 工程相对路径。
        /// </summary>
        public const string ComparerPath = "Tools/Beyond Compare/BCompare.exe";
        
        /// <summary>
        /// 界面模板的预制件的相对路径。
        /// </summary>
        public const string TemplatePrefabPath = "Assets/GameFramework/Extension/Editor/UI/TemplateForm.prefab";
        
        /// <summary>
        /// 界面模板的脚本的相对路径。
        /// </summary>
        public const string TemplateScriptPath = "Assets/GameFramework/Extension/Editor/UI/UIFormTemplate.txt";

        /// <summary>
        /// 界面预制件的命名规则。
        /// </summary>
        public const string NamePattern = @"\w*Form";

        /// <summary>
        /// 界面的预制件目录。
        /// </summary>
        public const string FormPath = "Assets/R/UI/Forms";
        
        /// <summary>
        /// 界面脚本的脚本目录。
        /// </summary>
        public const string ScriptPath = "Assets/UIForms";
        
        /// <summary>
        /// 界面脚本的临时目录。
        /// </summary>
        public const string ScriptTempPath = "Assets/Temp/UIForm";
    }
}