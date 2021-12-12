// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("AoC 2015 Day 4");

var input = "ckczppom";

Console.WriteLine($"One: {PuzzleOne(input)}");
Console.WriteLine($"Two: {PuzzleTwo(input)}");

int PuzzleOne(string input)
{
    int i = 0;
    for (i = 0; ; i++)
    {
        string work = $"{input}{i}";
        string hash = ComputeMD5(work);
        Console.WriteLine($"{i}: {hash}");

        if (string.Compare(hash, 0, "00000", 0, 5) == 0)
            break;
    }

    return i;
}

int PuzzleTwo(string input)
{
    int i = 0;
    for (i = 0; ; i++)
    {
        string work = $"{input}{i}";
        string hash = ComputeMD5(work);
        Console.WriteLine($"{i}: {hash}");

        if (string.Compare(hash, 0, "000000", 0, 6) == 0)
            break;
    }

    return i;
}

string ComputeMD5(string input)
{
    // Use input string to calculate MD5 hash
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
}