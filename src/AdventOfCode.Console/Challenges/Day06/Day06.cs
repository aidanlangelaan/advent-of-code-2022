using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 06")]
public class Day06 : Challenge<Day06>
{
    public Day06(string[] input) : base(input)
    {
    }

    public Day06() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var dataStream = _input.First().ToArray();
        var markerPosition = 0;
        for (var i = 0; i < dataStream.Length; i++)
        {
            var check = dataStream.Skip(i).Take(4).Distinct();
            if (check.Count() < 4) continue;
            
            markerPosition = i + 4;
            break;
        }

        return markerPosition;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}
