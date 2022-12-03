using System.Reflection.Metadata;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

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
            
            var priority = ((int) char.ToUpper(sharedItem)) - 64;
            if (char.IsUpper(sharedItem))
            {
                priority += 26;
            }

            prioritySum += priority;
        }

        return prioritySum;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}