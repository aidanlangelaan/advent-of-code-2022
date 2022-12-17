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

    public override int SolvePart2()
    {
        var pairs = GetPairs(true).ToList();
        var simpleList = pairs.SelectMany(x => x).ToList();
        simpleList.Sort(Compare);
        
        var part1 = simpleList.FindIndex(x => JsonNode.Parse("[[2]]")!.ToString().Equals(x.ToString())) + 1;
        var part2 = simpleList.FindIndex(x => JsonNode.Parse("[[6]]")!.ToString().Equals(x.ToString())) + 1;

        return part1 * part2;
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

    private IEnumerable<JsonNode?[]> GetPairs(bool includeDividerPackages = false)
    {
        var input = _input.ToList();
        if (includeDividerPackages)
        {
            input.Add("[[2]]");
            input.Add("[[6]]");
        }
        
        return input.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => JsonNode.Parse(x))
            .Chunk(2);
    }
}