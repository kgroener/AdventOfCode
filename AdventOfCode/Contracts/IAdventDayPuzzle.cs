using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Contracts
{
    interface IAdventDayPuzzle
    {
        string Description { get; }
        DateTime Date { get; } 
        IEnumerable<IAdventDaySolution> GetSolutions();
    }
}
