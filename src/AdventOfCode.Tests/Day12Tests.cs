using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day12Tests
{
    private Day12 _day12;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi",
        };
        
        _day12 = new Day12(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn31()
    {
        // act
        var result = _day12.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(31));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn0()
    {
        // act
        var result = _day12.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(0));
    }
}
