using System.ComponentModel;
using System.Text.Json.Nodes;
using AdventOfCode.Core;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

[Description("Day 13")]
public class Day13 : Challenge<Day13>
{
    public Day13(string[] input) : base(input)
    {
    }

    public Day13() : base()
    {
    }

    public override int SolvePart1()
    {
        var pairs = GetPairs();

        var correctPairIndexes = new List<int>();
        foreach (var (pair, index) in pairs.WithIndex())
        {
            var left = pair[0] as JsonArray;
            var right = pair[1] as JsonArray;

            var result = Compare(left, right);
            if (result < 0)
            {
                correctPairIndexes.Add(index + 1);
            }
        }

        return correctPairIndexes.Sum();
    }

    private static int Compare(JsonNode? left, JsonNode? right)
    {
        if (left is JsonValue && right is JsonValue)
        {
            return (int)left - (int)right;
        }

        var leftArray = left as JsonArray ?? new JsonArray((int)left!);
        var rightArray = right as JsonArray ?? new JsonArray((int)right!);

        return leftArray
            .Zip(rightArray)
            .Select(x => 
                Compare(x.First, x.Second))
            .FirstOrDefault(x => x != 0, leftArray.Count - rightArray.Count);
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }

    private IEnumerable<JsonNode?[]> GetPairs() =>
        _input.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => JsonNode.Parse(x))
            .Chunk(2);
}