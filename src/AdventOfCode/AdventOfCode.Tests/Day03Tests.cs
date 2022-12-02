using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day03Tests
{
    private Day03 _day03;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "A Y", "B X", "C Z"
        };
        
        _day03 = new Day03(testInput);
    }

    [Test]
    public void Example_Part1_ShoudReturn15()
    {
        // act
        var result = _day03.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(15));
    }
    
    [Test]
    public void Example_Part2_ShoudReturn12()
    {
        // act
        var result = _day03.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(12));
    }
}