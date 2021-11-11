using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// GM界面。
    /// </summary>
    [Identity((int) UIFormId.GMForm)]
    public class GMPresenter : UIFormPresenter<GMView, GMProp>
    {
        private int m_SelectIndex = -1;
        private IGMOperator[] m_Operators;

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.BackClicked = HideSelf;
            m_View.OperatorSelected = Select;
            m_View.ActionSelected = Action;

            m_Operators = Entry.GM.Operators.ToArray();
            m_View.SetOperators(m_Operators);
            m_View.SetSelectOperator(null);
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        private void Select(int index)
        {
            if (m_SelectIndex != index)
            {
                m_SelectIndex = index;
                m_View.SetSelectOperator(m_Operators[m_SelectIndex]);
            }
        }

        private void Action(int index)
        {
            m_Operators[m_SelectIndex].Actions[index].Invoke();
        }

        private void HideSelf()
        {
            Entry.UI.CloseUIForm(UIFormId.GMForm);
        }
    }
}