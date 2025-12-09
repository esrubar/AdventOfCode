namespace _2025.Day5;

public static class Day5
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day5/Input.txt");

        var result = CountFreshIngredientsInRange(input);
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

    // Part 2
    private static long CountFreshIngredientsInRange(string[] input)
    {
        var empty = Array.IndexOf(input, "");

        // Parseamos los rangos
        var ranges = input
            .Take(empty)
            .Select(r =>
            {
                var v = r.Split('-').Select(long.Parse).ToArray();
                return (Min: v.Min(), Max: v.Max());
            })
            .OrderBy(r => r.Min) // Ordenamos por inicio para fusionar
            .ToList();

        long total = 0;

        var currentMin = ranges[0].Min;
        var currentMax = ranges[0].Max;

        foreach (var (min, max) in ranges.Skip(1))
        {
            if (min <= currentMax + 1)
            {
                // Solapan → extendemos el rango
                currentMax = Math.Max(currentMax, max);
            }
            else
            {
                // No solapan → sumamos rango anterior
                total += currentMax - currentMin + 1;

                // Nuevo rango
                currentMin = min;
                currentMax = max;
            }
        }

        // Sumamos el último rango
        total += currentMax - currentMin + 1;

        return total;
    }

}