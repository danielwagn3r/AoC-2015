// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC 2015 Day 2");

var input = (await File.ReadAllLinesAsync("input.txt")).ToArray();

Console.WriteLine($"One: {PuzzleOne(input)}");
Console.WriteLine($"Two: {PuzzleTwo(input)}");

int PuzzleOne(string[] input)
{
    return input.Select(l => l.Split('x'))
        .Select(t => new int[] { int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]) })
        .Select(dim => new int[] { dim[0] * dim[1], dim[0] * dim[2], dim[1] * dim[2] })
        .Sum(dim => 2 * dim.Sum() + dim.Min());
}

int PuzzleTwo(string[] input)
{
    return input.Select(l => l.Split('x'))
        .Select(t => new int[] { int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]) }.OrderBy(i => i))
        .Select(d => d.Take(2).Sum() + d.Take(2).Sum() + d.Aggregate((a, x) => a * x)).Sum();
}