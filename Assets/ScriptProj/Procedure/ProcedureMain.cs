using System.Net;
using GameFramework.Network;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace TempProj
{
    /// <summary>
    /// 主流程，自此进入游戏逻辑。
    /// </summary>
    public class ProcedureMain : ProcedureBase
    {
        public override bool UseNativeDialog => true;

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // Entry.Script.TurnOn();

            PresenterController presenterController = PresenterController.Instance;
            Entry.UI.OpenCustomUIForm(UIFormId.SceneForm);
            Entry.UI.OpenCustomUIForm(UIFormId.GuideForm);
            Entry.UI.OpenCustomUIForm(UIFormId.MaskForm);
            Entry.UI.OpenCustomUIForm(UIFormId.TipForm);
            Entry.UI.OpenCustomUIForm(UIFormId.MainForm);

            channel = Entry.Network.CreateNetworkChannel("Main", ServiceType.Tcp, new NetworkChannelHelper());
            channel.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            channel.HeartBeatInterval = 10f;
        }

        private INetworkChannel channel;
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }
    }
}