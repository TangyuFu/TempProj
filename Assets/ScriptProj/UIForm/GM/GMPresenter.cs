using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// GM界面。
    /// </summary>
    [Identity((int) UIFormId.GMForm)]
    public class GMPresenter : UIFormPresenter
    {
        private int m_SelectedIndex = -1;
        private IGMOperator[] m_Operators;
        private IGMOperator m_SelectedOperator;
        private readonly List<GameObject> m_OperatorItems = new();
        private readonly List<GameObject> m_ArgItems = new();

        private GameObject m_Action;
        private GameObject m_Back;
        private GameObject m_ArgItem;
        private Transform m_ArgList;
        private GameObject m_OperatorItem;
        private Transform m_OperatorList;

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic customUIFormLogic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, customUIFormLogic, root, userData);

            m_Action = root.Find("Action").gameObject;
            m_Back = root.Find("Back").gameObject;
            m_ArgItem = root.Find("ArgItem").gameObject;
            m_ArgList = root.Find("Args/Viewport/ArgList");
            m_OperatorItem = root.Find("OperatorItem").gameObject;
            m_OperatorList = root.Find("Operators/Viewport/OperatorList");

            m_OperatorItem.gameObject.SetActive(false);
            m_ArgItem.gameObject.SetActive(false);
            UIClickTrigger.Get(m_Action).onClick.AddListener(OnAction);
            UIClickTrigger.Get(m_Back).onClick.AddListener(OnBack);

            m_Operators = Entry.GM.Operators.ToArray();
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_Action).onClick.RemoveListener(OnAction);
            UIClickTrigger.Get(m_Back).onClick.RemoveListener(OnBack);

            m_Action = null;
            m_Back = null;
            m_ArgItem = null;
            m_ArgList = null;
            m_OperatorItem = null;
            m_OperatorList = null;

            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            AddOperators();
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            foreach (var mOperatorItem in m_OperatorItems)
            {
                Object.Destroy(mOperatorItem);
            }

            m_OperatorItems.Clear();
            foreach (var mArgItem in m_ArgItems)
            {
                Object.Destroy(mArgItem);
            }

            m_ArgItems.Clear();
            m_SelectedIndex = -1;
            m_SelectedOperator = null;
        }

        private void AddOperators()
        {
            for (int i = 0; i < m_Operators.Length; i++)
            {
                int index = i;
                IGMOperator @operator = m_Operators[i];
                Transform operatorItem = Object.Instantiate(m_OperatorItem, m_OperatorList).transform;
                operatorItem.gameObject.SetActive(true);
                operatorItem.localScale = Vector3.one;
                TMP_Text name = operatorItem.Find("Button/Name").GetComponent<TMP_Text>();
                name.text = @operator.Name;
                GameObject button = operatorItem.Find("Button").gameObject;
                UIClickTrigger.Get(button).onClick.AddListener((go) => { OnSelectOperator(index); });
                m_OperatorItems.Add(operatorItem.gameObject);
            }
        }

        private void AddArgs()
        {
            for (int i = 0; i < m_SelectedOperator.ArgNames.Length; i++)
            {
                int index = i;
                string argName = m_SelectedOperator.ArgNames[i];
                string[] defaultArgs = m_SelectedOperator.DefaultArgs.Length > i
                    ? m_SelectedOperator.DefaultArgs[i]
                    : new string[0];

                Transform argItem = Object.Instantiate(m_ArgItem, m_ArgList).transform;
                argItem.gameObject.SetActive(true);
                argItem.localScale = Vector3.one;
                TMP_Text text = argItem.Find("Name").GetComponent<TMP_Text>();
                text.text = argName;
                TMP_InputField inputField = argItem.Find("InputField").GetComponent<TMP_InputField>();
                inputField.onValueChanged.AddListener(value => { m_SelectedOperator.InputArgs[index] = value; });
                TMP_Dropdown dropdown = argItem.Find("Dropdown").GetComponent<TMP_Dropdown>();
                if (defaultArgs.Length > 0)
                {
                    dropdown.gameObject.SetActive(true);
                    List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
                    foreach (var t in defaultArgs)
                    {
                        options.Add(new TMP_Dropdown.OptionData(t));
                    }

                    dropdown.options = options;
                    dropdown.onValueChanged.AddListener(value => inputField.text = options[value].text);
                    inputField.text = options[0].text;
                    m_SelectedOperator.InputArgs[index] = options[0].text;
                }
                else
                {
                    dropdown.gameObject.SetActive(false);
                }

                m_ArgItems.Add(argItem.gameObject);
            }
        }

        private void OnSelectOperator(int index)
        {
            if (m_SelectedIndex != index)
            {
                m_SelectedOperator = m_Operators[index];
                m_SelectedIndex = index;
                foreach (var mArgItem in m_ArgItems)
                {
                    Object.Destroy(mArgItem);
                }

                m_ArgItems.Clear();
                AddArgs();
            }
        }

        private void OnAction(GameObject gameObject)
        {
            m_SelectedOperator?.Action();
        }

        private void OnBack(GameObject gameObject)
        {
            Close();
        }
    }
}