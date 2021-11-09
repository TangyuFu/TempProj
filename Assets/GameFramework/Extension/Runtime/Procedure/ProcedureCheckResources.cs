using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 检查资源流程。
    /// </summary>
    public class ProcedureCheckResources : ProcedureBase
    {
        private bool m_CheckResourcesComplete = false;
        private bool m_NeedUpdateResources = false;
        private int m_UpdateResourceCount = 0;
        private long m_UpdateResourceTotalCompressedLength = 0L;

        public override bool UseNativeDialog => true;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_CheckResourcesComplete = false;
            m_NeedUpdateResources = false;
            m_UpdateResourceCount = 0;
            m_UpdateResourceTotalCompressedLength = 0L;

            Entry.Resource.CheckResources(OnCheckResourcesComplete);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_CheckResourcesComplete)
            {
                return;
            }

            // 需要更新资源时进入更新资源流程，否则进入预加载流程。
            if (m_NeedUpdateResources)
            {
                procedureOwner.SetData<VarInt32>("UpdateResourceCount", m_UpdateResourceCount);
                procedureOwner.SetData<VarInt64>("UpdateResourceTotalCompressedLength",
                    m_UpdateResourceTotalCompressedLength);
                ChangeState<ProcedureUpdateResources>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
        }

        private void OnCheckResourcesComplete(int movedCount, int removedCount, int updateCount, long updateTotalLength,
            long updateTotalCompressedLength)
        {
            m_CheckResourcesComplete = true;
            m_NeedUpdateResources = updateCount > 0;
            m_UpdateResourceCount = updateCount;
            m_UpdateResourceTotalCompressedLength = updateTotalCompressedLength;
            Log.Info(
                "Check resources complete, '{0}' resources need to update, compressed length is '{1}', uncompressed length is '{2}'.",
                updateCount.ToString(), updateTotalCompressedLength.ToString(), updateTotalLength.ToString());
        }
    }
}