using AdventOfCode.Challenges;

Console.WriteLine("--- Advent of Code 2022 ---\r\n");

Console.WriteLine("- Day 01 -");
var day01 = new Day01(File.ReadAllLines("Challenges\\Day01\\Input.txt"));
var day01Part1 = day01.SolvePart1();
Console.WriteLine($"part 1 result: {day01Part1}");
var day01Part2 = day01.SolvePart2();
Console.WriteLine($"part 2 result: {day01Part2}\r\n");

