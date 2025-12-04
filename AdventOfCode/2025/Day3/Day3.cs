namespace _2025.Day3;

public abstract class Day3
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day3/Input.txt");
        var result = 0;
        foreach (var line in input)
        {
            var password = FindPassword(line);
            result += password;
        }
        Console.WriteLine("Result: " + result);
    }

    private static int FindPassword(string line)
    {
        for (var i = 9; i > 0; i--)
        {
            var firstPosition = line.IndexOf(i.ToString(), StringComparison.Ordinal);
            if (firstPosition == -1) continue;
            
            var afterHigherNumber = line[(firstPosition+1)..];
            for (var j = 9; j > 0; j--)
            {
                var next = afterHigherNumber.IndexOf(j.ToString(), StringComparison.Ordinal);
                if (next == -1) continue;
                
                Console.WriteLine(i + "" + j);
                return int.Parse(i + "" + j);
            }
        }
        return 0;
    }
    
}