using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day01Tests
{
    private Day01 _day01;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "1000", "2000", "3000", "", "4000", "", "5000", "6000", "", "7000", "8000", "9000", "", "10000"
        };
        
        _day01 = new Day01(testInput);
    }

    [Test]
    public void Example_Part1_ShoudReturn24000()
    {
        // act
        var result = _day01.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(24000));
    }
    
    [Test]
    public void Example_Part2_ShoudReturn45000()
    {
        // act
        var result = _day01.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(45000));
    }
}