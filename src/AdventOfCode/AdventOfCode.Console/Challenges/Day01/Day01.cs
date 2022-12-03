using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

public class Day01 : Challenge<Day01>
{
    public Day01(string[] Input) : base(Input)
    {
    }

    public Day01() : base()
    {
    }

    public override int SolvePart1()
    {
        var calorieTotals = GetCalorieTotals();

        return calorieTotals.Max();
    }
    
    public override int SolvePart2()
    {
        var calorieTotals = GetCalorieTotals();
        
        return calorieTotals.OrderByDescending(x => x).Take(3).Sum();
    }

    private IEnumerable<int> GetCalorieTotals()
    {
        var calorieTotals = new List<int>();
        var penguinCount = 0;

        for (int i = 0; i < _input.Length; i++)
        {
            var itemValue = _input[i];
            if (string.IsNullOrEmpty(itemValue))
            {
                calorieTotals.Add(penguinCount);
                penguinCount = 0;
                continue;
            }

            penguinCount += int.Parse(itemValue);

            if (i == _input.Length - 1)
            {
                calorieTotals.Add(penguinCount);
            }
        }

        return calorieTotals;
    }

}