using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day09Tests
{
    private Day09 _day09;
    
    [SetUp]
    public void Setup()
    {
        var testInputP1 = new[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2",
        };
        
        var testInputP2 = new[]
        {
            "R 5",
            "U 8",
            "L 8",
            "D 3",
            "R 17",
            "D 10",
            "L 25",
            "U 20",
        };
        
        _day09 = new Day09(testInputP1);
    }

    [Test]
    public void Example_Part1_ShouldReturn13()
    {
        // act
        var result = _day09.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn36()
    {
        // act
        var result = _day09.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(36));
    }
}
