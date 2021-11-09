using GameFramework.Localization;
using GameFramework.Runtime.Extension;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 启动流程，最开始的流程，用于游戏初始化。
    /// </summary>
    public class ProcedureLaunch : ProcedureBase
    {
        public override bool UseNativeDialog => true;

        private LocalDataAgent m_LocalDataAgent;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_LocalDataAgent = Entry.PlayerData.GetDataAgent<LocalDataAgent>();
            
            // 构建信息：发布版本时，把一些数据以 Json 的格式写入 Assets/GameFramework/Extension/Resources/BuildInfo.txt，供游戏逻辑读取
            Entry.BuiltinData.InitBuildInfo();

            // 语言配置：设置当前使用的语言，如果不设置，则默认使用操作系统语言
            InitLanguageSettings();

            // 变体配置：根据使用的语言，通知底层加载对应的资源变体
            InitCurrentVariant();

            // 声音配置：根据用户配置数据，设置即将使用的声音选项
            InitSoundSettings();

            // 默认字典：加载默认字典文件  Assets/GameFramework/Extension/Resources/PresetLanguage.txt
            // 此字典文件记录了资源更新前使用的各种语言的字符串，会随 App 一起发布，故不可更新
            Entry.BuiltinData.InitDefaultDictionary();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            ChangeState<ProcedureSplash>(procedureOwner);
        }
        
        private void InitLanguageSettings()
        {
            if (Entry.Base.EditorResourceMode && Entry.Base.EditorLanguage != Language.Unspecified)
            {
                // 编辑器资源模式直接使用 Inspector 上设置的语言
                return;
            }

            Language language = m_LocalDataAgent.Language;
            if (language == Language.Unspecified)
            {
                language = Entry.Localization.SystemLanguage;
                
                if (language == Language.Unspecified)
                {
                    language = LocalizationExtension.DefaultLanguage;
                }

                m_LocalDataAgent.Language = language;
            }
            
            Entry.Localization.Language = language;
            Log.Info("Init language settings complete, current language is '{0}'.", language.ToString());
        }

        private void InitCurrentVariant()
        {
            if (Entry.Base.EditorResourceMode)
            {
                // 编辑器资源模式不使用 AssetBundle，也就没有变体了
                return;
            }

            string currentVariant = LocalizationExtension.GetVariant(Entry.Localization.Language);
            Entry.Resource.SetCurrentVariant(currentVariant);
            Log.Info("Init current variant complete.");
        }

        private void InitSoundSettings()
        {
            Entry.Sound.SetMusicMute(Entry.Sound.GetMusicMute());
            Entry.Sound.SetMusicVolume(Entry.Sound.GetMusicVolume());
            Entry.Sound.SetSoundMute(Entry.Sound.GetSoundMute());
            Entry.Sound.SetSoundVolume(Entry.Sound.GetSoundVolume());
            Entry.Sound.SetUISoundMute(Entry.Sound.GetUISoundMute());
            Entry.Sound.SetUISoundVolume(Entry.Sound.GetUISoundVolume());
            Log.Info("Init sound settings complete.");
        }
    }
}