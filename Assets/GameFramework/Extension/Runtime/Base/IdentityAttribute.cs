using System;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// ID 特性。
    /// </summary>
    public class IdentityAttribute : Attribute
    {
        private int m_Id;

        public int Id => m_Id;

        public IdentityAttribute(int id)
        {
            m_Id = id;
        }
    }
}