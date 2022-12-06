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
    
    public override int SolvePart1() =>
        GetMarkerPosition(4);

    public override int SolvePart2() =>
        GetMarkerPosition(14);
    
    private int GetMarkerPosition(int distinctAmount)
    {
        var dataStream = _input.First().ToArray();
        var markerPosition = 0;
        for (var i = 0; i < dataStream.Length; i++)
        {
            var check = dataStream.Skip(i).Take(distinctAmount).Distinct();
            if (check.Count() < distinctAmount) continue;

            markerPosition = i + distinctAmount;
            break;
        }

        return markerPosition;
    }
}
