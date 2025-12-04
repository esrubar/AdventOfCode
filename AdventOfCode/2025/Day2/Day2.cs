namespace _2025.Day2;

public abstract class Day2
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day2/Input.txt");
        // para que la linea de arriba funcione
        //btn derecho sobre el archivo --> properties--> editable --> build action: content --> copy to output directory: copy always
        
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
                var a = AllSubstringsRepeatedAtLeastTwice(i.ToString());
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
    
    private static bool AllSubstringsRepeatedAtLeastTwice(string s)
    {
        var n = s.Length;

        for (var len = 1; len <= n / 2; len++)
        {
            // La secuencia base debe encajar sin decimales
            if (n % len != 0)
                continue;

            var seq = s[..len];

            // Construir el posible string repetido para comprobar si es igual
            var repeats = n / len;
            var optionBuild = string.Concat(Enumerable.Repeat(seq, repeats));

            if (optionBuild == s)
                return true;
        }

        return false;
    }
}