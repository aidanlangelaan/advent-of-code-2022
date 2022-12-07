using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 07")]
public class Day07 : Challenge<Day07>
{
    public Day07(string[] input) : base(input)
    {
    }

    public Day07() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var directories = GetSizePerDirectory();
        var totalSize = directories
            .Select(path => directories
                .Where(x => x.Item1.StartsWith(path.Item1, StringComparison.Ordinal))
                .Sum(x => x.Item2))
            .Where(size => size <= 100000)
            .Aggregate(0, (current, size) => (int)(current + size));

        Console.WriteLine($"P1: {totalSize}");
        return 0;
    }

    public override int SolvePart2()
    {
        var directories = GetSizePerDirectory();
        var totalSizes = directories
            .Select(path => directories
                .Where(x => x.Item1.StartsWith(path.Item1, StringComparison.Ordinal))
                .Sum(x => x.Item2));

        var remainingDiscSpace = 70000000 - totalSizes.OrderDescending().First();
        var sizeToRemove = totalSizes.Where(x => x >= 30000000 - remainingDiscSpace).Order().First();
        
        Console.WriteLine($"P2: {sizeToRemove}");
        return 0;
    }

    private IEnumerable<(string, long)> GetSizePerDirectory()
    {
        var paths = new List<(string, long)> { ("\\", 0) };
        var path = "\\";
        for (var i = 1; i < _input.Length; i++)
        {
            var line = _input[i];
            if (!line.StartsWith("$")) continue;
            var commandLine = line.Split(" ");
            
            switch (commandLine[1])
            {
                case "cd":
                    var directory = commandLine[2];
                    if (directory == "..")
                    {
                        path = path.Remove(path.LastIndexOf("\\", StringComparison.Ordinal));
                        if (string.IsNullOrWhiteSpace(path))
                        {
                            path = "\\";
                        }
                    }
                    else
                    {
                        path = Path.Combine(path, directory);
                        if (!paths.Exists(x => x.Item1 == path))
                        {
                            paths.Add((path, 0));                            
                        }
                    }

                    break;
                case "ls":
                    var size = GetDirectorySize(i + 1);
                    var pathIndex = paths.FindIndex(x => x.Item1 == path);

                    paths[pathIndex] = (path, size);
                    break;
            }
        }
        return paths;
    }

    private long GetDirectorySize(int startIndex)
    {
        long totalFileSize = default;
        for (var i = startIndex; i < _input.Length; i++)
        {
            var line = _input[i];
            if (line.StartsWith("$"))
            {
                break;
            }
            
            if (line.StartsWith("dir")) continue;
            var fileLine = line.Split(" ");
            totalFileSize += long.Parse(fileLine[0]);
        }
        return totalFileSize;
    }
}
