namespace _2025.Day5;

public static class Day5
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day5/Input.txt");

        var result = CountFreshIngredientIds(input);
        Console.WriteLine("Resultado: " + result);
    }
    
    // Part 1
    private static long CountFreshIngredientIds(string[] input)
    {
        var empty = Array.IndexOf(input, "");

        var ranges = input
            .Take(empty)
            .Select(r =>
            {
                var v = r.Split('-').Select(long.Parse).ToArray();
                return (Min: v.Min(), Max: v.Max());
            })
            .ToList();

        return input
            .Skip(empty + 1)
            .Select(long.Parse)
            .Count(id => ranges.Any(r => id >= r.Min && id <= r.Max));
    }

}