using System.ComponentModel;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 05")]
public class Day05 : Challenge<Day05>
{
    public Day05(string[] Input) : base(Input)
    {
    }

    public Day05() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var (stackList, moveDetails) = ParseInput();
        stackList = PerformMovesOnStacks(moveDetails, stackList, false);

        var topCrates = stackList.Aggregate(string.Empty, (current, stack) => current + stack.Last());
        
        return 0;
    }
    
    public override int SolvePart2()
    {
        var (stackList, moveDetails) = ParseInput();
        stackList = PerformMovesOnStacks(moveDetails, stackList, true);

        var topCrates = stackList.Aggregate(string.Empty, (current, stack) => current + stack.Last());
        
        return 0;
    }

    private (List<List<char>> stackList, IEnumerable<Match[]> moveDetails) ParseInput()
    {
        var splitIndex = _input.ToList().FindIndex(string.IsNullOrEmpty);
        var stacks = _input[0..splitIndex];
        var moves = _input[(splitIndex + 1)..];

        var stackList = ParseStacks(stacks);
        var moveDetails = ParseMoves(moves);
        
        return (stackList, moveDetails);
    }

    private static List<List<char>> ParseStacks(string[] stacks)
    {
        var stackCount = Regex.Matches(stacks.Last(), @"\d+").Count;
        var stackList = new List<List<char>>();
        for (var i = 0; i < stackCount; i++)
        {
            stackList.Add(new List<char>());
        }

        stacks = stacks[0..^1];
        foreach (var row in stacks)
        {
            for (var y = 0; y < stackCount; y++)
            {
                var crate = string.Join("", row.Skip(y * 4).Take(3));
                if (string.IsNullOrWhiteSpace(crate))
                {
                    continue;
                }

                var crateLetter = crate[1];
                stackList[y].Add(crateLetter);
            }
        }

        stackList.ForEach(x => x.Reverse());
        return stackList;
    }
    
    private static IEnumerable<Match[]> ParseMoves(IEnumerable<string> moves) =>
        moves.Select(x => Regex.Matches(x, @"\d+").ToArray());
    
    private static List<List<char>> PerformMovesOnStacks(IEnumerable<Match[]> moveDetails, List<List<char>> stackList, bool supportsMultipleCrates)
    {
        foreach (var move in moveDetails)
        {
            var cratesToMove = int.Parse(move[0].Value);
            var stackFrom = int.Parse(move[1].Value) - 1;
            var stackTo = int.Parse(move[2].Value) - 1;

            var movingCrates = stackList[stackFrom].GetRange(stackList[stackFrom].Count - cratesToMove, cratesToMove);
            stackList[stackFrom].RemoveRange(stackList[stackFrom].Count - cratesToMove, cratesToMove);

            if (!supportsMultipleCrates)
            {
                movingCrates.Reverse();   
            }
            stackList[stackTo].AddRange(movingCrates);
        }

        return stackList;
    }
}
