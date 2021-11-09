using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class GMView : MVCView<GMProp>
    {
        public UnityAction BackClicked { get; set; }
        public UnityAction<int> OperatorSelected { get; set; }
        public UnityAction<int> ActionSelected { get; set; }

        private readonly List<GMOperatorItemProp> m_OperatorItemProps = new List<GMOperatorItemProp>();
        private readonly List<GMArgItemProp> m_ArgItemProps = new List<GMArgItemProp>();
        private readonly List<GMActionItemProp> m_ActionItemProps = new List<GMActionItemProp>();

        private IGMOperator m_CurrentOperator;

        public override void Init(GMProp prop)
        {
            base.Init(prop);

            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.AddListener(OnBackClick);
            m_OperatorItemProps.ForEach(itemProp =>
            {
                UIClickTrigger.Get(itemProp.BlockGameObject).onClick.AddListener(OnOperatorClick);
            });

            m_ActionItemProps.ForEach(itemProp =>
            {
                UIClickTrigger.Get(itemProp.BlockGameObject).onClick.AddListener(OnActionClick);
            });
        }

        public override void Deinit()
        {
            base.Deinit();

            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.RemoveListener(OnBackClick);
            m_OperatorItemProps.ForEach(prop =>
            {
                UIClickTrigger.Get(prop.BlockGameObject).onClick.RemoveListener(OnOperatorClick);
            });

            m_ActionItemProps.ForEach(prop =>
            {
                UIClickTrigger.Get(prop.BlockGameObject).onClick.RemoveListener(OnActionClick);
            });
        }

        public void SetOperators(IGMOperator[] operators)
        {
            m_Prop.OperationItemGameObejct.SetActive(false);
            m_Prop.ArgItemGameObejct.SetActive(false);
            m_Prop.OperationItemGameObejct.SetActive(false);

            for (int i = 0; i < operators.Length; i++)
            {
                IGMOperator @operator = operators[i];
                GMOperatorItemProp operatorItemProp = null;
                if (m_OperatorItemProps.Count <= i)
                {
                    GameObject itemGameObject =
                        Object.Instantiate(m_Prop.OperationItemGameObejct, m_Prop.OperationRootTransform);
                    itemGameObject.transform.localScale = Vector3.one;
                    operatorItemProp = itemGameObject.GetComponent<GMOperatorItemProp>();
                    UIClickTrigger.Get(operatorItemProp.BlockGameObject).onClick.AddListener(OnOperatorClick);
                    m_OperatorItemProps.Add(operatorItemProp);
                }
                else
                {
                    operatorItemProp = m_OperatorItemProps[i];
                }

                operatorItemProp.gameObject.SetActive(true);
                operatorItemProp.NameText.text = @operator.Name;
            }
        }

        public void SetSelectOperator(IGMOperator @operator)
        {
            m_CurrentOperator = @operator;

            foreach (var argItemProp in m_ArgItemProps)
            {
                argItemProp.gameObject.SetActive(false);
            }

            if (m_CurrentOperator != null)
            {
                for (int i = 0; i < m_CurrentOperator.ArgNames.Length; i++)
                {
                    GMArgItemProp argItemProp = null;
                    if (m_ArgItemProps.Count <= i)
                    {
                        GameObject itemGameObject =
                            Object.Instantiate(m_Prop.ArgItemGameObejct, m_Prop.ArgRootTransform);
                        itemGameObject.transform.localScale = Vector3.one;
                        argItemProp = itemGameObject.GetComponent<GMArgItemProp>();
                        m_ArgItemProps.Add(argItemProp);
                    }
                    else
                    {
                        argItemProp = m_ArgItemProps[i];
                    }

                    argItemProp.gameObject.SetActive(true);
                    argItemProp.NameText.text = m_CurrentOperator.ArgNames[i];
                    argItemProp.ArgInputField.text = string.Empty;
                }
            }

            foreach (var actionItemProp in m_ActionItemProps)
            {
                actionItemProp.gameObject.SetActive(false);
            }

            if (m_CurrentOperator != null)
            {
                for (int i = 0; i < m_CurrentOperator.ActionNames.Length; i++)
                {
                    GMActionItemProp actionItemProp = null;
                    if (m_ActionItemProps.Count <= i)
                    {
                        GameObject itemGameObject =
                            Object.Instantiate(m_Prop.ActionItemGameObejct, m_Prop.ActionRootTransform);
                        itemGameObject.transform.localScale = Vector3.one;
                        actionItemProp = itemGameObject.GetComponent<GMActionItemProp>();
                        UIClickTrigger.Get(actionItemProp.BlockGameObject).onClick.AddListener(OnActionClick);
                        m_ActionItemProps.Add(actionItemProp);
                    }
                    else
                    {
                        actionItemProp = m_ActionItemProps[i];
                    }

                    actionItemProp.gameObject.SetActive(true);
                    actionItemProp.NameText.text = m_CurrentOperator.ActionNames[i];
                }
            }
        }

        private void OnOperatorClick(GameObject go)
        {
            int index = go.transform.parent.GetSiblingIndex();
            OperatorSelected?.Invoke(index);
        }

        private void OnActionClick(GameObject go)
        {
            for (int i = 0; i < m_CurrentOperator.Args.Length; i++)
            {
                string arg = m_ArgItemProps[i].ArgInputField.text;
                m_CurrentOperator.Args[i] = arg;
            }

            int index = go.transform.parent.GetSiblingIndex();
            ActionSelected?.Invoke(index);
        }

        private void OnBackClick(GameObject go)
        {
            BackClicked?.Invoke();
        }
    }
}