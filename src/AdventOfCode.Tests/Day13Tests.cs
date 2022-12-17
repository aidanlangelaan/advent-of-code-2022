using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day13Tests
{
    private Day13 _day13;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "[1,1,3,1,1]",
            "[1,1,5,1,1]",
            "",
            "[[1],[2,3,4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };
        
        _day13 = new Day13(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn13()
    {
        // act
        var result = _day13.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn123()
    {
        // act
        var result = _day13.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(123));
    }
}
