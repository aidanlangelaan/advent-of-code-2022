using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day08Tests
{
    private Day08 _day08;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };
        
        _day08 = new Day08(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn21()
    {
        // act
        var result = _day08.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(21));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day08.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}
