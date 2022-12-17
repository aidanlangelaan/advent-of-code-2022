using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day14Tests
{
    private Day14 _day14;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "put test values here",
        };
        
        _day14 = new Day14(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn123()
    {
        // act
        var result = _day14.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day14.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}
