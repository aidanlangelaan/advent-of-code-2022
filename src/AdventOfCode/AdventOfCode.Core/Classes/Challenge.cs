namespace AdventOfCode.Core;

public abstract class Challenge<TDay>
{
    protected string[] _input;

    protected Challenge(string[] Input) => _input = Input;

    protected Challenge()
    {
        _input = File.ReadAllLines($"Challenges\\{typeof(TDay).Name}\\Input.txt");
    }

    public abstract int SolvePart1();
    public abstract int SolvePart2();
}