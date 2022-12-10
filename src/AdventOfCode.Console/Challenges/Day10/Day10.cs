using System.ComponentModel;
using AdventOfCode.Core;

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
        var cycles = GetCycles();
        var signalStrengths = GetSignalStrengths(cycles);

        return signalStrengths.Sum();
    }

    public override int SolvePart2()
    {
        var cycles = GetCycles();
        var crtOutput = ConvertCyclesToCrtOutput(cycles);

        var row = 0;
        while (row < 6)
        {
            Console.WriteLine(crtOutput.Substring(row * 40, 40));
            row += 1;
        }

        return 0;
    }

    private List<int> GetCycles()
    {
        var cycles = new List<int>();
        foreach (var t in _input)
        {
            cycles.Add(0);
            if (t.Equals("noop")) continue;

            cycles.Add(int.Parse(t.Split(" ")[1]));
        }

        return cycles;
    }

    private static IEnumerable<int> GetSignalStrengths(IReadOnlyList<int> cycles)
    {
        var x = 1;
        var messageSignalCycle = 20;
        var signalStrengths = new List<int>();
        for (var i = 0; i < cycles.Count; i++)
        {
            if (i == messageSignalCycle - 1)
            {
                signalStrengths.Add((i + 1) * x);
                messageSignalCycle += 40;
            }

            x += cycles[i];
        }

        return signalStrengths;
    }

    private static string ConvertCyclesToCrtOutput(List<int> cycles)
    {
        var x = 1;
        var crtCount = 0;
        var crtOutput = string.Empty;
        foreach (var cycle in cycles)
        {
            if (crtCount == x
                || crtCount == x - 1
                || crtCount == x + 1)
            {
                crtOutput += "#";
            }
            else
            {
                crtOutput += ".";
            }

            crtCount += 1;
            x += cycle;

            if (crtCount == 40)
            {
                crtCount = 0;
            }
        }

        return crtOutput;
    }
}