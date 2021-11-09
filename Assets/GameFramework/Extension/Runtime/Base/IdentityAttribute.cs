using System;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// ID 特性。
    /// </summary>
    public class IdentityAttribute : Attribute
    {
        public int Id { get; private set; }

        public IdentityAttribute(int id)
        {
            Id = id;
        }
    }
}