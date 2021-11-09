using GameFramework.Resource;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 闪屏流程，编辑器下跳过。。
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        public override bool UseNativeDialog => true;

        private ProcedureOwner m_ProcedureOwner;

        private SplashForm m_SplashForm;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;
            //编辑器下跳过闪屏动画，直接进入下一个流程。
            if (Application.isEditor)
            {
                Leave();
            }
            else
            {
                OnSplashStart();
            }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnSplashStart()
        {
            m_SplashForm = Entry.BuiltinData.SplashForm;
            m_SplashForm.gameObject.SetActive(true);
            m_SplashForm.onComplete += OnSplashComplete;
            m_SplashForm.StartSplash();
        }

        private void OnSplashComplete()
        {
            if (m_SplashForm != null)
            {
                m_SplashForm.onComplete -= OnSplashComplete;
                Object.Destroy(m_SplashForm.gameObject);
            }

            Leave();
        }

        private void Leave()
        {
            if (Entry.Base.EditorResourceMode)
            {
                // 编辑器模式，跳过版本、资源检查，直接进入预加载流程。
                Log.Info("Editor resource mode detected.");
                ChangeState<ProcedurePreload>(m_ProcedureOwner);
            }
            else if (Entry.Resource.ResourceMode == ResourceMode.Package)
            {
                // 单机模式，资源在 StreamingAssets 下，进入单机模式初始化资源流程。
                Log.Info("Package resource mode detected.");
                ChangeState<ProcedureInitResources>(m_ProcedureOwner);
            }
            else
            {
                // 可更新模式，进入检查版本流程。
                Log.Info("Updatable resource mode detected.");
                ChangeState<ProcedureCheckVersion>(m_ProcedureOwner);
            }
        }
    }
}