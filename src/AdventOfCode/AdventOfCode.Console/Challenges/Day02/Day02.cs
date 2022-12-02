namespace AdventOfCode.Challenges;

public class Day02
{
    private readonly string[] _input;

    public Day02(string[] Input) => _input = Input;

    public int SolvePart1()
    {
        int round = 0,
            totalScore = 0;

        while (round < _input.Length)
        {
            var game = _input.Skip(round).Take(1).Select(x => x.Split(" ")).First();

            var shapeScore = GetShapeScore(game[1]);
            var playScore = GetPlayScore(game);
            totalScore += (shapeScore + playScore);

            round += 1;
        }

        return totalScore;
    }

    public int SolvePart2()
    {
        int round = 0,
            totalScore = 0;

        while (round < _input.Length)
        {
            var game = _input.Skip(round).Take(1).Select(x => x.Split(" ")).First();

            // figure out what shape to use
            var shapeToUse = GetShapeToUse(game);
            game[1] = shapeToUse;

            var shapeScore = GetShapeScore(game[1]);
            var playScore = GetPlayScore(game);
            totalScore += (shapeScore + playScore);

            round += 1;
        }

        return totalScore;
    }

    private static int GetShapeScore(string shape) => shape switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
    };

    private static int GetPlayScore(string[] game) => game[0] switch
    {
        "A" => game[1] switch
        {
            "X" => 3,
            "Y" => 6,
            "Z" => 0,
            _ => throw new ArgumentOutOfRangeException()
        },
        "B" => game[1] switch
        {
            "X" => 0,
            "Y" => 3,
            "Z" => 6,
            _ => throw new ArgumentOutOfRangeException()
        },
        "C" => game[1] switch
        {
            "X" => 6,
            "Y" => 0,
            "Z" => 3,
            _ => throw new ArgumentOutOfRangeException()
        },
        _ => 0
    };

    private string GetShapeToUse(string[] game) => game[0] switch
    {
        "A" => game[1] switch
        {
            "X" => "Z",
            "Y" => "X",
            "Z" => "Y",
            _ => throw new ArgumentOutOfRangeException()
        },
        "B" => game[1] switch
        {
            "X" => "X",
            "Y" => "Y",
            "Z" => "Z",
            _ => throw new ArgumentOutOfRangeException()
        },
        "C" => game[1] switch
        {
            "X" => "Y",
            "Y" => "Z",
            "Z" => "X",
            _ => throw new ArgumentOutOfRangeException()
        },
        _ => ""
    };
}