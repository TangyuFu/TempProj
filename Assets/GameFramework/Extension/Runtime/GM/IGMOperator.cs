using System;

namespace UnityGameFramework.Runtime.Extension
{
    public interface IGMOperator
    {
        int Priority { get; }
        string Name { get; }
        string[] ArgNames { get; }
        string[] Args { get; set; }
        string[] ActionNames { get; }
        Action[] Actions { get; }
    }
}