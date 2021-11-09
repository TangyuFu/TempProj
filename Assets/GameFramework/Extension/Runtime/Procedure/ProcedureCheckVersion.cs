using GameFramework;
using GameFramework.Event;
using GameFramework.Resource;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 检查版本流程，可更新模式下进行版本、资源检查。
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        private bool m_CheckVersionComplete = false;
        private bool m_NeedUpdateVersion = false;
        private VersionInfo m_VersionInfo = null;

        public override bool UseNativeDialog => true;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_CheckVersionComplete = false;
            m_NeedUpdateVersion = false;
            m_VersionInfo = null;

            Entry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            Entry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

            // 向服务器请求版本信息
            BuildInfo buildInfo = Entry.BuiltinData.BuildInfo;
            string versionUrl = Utility.Text.Format("{0}Version_{1}_{2}.txt",
                buildInfo.Url,
                GetPlatformPath(),
                buildInfo.Channel);
            Entry.WebRequest.AddWebRequest(versionUrl, this);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            Entry.Event.Unsubscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            Entry.Event.Unsubscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_CheckVersionComplete)
            {
                return;
            }

            // 需要更新本地版本信息是进入更新本地版本信息流程，否则直接进入检查资源流程。
            if (m_NeedUpdateVersion)
            {
                procedureOwner.SetData<VarInt32>("VersionListLength", m_VersionInfo.VersionListLength);
                procedureOwner.SetData<VarInt32>("VersionListHashCode", m_VersionInfo.VersionListHashCode);
                procedureOwner.SetData<VarInt32>("VersionListCompressedLength",
                    m_VersionInfo.VersionListCompressedLength);
                procedureOwner.SetData<VarInt32>("VersionListCompressedHashCode",
                    m_VersionInfo.VersionListCompressedHashCode);
                ChangeState<ProcedureUpdateVersion>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedureCheckResources>(procedureOwner);
            }
        }

        private void GotoUpdateApp(object userData)
        {
            string url;
            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer)
            {
                url = Entry.BuiltinData.BuildInfo.WindowsAppUrl;
            }
            else if (Application.platform == RuntimePlatform.OSXEditor ||
                     Application.platform == RuntimePlatform.OSXPlayer)
            {
                url = Entry.BuiltinData.BuildInfo.OSXAppUrl;
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                url = Entry.BuiltinData.BuildInfo.IOSAppUrl;
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                url = Entry.BuiltinData.BuildInfo.AndroidAppUrl;
            }
            else
            {
                Log.Error($"Unsupported platform '{Application.platform}'.");
                return;
            }

            if (!string.IsNullOrEmpty(url))
            {
                Application.OpenURL(url);
            }
        }

        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            // 解析版本信息
            byte[] versionInfoBytes = ne.GetWebResponseBytes();
            string versionInfoString = Utility.Converter.GetString(versionInfoBytes);
            m_VersionInfo = Utility.Json.ToObject<VersionInfo>(versionInfoString);
            if (m_VersionInfo == null)
            {
                Log.Error("Parse VersionInfo failure.");
                return;
            }

            Log.Info("Latest game version is '{0} ({1})', local game version is '{2} ({3})'.",
                m_VersionInfo.LatestVersion, m_VersionInfo.InternalVersion.ToString(), Version.GameVersion,
                Version.InternalGameVersion.ToString());

            if (m_VersionInfo.LatestVersion != Entry.BuiltinData.BuildInfo.Version)
            {
                // 需要强制更新游戏应用
                Entry.UI.OpenDialog(new DialogParams
                {
                    Mode = 2,
                    Title = Entry.Localization.GetString("ForceUpdate.Title"),
                    Message = Entry.Localization.GetString("ForceUpdate.Message"),
                    ConfirmText = Entry.Localization.GetString("ForceUpdate.UpdateButton"),
                    OnClickConfirm = GotoUpdateApp,
                    CancelText = Entry.Localization.GetString("ForceUpdate.QuitButton"),
                    OnClickCancel = delegate { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
                });

                return;
            }

            // 设置资源更新下载地址
            string updateUri = Utility.Text.Format("{0}{1}_{2}/{3}",
                m_VersionInfo.UpdateUrl,
                m_VersionInfo.LatestVersion.Replace('.', '_'),
                m_VersionInfo.ResourceVersion,
                GetPlatformPath());
            Entry.Resource.UpdatePrefixUri = updateUri;

            m_CheckVersionComplete = true;
            // 检查是否需要更新本地版本信息。
            m_NeedUpdateVersion = Entry.Resource.CheckVersionList(m_VersionInfo.ResourceVersion) ==
                                  CheckVersionListResult.NeedUpdate;
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            WebRequestFailureEventArgs ne = (WebRequestFailureEventArgs) e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Warning("Check version failure, error message is '{0}'.", ne.ErrorMessage);
        }

        private string GetPlatformPath()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";

                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    return "MacOS";

                case RuntimePlatform.IPhonePlayer:
                    return "IOS";

                case RuntimePlatform.Android:
                    return "Android";

                default:
                    throw new System.NotSupportedException(Utility.Text.Format("Platform '{0}' is not supported.",
                        Application.platform.ToString()));
            }
        }
    }
}