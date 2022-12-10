using System.ComponentModel;
using AdventOfCode.Core;
using Microsoft.VisualBasic.FileIO;

namespace AdventOfCode.Challenges;

[Description("Day 10")]
public class Day10 : Challenge<Day10>
{
    public Day10(string[] input) : base(input)
    {
    }

    public Day10() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var messageSignalCycle = 20;
        var signalStrengths = new List<int>();
        var cycles = new List<int>();
        
        foreach (var t in _input)
        {
            cycles.Add(0);
            if (t.Equals("noop")) continue;
            
            cycles.Add(int.Parse(t.Split(" ")[1]));
        }

        var x = 1;
        for (var i = 0; i < cycles.Count; i++)
        {
            if (i == messageSignalCycle - 1)
            {
                signalStrengths.Add((i + 1) * x);
                messageSignalCycle += 40;
            }
            x += cycles[i];
        }

        return signalStrengths.Sum();
    }


    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}
