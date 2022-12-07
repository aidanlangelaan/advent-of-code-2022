using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day05Tests
{
    private Day05 _day05;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "put test values here",
        };
        
        _day05 = new Day05(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn0()
    {
        // act
        var result = _day05.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(0));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn0()
    {
        // act
        var result = _day05.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(0));
    }
}
