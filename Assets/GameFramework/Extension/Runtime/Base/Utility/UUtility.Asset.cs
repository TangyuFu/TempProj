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
            /// 资源数据表目录。s
            /// </summary>
            public const string RTablePath = RPath + "/DataTables";

            public const string RTableDataPath = RTablePath + "/Data";
            public const string RTableLanguagePath = RTablePath + "/Languages";

            /// <summary>
            /// 获取数据表数据路径。
            /// </summary>
            /// <param name="name">数据表数据名称。</param>
            /// <param name="ext">数据表数据后缀名。</param>
            /// <returns>数据表数据路径。</returns>
            public static string GetTableDataPath(string name, string ext = "txt")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RTableDataPath, name, ext);
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
            public const string RUITimelinePath = RUIPath + "/Timelines";
            public const string RUIAnimatorPath = RUIPath + "/Animators";

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
            public static string GetUIEntitiesPath(string name, string ext = "prefab")
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

            /// <summary>
            /// 获取 UI 时间线资源路径。
            /// </summary>
            /// <param name="name">时间线资源名称。</param>
            /// <param name="ext">时间线资源后缀名。</param>
            /// <returns>时间线资源路径。</returns>
            public static string GetUITimelinePath(string name, string ext = "playable")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUITimelinePath, name, ext);
            }

            /// <summary>
            /// 获取 UI 动画控制器资源路径。
            /// </summary>
            /// <param name="name">动画控制器资源名称。</param>
            /// <param name="ext">动画控制器资源后缀名。</param>
            /// <returns>动画控制器资源路径。</returns>
            public static string GetUIAnimatorPath(string name, string ext = "controller")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RUIAnimatorPath, name, ext);
            }

            # endregion

            # region ------------------------------------------------------------------------------------------ Effect

            /// <summary>
            /// 资源特效目录。
            /// </summary>
            public const string REffectPath = RPath + "/EffetProj";

            public const string REffectPrefabPath = REffectPath + "/Prefabs";
            public const string REffectEntityPath = REffectPath + "/Entities";
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
                return Utility.Text.Format("{0}/{1}.{2}", REffectPrefabPath, name, ext);
            }
            
            /// <summary>
            /// 获取特效动画控制器路径。
            /// </summary>
            /// <param name="name">特效动画控制器名称。</param>
            /// <param name="ext">特效动画控制器后缀名。</param>
            /// <returns>特效动画控制器路径。</returns>
            public static string GetEffectAnimatorPath(string name, string ext = "controller")
            {
                return Utility.Text.Format("{0}/{1}.{2}", REffectAnimatorPath, name, ext);
            }
            
            /// <summary>
            /// 获取特效纹理路径。
            /// </summary>
            /// <param name="name">特效纹理名称。</param>
            /// <param name="ext">特效纹理后缀名。</param>
            /// <returns>特效纹理路径。</returns>
            public static string GetEffectTexturePath(string name, string ext = "png")
            {
                return Utility.Text.Format("{0}/{1}.{2}", REffectTexturePath, name, ext);
            }
            
            /// <summary>
            /// 获取特效材质路径。
            /// </summary>
            /// <param name="name">特效材质名称。</param>
            /// <param name="ext">特效材质后缀名。</param>
            /// <returns>特效材质路径。</returns>
            public static string GetEffectMaterialPath(string name, string ext = "mat")
            {
                return Utility.Text.Format("{0}/{1}.{2}", REffectMaterialPath, name, ext);
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

            /// <summary>
            /// 获取特效动画控制器路径。
            /// </summary>
            /// <param name="name">特效动画控制器名称。</param>
            /// <param name="ext">特效动画控制器后缀名。</param>
            /// <returns>特效动画控制器路径。</returns>
            public static string GetModelAnimatorPath(string name, string ext = "controller")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RModelAnimatorPath, name, ext);
            }
            
            /// <summary>
            /// 获取特效纹理路径。
            /// </summary>
            /// <param name="name">特效纹理名称。</param>
            /// <param name="ext">特效纹理后缀名。</param>
            /// <returns>特效纹理路径。</returns>
            public static string GetModelTexturePath(string name, string ext = "png")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RModelTexturePath, name, ext);
            }
            
            /// <summary>
            /// 获取特效材质路径。
            /// </summary>
            /// <param name="name">特效材质名称。</param>
            /// <param name="ext">特效材质后缀名。</param>
            /// <returns>特效材质路径。</returns>
            public static string GetModelMaterialPath(string name, string ext = "mat")
            {
                return Utility.Text.Format("{0}/{1}.{2}", RModelMaterialPath, name, ext);
            }
            
            # endregion
        }
    }
}