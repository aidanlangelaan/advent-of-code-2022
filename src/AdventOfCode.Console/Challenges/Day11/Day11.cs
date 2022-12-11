using System.ComponentModel;
using System.Text.RegularExpressions;
using AdventOfCode.Core;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

[Description("Day 11")]
public class Day11 : Challenge<Day11>
{
    public Day11(string[] input) : base(input)
    {
    }

    public Day11() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var monkeys = ParseMonkeys();
        
        PerformMonkeyBusiness(20, monkeys, true);

        var topMonkeys = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToArray();
        var monkeyBusiness = topMonkeys[0].InspectionCount * topMonkeys[1].InspectionCount; 
        
        Console.WriteLine(monkeyBusiness);
        
        return 0;
    }

    public override int SolvePart2()
    {
        var monkeys = ParseMonkeys();
        
        PerformMonkeyBusiness(10000, monkeys, false);

        var topMonkeys = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToArray();
        var monkeyBusiness = topMonkeys[0].InspectionCount * topMonkeys[1].InspectionCount; 
        
        Console.WriteLine(monkeyBusiness);
        
        return 0;
    }
    
    private static void PerformMonkeyBusiness(int rounds, List<Monkey> monkeys, bool reliefEnabled)
    {
        for (var r = 0; r < rounds; r++)
        {
            var divisionTestProduct = monkeys.Aggregate(1, (current, monkey) => current * monkey.DivisibleBy);
            foreach (var (monkey, index) in monkeys.WithIndex())
            {
                for (var i = 0; i < monkey.Items.Count; i++)
                {
                    var item = monkey.Items[i];

                    // inspection
                    var operation = monkey.Operation.Replace("old", item.ToString());
                    
                    // operation
                    item = PerformCalculation(operation);
                    item %= divisionTestProduct;
                    monkeys[index].InspectionCount += 1;

                    if (reliefEnabled)
                    {
                        // boredom
                        item /= 3;   
                    }

                    // pass the parcel
                    if (item % monkey.DivisibleBy == 0)
                    {
                        monkeys[monkey.TrueAction].Items.Add(item);
                    }
                    else
                    {
                        monkeys[monkey.FalseAction].Items.Add(item);
                    }
                }

                // remove passed items
                monkeys[index].Items.Clear();
            }
        }
    }

    private static long PerformCalculation(string operation)
    {
        var calculation = operation.Split(" ");
        var firstElem = long.Parse(Regex.Match(calculation[0], @"\d+").Value);
        var secondElem = long.Parse(Regex.Match(calculation[2], @"\d+").Value);
        var item = calculation[1] switch
        {
            "+" => firstElem + secondElem,
            "-" => firstElem - secondElem,
            "*" => firstElem * secondElem,
            "/" => firstElem / secondElem,
        };
        return item;
    }

    private List<Monkey> ParseMonkeys()
    {
        var operators = new string[] { "-", "+", "*", "/" };
        var monkeyCount = _input.Count(string.IsNullOrEmpty) + 1;
        var monkeys = new List<Monkey>();

        while (monkeys.Count < monkeyCount)
        {
            var monkeyDetails = _input.Skip(7 * monkeys.Count).Take(6).ToList();

            // items
            var items = Regex.Matches(monkeyDetails[1], @"-?\d+")
                .OfType<Match>()
                .Select(m => long.Parse(m.Value))
                .ToList();

            // operation
            var operationParts = monkeyDetails[2].Split(" ").Reverse().Take(3);//.Select(p => operators.Contains(p) ? p : p + ".0");
            var operation = string.Join(" ", operationParts);

            // test
            var divisibleBy = int.Parse(Regex.Match(monkeyDetails[3], @"\d+").Value);
            var trueAction = int.Parse(Regex.Match(monkeyDetails[4], @"\d+").Value);
            var falseAction = int.Parse(Regex.Match(monkeyDetails[5], @"\d+").Value);

            monkeys.Add(new Monkey()
            {
                Items = items,
                Operation = operation,
                DivisibleBy = divisibleBy,
                TrueAction = trueAction,
                FalseAction = falseAction
            });
        }

        return monkeys;
    }

    private class Monkey
    {
        public List<long> Items { get; init; }
        public string Operation { get; init; }
        public int DivisibleBy { get; init; }
        public int TrueAction { get; init; }
        public int FalseAction { get; init; }
        public long InspectionCount { get; set; }
    }
}
