using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day06Tests
{
    private Day06 _day06;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
        };
        
        _day06 = new Day06(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn7()
    {
        // act
        var result = _day06.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(7));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn19()
    {
        // act
        var result = _day06.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(19));
    }
}
