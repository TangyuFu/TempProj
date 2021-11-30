using System;
using System.Collections.Generic;

namespace TempProj
{
    public interface IGMOperator
    {
        int Priority { get; }
        string Name { get; }
        string[] ArgNames { get; }
        string[][] DefaultArgs { get; }
        string[] InputArgs { get; set; }
        Action Action { get; }
    }
}