using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 08")]
public class Day08 : Challenge<Day08>
{
    public Day08(string[] input) : base(input)
    {
    }

    public Day08() : base()
    {
    }

    public override int SolvePart1()
    {
        var grid = _input.Select(t => t.Select(x => int.Parse(x.ToString())).ToList()).ToList();
        var visible = 0;
        
        for (var y = 1; y < grid.Count - 1; y++)
        {
            for (var x = 1; x < grid[y].Count - 1; x++)
            {
                if (IsTreeVisible(grid, x, y))
                {
                    visible += 1;
                }
            }
        }
        
        visible += grid[0].Count * 2 + (grid.Count - 2) * 2;
        return visible;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
    
    private static bool IsTreeVisible(IReadOnlyList<List<int>> grid, int x, int y)
    {
        var tree = grid[y][x];

        var treesLeft = grid[y].Skip(0).Take(x);
        var visibleLeft = !treesLeft.Any(i => i >= tree);
        
        var treesRight = grid[y].Skip(x + 1).Take(grid[y].Count - x);
        var visibleRight = !treesRight.Any(i => i >= tree);

        var treesTop = grid.Select(i => i[x]).Skip(0).Take(y);
        var visibleTop = !treesTop.Any(i => i >= tree);
        
        var treesBottom = grid.Select(i => i[x]).Skip(y + 1).Take(grid.Count - y);
        var visibleBottom = !treesBottom.Any(i => i >= tree);

        return visibleLeft || visibleRight || visibleTop || visibleBottom;
    }
}