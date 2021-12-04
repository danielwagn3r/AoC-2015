// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC 2015 Day 1");

var input = (await File.ReadAllLinesAsync("input.txt")).ToArray();

var steps = input[0].Select(c => c == ')' ? -1 : 1);

Console.WriteLine($"One: {PuzzleOne(steps)}");
Console.WriteLine($"Two: {PuzzleTwo(steps)}");

int PuzzleOne(IEnumerable<int> input)
{

    return input.Sum();
}

int PuzzleTwo(IEnumerable<int> input)
{
    int floor = 0;

    return input.Select((c, i) => new { Floor = floor += c, Index = i + 1 }).Where(s => s.Floor == -1).First().Index;
}