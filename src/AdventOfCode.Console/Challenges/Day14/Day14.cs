using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 14")]
public class Day14 : Challenge<Day14>
{
    public Day14(string[] input) : base(input)
    {
    }

    public Day14() : base()
    {
    }

    private record struct Coordinate(int x, int y);

    public override int SolvePart1()
    {
        var map = CreateMap();

        var sandStartPosition = new Coordinate(500, 0);
        map[sandStartPosition] = '+';

        var abbysLevel = map.Keys.Max(c => c.y);
        var stopRun = false;
        while (!stopRun)
        {
            Coordinate? currentItemPosition = null;
            if (map.Any(x => x.Value == '+'))
            {
                currentItemPosition = map.FirstOrDefault(c => c.Value == '+').Key;
            }
            else
            {
                // start again
                map[sandStartPosition] = '+';
                currentItemPosition = sandStartPosition;
            }

            // check directions
            var down = currentItemPosition.Value with { y = currentItemPosition.Value.y + 1 };
            var downLeft = new Coordinate(currentItemPosition.Value.x - 1, currentItemPosition.Value.y + 1);
            var downRight = new Coordinate(currentItemPosition.Value.x + 1, currentItemPosition.Value.y + 1);

            // down
            if (!map.ContainsKey(down) || (map.ContainsKey(down) && !map[down].Equals('o') && !map[down].Equals('#')))
            {
                map[currentItemPosition.Value] = '.';
                map[down] = '+';

                if (down.y > abbysLevel)
                {
                    stopRun = true;
                }

                continue;
            }

            if (!map.ContainsKey(downLeft) || (map.ContainsKey(downLeft) && !map[downLeft].Equals('o') && !map[downLeft].Equals('#')))
            {
                map[currentItemPosition.Value] = '.';
                map[downLeft] = '+';

                if (down.y > abbysLevel)
                {
                    stopRun = true;
                }

                continue;
            }

            if (!map.ContainsKey(downRight) || (map.ContainsKey(downRight) && !map[downRight].Equals('o') && !map[downRight].Equals('#')))
            {
                map[currentItemPosition.Value] = '.';
                map[downRight] = '+';

                if (down.y > abbysLevel)
                {
                    stopRun = true;
                }

                continue;
            }

            // sand can't move anymore so rest
            map[currentItemPosition.Value] = 'o';
        }

        return map.Count(x => x.Value.Equals('o'));
    }

    private Dictionary<Coordinate, char> CreateMap()
    {
        var map = new Dictionary<Coordinate, char>();
        foreach (var path in _input)
        {
            var steps = path.Split(" -> ");

            var currentIndex = 0;
            for (var i = 1; i < steps.Length; i++)
            {
                var startParts = steps[currentIndex].Split(",").Select(int.Parse).ToArray();
                var startPosition = new Coordinate(startParts[0], startParts[1]);

                var endParts = steps[i].Split(",").Select(int.Parse).ToArray();
                var endPosition = new Coordinate(endParts[0], endParts[1]);

                if (startPosition.x - endPosition.x == 0)
                {
                    var rangeStart = startPosition.y;
                    var rangeCount = endPosition.y - startPosition.y;
                    if (rangeCount < 0)
                    {
                        rangeStart = endPosition.y;
                        rangeCount = startPosition.y - endPosition.y;
                    }

                    Enumerable.Range(rangeStart, rangeCount + 1).ToList().ForEach(y =>
                    {
                        var stonePosition = startPosition with { y = y };
                        if (!map.ContainsKey(stonePosition))
                        {
                            map.Add(stonePosition, '#');
                        }
                    });
                }
                else
                {
                    var rangeStart = startPosition.x;
                    var rangeCount = endPosition.x - startPosition.x;
                    if (rangeCount < 0)
                    {
                        rangeStart = endPosition.x;
                        rangeCount = startPosition.x - endPosition.x;
                    }

                    Enumerable.Range(rangeStart, rangeCount + 1).ToList().ForEach(x =>
                    {
                        var stonePosition = startPosition with { x = x };
                        if (!map.ContainsKey(stonePosition))
                        {
                            map.Add(stonePosition, '#');
                        }
                    });
                }

                currentIndex = i;
            }
        }

        return map;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}