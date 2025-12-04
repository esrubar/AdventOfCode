namespace _2025.Day2;

public abstract class Day2
{
    public static void Solve(string[] input)
    {
        var inputList = new List<string>();
        foreach (var row in input)
        {
            var element = row
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            inputList.AddRange(element);
        }

        var result = 0L;
        foreach (var row in inputList)
        {
            var element = row
                .Split('-', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            for (var i = element[0]; i <  element[1] + 1; i++)
            {
                var a = AllSubstringsRepeatedTwice(i.ToString());
                if (!a) continue;
                
                Console.WriteLine(i);
                result += i;
            }
        }

        Console.WriteLine("Result: " + result);
    }

    private static bool AllSubstringsRepeatedTwice(string s)
    {
        if (s.Length % 2 != 0)
            return false;

        var half = s.Length / 2;

        var first = s[..half];
        var second = s.Substring(half, half);

        return first == second;
    }
}