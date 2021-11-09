using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 封装 MonoBehaviour。
    /// </summary>
    public class WrappedMonoBehaviour : MonoBehaviour
    {
        private GameObject m_GameObject;
        private Transform m_Transform;

        public new GameObject gameObject
        {
            get
            {
                if (m_GameObject == null)
                {
                    m_GameObject = gameObject;
                }

                return m_GameObject;
            }
        }

        public new Transform transform
        {
            get
            {
                if (m_Transform == null)
                {
                    m_Transform = transform;
                }

                return m_Transform;
            }
        }
    }
}