using System.Text.RegularExpressions;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC 2015 Day 6");

var input = (await File.ReadAllLinesAsync("input.txt")).ToArray();

Console.WriteLine($"One: {PuzzleOne(input)}");
Console.WriteLine($"Two: {PuzzleTwo(input)}");

int PuzzleOne(string[] input)
{
    var instructions = ParseInput(input);

    bool[,] lights = new bool[1000, 1000];

    foreach (var instruction in instructions)
    {
        ApplyInstruction(lights, instruction);
    }

    var (maxX, maxY) = (lights.GetLength(0), lights.GetLength(1));

    int onLights = 0;
    for (int x = 0; x < maxX; x++)
        for (int y = 0; y < maxY; y++)
            if (lights[x, y]) onLights++;

    return onLights;
}

long PuzzleTwo(string[] input)
{
    var instructions = ParseInput(input);

    int[,] lights = new int[1000, 1000];

    foreach (var instruction in instructions)
    {
        ApplyInstruction2(lights, instruction);
    }

    var (maxX, maxY) = (lights.GetLength(0), lights.GetLength(1));

    long brightness = 0;
    for (int x = 0; x < maxX; x++)
        for (int y = 0; y < maxY; y++)
            brightness += lights[x, y];

    return brightness;
}

void ApplyInstruction(bool[,] lights, Instruction i)
{
    for (int x = i.A.X; x <= i.B.X; x++)
        for (int y = i.A.Y; y <= i.B.Y; y++)
        {
            switch (i.Command)
            {
                case "turn on":
                    lights[x, y] = true;
                    break;

                case "toggle":
                    lights[x, y] = !lights[x, y];
                    break;

                case "turn off":
                    lights[x, y] = false;
                    break;

                default:
                    throw new ArgumentException($"Command {i.Command} not expected.");
            }
        }
}

void ApplyInstruction2(int[,] lights, Instruction i)
{
    for (int x = i.A.X; x <= i.B.X; x++)
        for (int y = i.A.Y; y <= i.B.Y; y++)
        {
            switch (i.Command)
            {
                case "turn on":
                    lights[x, y]++;
                    break;

                case "toggle":
                    lights[x, y] += 2;
                    break;

                case "turn off":
                    lights[x, y] = Math.Max(0, lights[x, y] - 1);
                    break;

                default:
                    throw new ArgumentException($"Command {i.Command} not expected.");
            }
        }
}

IList<Instruction> ParseInput(string[] input)
{
    var regex = new Regex(@"^(?<command>[a-z ]+)(?<xa>[0-9]+),(?<ya>[0-9]+)([a-z ])+(?<xb>[0-9]+),(?<yb>[0-9]+)$", RegexOptions.ExplicitCapture, TimeSpan.FromMilliseconds(150));

    List<Instruction> instructions = new();

    foreach (var line in input)
    {
        var match = regex.Match(line);

        var instruction = new Instruction
        {
            Command = match.Groups["command"].Value.Trim(),
            A = new Point(int.Parse(match.Groups["xa"].Value), int.Parse(match.Groups["ya"].Value)),
            B = new Point(int.Parse(match.Groups["xb"].Value), int.Parse(match.Groups["yb"].Value))
        };

        instructions.Add(instruction);
    }

    return instructions;
}

internal class Instruction
{
    public string Command { get; set; }

    public Point A { get; set; }
    public Point B { get; set; }
}

public class Point : IEquatable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        if (obj is not Point point)
            throw new ArgumentException("Object is not a Point.");

        return this.X == point.X && this.Y == point.Y;
    }

    public override int GetHashCode()
    {
        int hashX = X.GetHashCode();

        int hashY = Y.GetHashCode();

        return hashX ^ hashY;
    }

    public bool Equals(Point obj)
    {
        if (obj == null)
            return false;

        return this.X == obj.X && this.Y == obj.Y;
    }
}