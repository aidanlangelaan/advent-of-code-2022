using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day02Tests
{
    private Day02 _day02;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "A Y", "B X", "C Z"
        };
        
        _day02 = new Day02(testInput);
    }

    [Test]
    public void Example_Part1_ShoudReturn15()
    {
        // act
        var result = _day02.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(15));
    }
    
    [Test]
    public void Example_Part2_ShoudReturn45000()
    {
        // act
        var result = _day02.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(45000));
    }
}