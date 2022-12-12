using System.Collections.Immutable;
using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 12")]
public class Day12 : Challenge<Day12>
{
    public Day12(string[] input) : base(input)
    {
    }

    public Day12() : base()
    {
    }

    public override int SolvePart1()
    {
        var (map, startPosition, endPosition) = ParseMap();
        
        var distances = FindDistances(map, startPosition);
        return distances[endPosition].Distance;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }

    private (Dictionary<(int, int), Node> map, (int, int) startPosition, (int, int) endPosition) ParseMap()
    {
        var map = new Dictionary<(int, int), Node>();
        (int, int) startPosition, endPosition = startPosition = (0, 0);

        for (var row = 0; row < _input.Length; row++)
        {
            for (var col = 0; col < _input[0].Length; col++)
            {
                var node = _input[row][col];
                switch (node)
                {
                    case 'S':
                        startPosition = (col, row);
                        map.Add(startPosition, new Node { HeightValue = 0 });
                        break;
                    case 'E':
                        endPosition = (col, row);
                        map.Add(endPosition, new Node { HeightValue = 27 });
                        break;
                    default:
                        map.Add((col, row), new Node { HeightValue = char.ToUpper(node) - 64 });
                        break;
                }
            }
        }

        return (map, startPosition, endPosition);
    }
    
    // Use bread-width search to determine the distance between the nodes in the map   
    private ImmutableDictionary<(int, int), Node> FindDistances(IReadOnlyDictionary<(int, int), Node> map, (int, int) startPosition)
    {
        var visited = new Dictionary<(int, int), Node> { { startPosition, new Node { HeightValue = 0 } } };
        var queue = new Queue<(int, int)>();
        queue.Enqueue(startPosition);

        while (queue.Any())
        {
            var coordinates = queue.Dequeue();
            var node = visited[coordinates];

            var neighboringNodes = GetNeighbours(coordinates).Where(map.ContainsKey);
            foreach (var neighbourCoordinates in neighboringNodes)
            {
                if (visited.ContainsKey(neighbourCoordinates)) continue;

                var neighbourNode = map[neighbourCoordinates];
                
                if (neighbourNode.HeightValue - node.HeightValue > 1) continue;
                
                visited.Add(neighbourCoordinates, neighbourNode with { Distance = node.Distance + 1 });
                queue.Enqueue(neighbourCoordinates);
            }
        }

        return visited.ToImmutableDictionary();
    }

    private IEnumerable<(int, int)> GetNeighbours((int, int) node) =>
        new[]
        {
            node with { Item2 = node.Item2 + 1 },
            node with { Item2 = node.Item2 - 1 },
            node with { Item1 = node.Item1 + 1 },
            node with { Item1 = node.Item1 - 1 },
        };

    private record Node
    {
        public int HeightValue { get; init; }
        public int Distance { get; init; }
    }
}