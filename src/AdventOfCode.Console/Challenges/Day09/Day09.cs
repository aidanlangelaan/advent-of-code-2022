using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 09")]
public class Day09 : Challenge<Day09>
{
    public Day09(string[] input) : base(input)
    {
    }

    public Day09() : base()
    {
    }

    public override int SolvePart1()
    {
        var movements = ParseMovements();

        var positions = GetTailPositions(movements);
        return positions.Distinct().Count();
    }

    private List<(int, int)> GetTailPositions(IEnumerable<(string, int)> movements)
    {
        var knots = Enumerable.Repeat((0, 0), 2).ToArray();
        var tailPositions = new List<(int, int)>();
        foreach (var move in movements)
        {
            for (var i = 0; i < move.Item2; i++)
            {
                knots = MoveHead(knots, move.Item1);
                tailPositions.Add(knots.Last());
            }
        }
        return tailPositions;
    }

    private (int, int)[] MoveHead((int, int)[] knots, string direction)
    {
        // move the head
        knots[0] = direction switch
        {
            "U" => knots[0] with { Item2 = knots[0].Item2 + 1 },
            "D" => knots[0] with { Item2 = knots[0].Item2 - 1 },
            "L" => knots[0] with { Item1 = knots[0].Item1 - 1 },
            "R" => knots[0] with { Item1 = knots[0].Item1 + 1 },
        };

        // move each knot
        for (var i = 1; i < knots.Length; i++)
        {
            var currentKnot = knots[i];
            var previousKnot = knots[i - 1];
            
            var deltaX = previousKnot.Item1 - currentKnot.Item1;
            var deltaY = previousKnot.Item2 - currentKnot.Item2;

            if (Math.Abs(deltaX) > 1 || Math.Abs(deltaY) > 1)
            {
                knots[i] = (currentKnot.Item1 + Math.Sign(deltaX), currentKnot.Item2 + Math.Sign(deltaY));
            } 
        }

        return knots;
    }

    public override int SolvePart2()
    {
        var movements = ParseMovements();
        
        return 0;
    }

    private IEnumerable<(string, int)> ParseMovements() =>
        _input
            .Select(line => line.Split(" "))
            .Select(x => (x[0], int.Parse(x[1])));
}