// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC 2015 Day 5");

var input = (await File.ReadAllLinesAsync("input.txt")).ToArray();

Console.WriteLine($"One: {PuzzleOne(input)}");
Console.WriteLine($"Two: {PuzzleTwo(input)}");

int PuzzleOne(string[] input)
{
    var nice = input.Where(line => line.IsNice());

    return nice.Count();
}

int PuzzleTwo(string[] input)
{
    var nice = input.Where(line => line.IsNice2());

    return nice.Count();
}

internal static class Extensions
{
    private static readonly string vowels = "aeiou";
    private static readonly string[] forbidden = { "ab", "cd", "pq", "xy" };

    public static bool IsNice(this string line)
    {
        bool consecutiveLetters = false;
        int foundVowels = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (vowels.Contains(line[i]))
                foundVowels++;

            if (i < line.Length - 1 && line[i] == line[i + 1])
                consecutiveLetters = true;

            if (i < line.Length - 1 && forbidden.Any(f => string.Compare(f, 0, line, i, 2) == 0))
                return false;
        }

        return consecutiveLetters && foundVowels >= 3;
    }

    public static bool IsNice2(this string line)
    {
        bool repeatingLetters = false;
        bool repeatingPair = false;

        for (int i = 0; i < line.Length - 2; i++)
        {
            if (line[i] == line[i + 2])
                repeatingLetters = true;

            string pair = line[i..(i + 2)];
            string before = line[..i];
            string after = line[(i + 2)..];

            if (before.Contains(pair) || after.Contains(pair))
                repeatingPair = true;
        }

        return repeatingLetters && repeatingPair;
    }
}