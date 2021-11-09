using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架资源工具。
        /// </summary>
        public static class Asset
        {
            /// <summary>
            /// 资源根目录。
            /// </summary>
            public const string RPath = "Assets/R";

            # region ------------------------------------------------------------------------------------------ Scene

            /// <summary>
            /// 资源场景目录。
            /// </summary>
            public const string RScenePath = RPath + "/Scenes";

            /// <summary>
            /// 获取场景资源路径。
            /// </summary>
            /// <param name="name">场景资源名称。</param>
            /// <param name="ext">场景资源后缀名。</param>
            /// <returns>场景资源路径。</returns>
            public static string GetScenePath(string name, string ext = "unity")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RScenePath, name, ext);
            }

            # endregion

            # region ------------------------------------------------------------------------------------------ Video

            /// <summary>
            /// 资源视频目录。
            /// </summary>
            public const string RVideoPath = RPath + "/Videos";

            /// <summary>
            /// 获取视频资源路径。
            /// </summary>
            /// <param name="name">视频资源名称。</param>
            /// <param name="ext">视频资源后缀名。</param>
            /// <returns>视频资源路径。</returns>
            public static string GetVideoPath(string name, string ext = "mp4")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RVideoPath, name, ext);
            }

            # endregion

            # region ------------------------------------------------------------------------------------------ Audio

            /// <summary>
            /// 资源音频目录。
            /// </summary>
            public const string RAudioPath = RPath + "/Audios";

            public const string RAudioMusicPath = RAudioPath + "/Musics";
            public const string RAudioSoundPath = RAudioPath + "/Sounds";
            public const string RAudioUISoundPath = RAudioPath + "/UISounds";

            /// <summary>
            /// 获取背景声效资源路径。
            /// </summary>
            /// <param name="name">背景声效资源名称。</param>
            /// <param name="ext">背景声效资源后缀名。</param>
            /// <returns>背景声效资源路径。</returns>
            public static string GetMusicPath(string name, string ext = "mp3")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RAudioMusicPath, name, ext);
            }

            /// <summary>
            /// 获取 3D 声效资源路径。
            /// </summary>
            /// <param name="name">3D 声效资源名称。</param>
            /// <param name="ext">3D 声效资源后缀名。</param>
            /// <returns>3D 声效资源路径。</returns>
            public static string GetSoundPath(string name, string ext = "mp3")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RAudioSoundPath, name, ext);
            }

            /// <summary>
            /// 获取 UI 声效资源路径。
            /// </summary>
            /// <param name="name">UI 声效资源名称。</param>
            /// <param name="ext">UI 声效资源后缀名。</param>
            /// <returns>UI 声效资源路径。</returns>
            public static string GetUISoundPath(string name, string ext = "mp3")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RAudioUISoundPath, name, ext);
            }

            # endregion

            # region ------------------------------------------------------------------------------------------ DataTable

            /// <summary>
            /// 资源数据表目录。
            /// </summary>
            public const string RTablePath = RPath + "/TableProj";

            public const string RTableExcelPath = RTablePath + "/Excel";
            
            public const string RTableClientPath = RTablePath + "/Client";
            public const string RTableClientDataPath = RTableClientPath + "/Data";
            public const string RTableClientScriptPath = RTableClientPath + "/Script";
            
            public const string RTableServerPath = RTablePath + "/Server";
            public const string RTableServerDataPath = RTableServerPath + "/Data";
            public const string RTableServerScriptPath = RTableServerPath + "/Script";
            
            public const string RTableJsonPath = RTablePath + "/Json";
            
            public const string RTableLanguagePath = RTablePath + "/Language";
            
            /// <summary>
            /// 获取数据表 Excel 路径。
            /// </summary>
            /// <param name="name">数据表 Excel 名称。</param>
            /// <param name="ext">数据表 Excel 后缀名。</param>
            /// <returns>数据表 Excel 路径。</returns>
            public static string GetTableExcelPath(string name, string ext = "xlsx")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableExcelPath, name, ext);
            }

            /// <summary>
            /// 获取数据表前端数据路径。
            /// </summary>
            /// <param name="name">数据表前端数据名称。</param>
            /// <param name="ext">数据表前端数据后缀名。</param>
            /// <returns>数据表前端数据路径。</returns>
            public static string GetTableClientDataPath(string name, string ext = "txt")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableClientDataPath, name, ext);
            }
            
            /// <summary>
            /// 获取数据表前端脚本路径。
            /// </summary>
            /// <param name="name">数据表前端脚本名称。</param>
            /// <param name="ext">数据表前端脚本后缀名。</param>
            /// <returns>数据表前端脚本路径。</returns>
            public static string GetTableClientScriptPath(string name, string ext = "cs")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableClientScriptPath, name, ext);
            }

            /// <summary>
            /// 获取数据表后端数据路径。
            /// </summary>
            /// <param name="name">数据表后端数据名称。</param>
            /// <param name="ext">数据表后端数据后缀名。</param>
            /// <returns>数据表后端数据路径。</returns>
            public static string GetTableServerDataPath(string name, string ext = "txt")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableServerDataPath, name, ext);
            }

            /// <summary>
            /// 获取数据表后端脚本路径。
            /// </summary>
            /// <param name="name">数据表后端脚本名称。</param>
            /// <param name="ext">数据表后端脚本后缀名。</param>
            /// <returns>数据表后端脚本路径。</returns>
            public static string GetTableServerScriptPath(string name, string ext = "txt")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableServerScriptPath, name, ext);
            }

            /// <summary>
            /// 获取数据表 JSON 路径。
            /// </summary>
            /// <param name="name">数据表 JSON 名称。</param>
            /// <param name="ext">数据表 JSON 后缀名。</param>
            /// <returns>数据表 JSON 路径。</returns>
            public static string GetTableJsonPath(string name, string ext = "json")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableJsonPath, name, ext);
            }

            /// <summary>
            /// 获取数据表语言表路径。
            /// </summary>
            /// <param name="name">数据表语言表名称。</param>
            /// <param name="ext">数据表语言表后缀名。</param>
            /// <returns>数据表 JSON 路径。</returns>
            public static string GetTableLanguagePath(string name, string ext = "xml")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableLanguagePath, name, ext);
            }
            
            # endregion

            # region ------------------------------------------------------------------------------------------ UI

            /// <summary>
            /// 资源 UI 目录。
            /// </summary>
            public const string RUIPath = RPath + "/UIProj";

            public const string RUIAtlasPath = RUIPath + "/Atlases";
            public const string RUIFontPath = RUIPath + "/Fonts";
            public const string RUIEntityPath = RUIPath + "/Entities";
            public const string RUIFormPath = RUIPath + "/Forms";
            public const string RUISpritePath = RUIPath + "/Sprites";
            public const string RUITexturePath = RUIPath + "/Textures";

            /// <summary>
            /// 获取 UI 图集精灵资源路径。
            /// </summary>
            /// <param name="atlasName">图集名称。</param>
            /// <param name="spriteName">精灵名称。</param>
            /// <param name="ext">精灵资源后缀名。</param>
            /// <returns>UI 图集精灵资源路径。</returns>
            public static string GetUIAtlasSpritePath(string atlasName, string spriteName, string ext = "png")
            {
                return Utility.Text.Format("{0}/{1}/{2}.{3}", RUIAtlasPath, atlasName, spriteName, ext);
            }

            /// <summary>
            /// 获取 UI 图集资源路径。
            /// </summary>
            /// <param name="name">图集名称。</param>
            /// <param name="ext">图集资源后缀名。</param>
            /// <returns>UI 图集资源路径。</returns>
            public static string GetUIAtlasPath(string name, string ext = "spriteatlas")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUIAtlasPath, name, ext);
            }

            /// <summary>
            /// 获取 UI 字体资源路径。
            /// </summary>
            /// <param name="name">字体资源名称。</param>
            /// <param name="ext">字体资源后缀名。</param>
            /// <returns>UI 字体资源路径。</returns>
            public static string GetUIFontPath(string name, string ext = "asset")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUIFontPath, name, ext);
            }
            
            /// <summary>
            /// 获取 UI 控件实体路径。
            /// </summary>
            /// <param name="name">小控件实体名称</param>
            /// <param name="ext">小控件实体后缀名。</param>
            /// <returns>UI 小控件实体路径。</returns>
            public static string GetUIItemPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUIEntityPath, name, ext);
            }

            /// <summary>
            /// 获取 UI 界面资源路径。
            /// </summary>
            /// <param name="name">界面资源名称。</param>
            /// <param name="ext">界面资源后缀名。</param>
            /// <returns>界面资源路径。</returns>
            public static string GetUIFormPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUIFormPath, name, ext);
            }
            
            /// <summary>
            /// 获取 UI 精灵资源路径。
            /// </summary>
            /// <param name="name">精灵资源名称。</param>
            /// <param name="ext">精灵资源后缀名。</param>
            /// <returns>精灵资源路径。</returns>
            public static string GetUISpritePath(string name, string ext = "png")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUISpritePath, name, ext);
            }
            
            /// <summary>
            /// 获取 UI 纹理资源路径。
            /// </summary>
            /// <param name="name">纹理资源名称。</param>
            /// <param name="ext">纹理资源后缀名。</param>
            /// <returns>纹理资源路径。</returns>
            public static string GetUITexturePath(string name, string ext = "png")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUITexturePath, name, ext);
            }
            
            # endregion

            # region ------------------------------------------------------------------------------------------ Effect

            /// <summary>
            /// 资源特效目录。
            /// </summary>
            public const string REffectPath = RPath + "/EffetProj";
            public const string REffectEntityPath = REffectPath + "/Entities";
            public const string REffectPrefabPath = REffectPath + "/Prefabs";
            public const string REffectAnimationPath = REffectPath + "/Animations";
            public const string REffectAnimatorPath = REffectPath + "/Animators";
            public const string REffectTexturePath = REffectPath + "/Textures";
            public const string REffectMaterialPath = REffectPath + "/Materials";

            /// <summary>
            /// 获取特效预制件路径。
            /// </summary>
            /// <param name="name">特效预制件名称。</param>
            /// <param name="ext">特效预制件后缀名。</param>
            /// <returns>特效预制件路径。</returns>
            public static string GetEffectPrefabPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", REffectEntityPath, name, ext);
            }
            
            /// <summary>
            /// 获取特效实体路径。
            /// </summary>
            /// <param name="name">特效实体名称。</param>
            /// <param name="ext">特效实体后缀名。</param>
            /// <returns>特效实体路径。</returns>
            public static string GetEffectEntityPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", REffectEntityPath, name, ext);
            }

            # endregion

            # region ------------------------------------------------------------------------------------------ Model

            /// <summary>
            /// 资源模型目录。
            /// </summary>
            public const string RModelPath = RPath + "/ModelProj";
            public const string RModelEntityPath = RModelPath + "/Entities";
            public const string RModelPrefabPath = RModelPath + "/Prefabs";
            public const string RModelAnimationPath = RModelPath + "/Animations";
            public const string RModelAnimatorPath = RModelPath + "/Animators";
            public const string RModelTexturePath = RModelPath + "/Textures";
            public const string RModelMaterialPath = RModelPath + "/Materials";
            
            /// <summary>
            /// 获取模型预制件路径。
            /// </summary>
            /// <param name="name">模型预制件名称。</param>
            /// <param name="ext">模型预制件后缀名。</param>
            /// <returns>模型预制件路径。</returns>
            public static string GetModelPrefabPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RModelPrefabPath, name, ext);
            }

            /// <summary>
            /// 获取模型实体路径。
            /// </summary>
            /// <param name="name">模型实体名称。</param>
            /// <param name="ext">模型实体后缀名。</param>
            /// <returns>模型实体路径。</returns>
            public static string GetModelEntityPath(string name, string ext = "prefab")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RModelEntityPath, name, ext);
            }
            # endregion
        }
    }
}