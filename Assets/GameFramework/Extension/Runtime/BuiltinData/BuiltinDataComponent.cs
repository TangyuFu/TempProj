using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架内置数据组件。
    /// 提供主内置游戏数据功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Builtin Data")]
    public sealed class BuiltinDataComponent : CustomGameFrameworkComponent
    {
        [SerializeField] private Transform m_UIInstanceRoot = null;

        [SerializeField] private TextAsset m_BuildInfoTextAsset = null;

        [SerializeField] private TextAsset m_DefaultDictionaryTextAsset = null;

        [SerializeField] private SplashForm m_SplashForm = null;

        [SerializeField] private UpdateResourceForm m_UpdateResourceForm = null;

        [SerializeField] private DialogForm m_DialogForm = null;

        private BuildInfo m_BuildInfo = null;

        /// <summary>
        /// 版本构建信息。
        /// </summary>
        public BuildInfo BuildInfo => m_BuildInfo;

        /// <summary>
        /// 闪屏界面。
        /// </summary>
        public SplashForm SplashForm
        {
            get
            {
                if (m_SplashForm == null)
                {
                    string splashFormGameObjectPath = "SplashForm";
                    GameObject splashFormGameObject = Resources.Load<GameObject>(splashFormGameObjectPath);
                    if (splashFormGameObject == null)
                    {
                        Log.Error($"Failed to load splash form from '{splashFormGameObjectPath}'.");
                    }
                    else
                    {
                        splashFormGameObject = Instantiate(splashFormGameObject, m_UIInstanceRoot);
                        splashFormGameObject.transform.localScale = Vector3.one;
                        splashFormGameObject.transform.localPosition = Vector3.zero;
                        m_SplashForm = splashFormGameObject.GetComponent<SplashForm>();
                    }

                    if (m_SplashForm != null)
                    {
                        m_SplashForm.gameObject.SetActive(false);
                    }
                }

                return m_SplashForm;
            }
        }

        /// <summary>
        /// 更新资源界面。
        /// </summary>
        public UpdateResourceForm UpdateResourceForm
        {
            get
            {
                if (m_UpdateResourceForm == null)
                {
                    string updateFormGameObjectPath = "UpdateResourceForm";
                    GameObject updateResourceFormGameObject = Resources.Load<GameObject>(updateFormGameObjectPath);
                    if (updateResourceFormGameObject == null)
                    {
                        Log.Error($"Failed to load update resource form from '{updateFormGameObjectPath}'.");
                    }
                    else
                    {
                        updateResourceFormGameObject = Instantiate(updateResourceFormGameObject, m_UIInstanceRoot);
                        updateResourceFormGameObject.transform.localScale = Vector3.one;
                        updateResourceFormGameObject.transform.localPosition = Vector3.zero;
                        m_UpdateResourceForm = updateResourceFormGameObject.GetComponent<UpdateResourceForm>();
                    }

                    if (m_UpdateResourceForm != null)
                    {
                        m_UpdateResourceForm.gameObject.SetActive(false);
                    }
                }

                return m_UpdateResourceForm;
            }
        }

        /// <summary>
        /// 对话界面
        /// </summary>
        public DialogForm DialogForm
        {
            get
            {
                if (m_DialogForm == null)
                {
                    string dialogFormGameObjectPath = "DialogForm";
                    GameObject dialogFormGameObject = Resources.Load<GameObject>(dialogFormGameObjectPath);
                    if (dialogFormGameObject == null)
                    {
                        Log.Error($"Failed to load dialog form from '{dialogFormGameObjectPath}'.");
                    }
                    else
                    {
                        dialogFormGameObject = Instantiate(dialogFormGameObject, m_UIInstanceRoot);
                        dialogFormGameObject.transform.localScale = Vector3.one;
                        dialogFormGameObject.transform.localPosition = Vector3.zero;
                        m_DialogForm = dialogFormGameObject.GetComponent<DialogForm>();
                    }

                    if (m_DialogForm != null)
                    {
                        m_DialogForm.gameObject.SetActive(false);
                    }
                }

                return m_DialogForm;
            }
        }


        protected override void Awake()
        {
            base.Awake();
        }

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null)
            {
                string buildInfoTextAssetPath = "BuildInfo";
                m_BuildInfoTextAsset = Resources.Load<TextAsset>(buildInfoTextAssetPath);
                if (m_BuildInfoTextAsset == null)
                {
                    Log.Error($"Failed to load build info from '{buildInfoTextAssetPath}'.");
                }
            }

            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }
        }

        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null)
            {
                string defaultDictionaryPath = "DefaultLanguage";
                m_DefaultDictionaryTextAsset = Resources.Load<TextAsset>(defaultDictionaryPath);
                if (m_DefaultDictionaryTextAsset == null)
                {
                    Log.Error($"Failed to load default dictionary from '{defaultDictionaryPath}'.");
                }
            }

            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not be found or empty.");
                return;
            }

            if (!Entry.Localization.ParseData(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }

        /// <summary>
        /// 内置数据组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.BuiltinData;

        /// <summary>
        /// 内置数据组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理内置数据组件。
        /// </summary>
        internal override void Shutdown()
        {
        }
    }
}