using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day04Tests
{
    private Day04 _day04;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };
        
        _day04 = new Day04(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn2()
    {
        // act
        var result = _day04.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Example_Part2_ShoudReturn70()
    {
        // act
        var result = _day04.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(70));
    }
}