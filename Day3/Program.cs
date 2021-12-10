// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC 2015 Day 3");

var input = (await File.ReadAllLinesAsync("input.txt")).First();

Dictionary<char, Tuple<int, int>> map = new()
{
    { '^', new Tuple<int, int>(0, 1) },
    { 'v', new Tuple<int, int>(0, -1) },
    { '<', new Tuple<int, int>(1, 0) },
    { '>', new Tuple<int, int>(-1, 0) }
};

//var input = ">";
//var input = "^>v<";
//var input = "^v^v^v^v^v";

Console.WriteLine($"One: {PuzzleOne(input)}");
Console.WriteLine($"Two: {PuzzleTwo(input)}");

int PuzzleOne(string input)
{
    List<Tuple<int, int>> visited = new();
    Tuple<int, int> position = new(0, 0);

    visited.Add(position);

    foreach (var c in input)
    {
        position = new Tuple<int, int>(position.Item1 + map[c].Item1, position.Item2 + map[c].Item2);
        visited.Add(position);
    }

    return visited.Distinct().Count();
}

int PuzzleTwo(string input)
{
    return 0;
}