using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 04")]
public class Day04 : Challenge<Day04>
{
    public Day04(string[] Input) : base(Input)
    {
    }

    public Day04() : base()
    {
    }

    public override int SolvePart1()
    {
        var ranges = _input
            .Select(x => x
                .Replace("-", ",")
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .ToList();
        
        var contained = ranges.Count(x => x[2] >= x[0] && x[3] <= x[1]   // second-start >= first-start && second-stop <= first-stop
                          || x[0] >= x[2] && x[1] <= x[3]);                     // first-start >= second-start && first-stop <= second-stop;

        return contained;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}