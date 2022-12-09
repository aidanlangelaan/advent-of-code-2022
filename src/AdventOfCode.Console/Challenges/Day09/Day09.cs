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

        var visitedPositionsByTail = new List<(int, int)> { (0, 0) };
        int tailX = 0,
            tailY = 0,
            headX = 0,
            headY = 0;
        foreach (var move in movements)
        {
            for (var i = 1; i <= move.Item2; i++)
            {
                switch (move.Item1)
                {
                    case "U":
                        headY += 1;
                        if (CoversOrInSurroundingArea(tailX, tailY, headX, headY))
                        {
                            continue;
                        }

                        if (headY > tailY && headX != tailX)
                        {
                            tailX = headX;
                        }

                        tailY += 1;
                        break;
                    case "D":
                        headY -= 1;
                        if (CoversOrInSurroundingArea(tailX, tailY, headX, headY))
                        {
                            continue;
                        }

                        if (headY < tailY && headX != tailX)
                        {
                            tailX = headX;
                        }

                        tailY -= 1;
                        break;
                    case "L":
                        headX -= 1;
                        if (CoversOrInSurroundingArea(tailX, tailY, headX, headY))
                        {
                            continue;
                        }

                        if (headX < tailX && headX != tailX)
                        {
                            tailY = headY;
                        }

                        tailX -= 1;
                        break;
                    case "R":
                        headX += 1;
                        if (CoversOrInSurroundingArea(tailX, tailY, headX, headY))
                        {
                            continue;
                        }

                        if (headX > tailX && headX != tailX)
                        {
                            tailY = headY;
                        }
                        tailX += 1;
                        break;
                }

                visitedPositionsByTail.Add((tailX, tailY));
            }
        }
        return visitedPositionsByTail.Distinct().Count();
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }

    private IEnumerable<(string, int)> ParseMovements() =>
        _input
            .Select(line => line.Split(" "))
            .Select(x => (x[0], int.Parse(x[1])));

    private static bool CoversOrInSurroundingArea(int tailX, int tailY, int headX, int headY) =>
        tailX == headX && tailY == headY // covered
        || tailX == headX && tailY + 1 == headY // top
        || tailX == headX && tailY - 1 == headY // bottom
        || tailY == headY && tailX + 1 == headX // right
        || tailY == headY && tailX - 1 == headX // left
        || tailY + 1 == headY && tailX - 1 == headX // top-left
        || tailY + 1 == headY && tailX + 1 == headX // top-right
        || tailY - 1 == headY && tailX - 1 == headX // bottom-left
        || tailY - 1 == headY && tailX + 1 == headX; // bottom-right
}