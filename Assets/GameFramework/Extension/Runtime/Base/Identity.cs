using UnityEngine;
using UnityEngine.Events;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// ID 依附于场景物体，用于射线检测。
    /// </summary>
    public class Identity : MonoBehaviour
    {
        [SerializeField] private int m_Id;

        /// <summary>
        /// Identity 的 Id.
        /// </summary>
        public int Id
        {
            get => m_Id;
            set => m_Id = value;
        }

        private UnityEvent m_OnClick;

        /// <summary>
        /// Identity 的 点击事件。
        /// </summary>
        public UnityEvent OnClick => m_OnClick ??= new UnityEvent();
    }
}