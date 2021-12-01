using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Contracts
{
    interface IAdventDaySolution
    {
        string Description { get; }
        int Part { get; }
        object Solve();
    }
}
