using System.ComponentModel;
using System.Reflection.Metadata;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 03")]
public class Day03 : Challenge<Day03>
{
    public Day03(string[] Input) : base(Input)
    {
    }

    public Day03() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var prioritySum = 0;
        foreach (var bag in _input)
        {
            var splitLenght = bag.Length / 2;
            var comp1 = bag[..(splitLenght)].ToArray();
            var comp2 = bag[splitLenght..].ToArray();
            
            var sharedItem = comp1.Intersect(comp2).First();
            
            var priority = CalculatePriority(sharedItem);
            prioritySum += priority;
        }

        return prioritySum;
    }

    public override int SolvePart2()
    {
        int bagGroupCount = _input.Length / 3, 
            groupCount = 0,
            prioritySum = 0;

        while (groupCount < bagGroupCount)
        {
            var bags = _input.Skip(groupCount * 3).Take(3).Select(x => x.ToList()).ToList();

            var sharedItem = bags.Aggregate<IEnumerable<char>>((prev, next) => prev.Intersect(next)).First();
            
            var priority = CalculatePriority(sharedItem);
            prioritySum += priority;
            
            groupCount += 1;
        }

        return prioritySum;
    }

    private static int CalculatePriority(char sharedItem)
    {
        var priority = char.ToUpper(sharedItem) - 64;
        if (char.IsUpper(sharedItem))
        {
            priority += 26;
        }

        return priority;
    }
}