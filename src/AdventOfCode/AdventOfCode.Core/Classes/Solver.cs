namespace AdventOfCode.Core;

public class Solver<TDay> where TDay : Challenge<TDay>
{
    private readonly TDay _day;

    public Solver()
    {
        _day = Activator.CreateInstance<TDay>();
        if (_day == null)
        {
            throw new Exception("Instance not found");
        }
    }

    public void SolveDayPart1()
    {
        var result = _day.SolvePart1();
        Console.WriteLine($"part 1 result: {result}");
    }
    
    public void SolveDayPart2()
    {
        var result = _day.SolvePart2();
        Console.WriteLine($"part 2 result: {result}\r\n");
    }
}