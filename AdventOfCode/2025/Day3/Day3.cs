namespace _2025.Day3;

public abstract class Day3
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day3/Input.txt");
        var result = 0L;
        foreach (var line in input)
        {
            var password = long.Parse(FindPasswordWith12Elements(line));
            Console.WriteLine(password);
            result += password;
        }
        Console.WriteLine("Result: " + result);
    }

    // Parte 1
    private static int FindPasswordWith2Elements(string line)
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
    
    // Parte 2
    private static string FindPasswordWith12Elements(string line, int maxLenght = 12)
    {
        var stack = new Stack<char>();
        var toRemove = line.Length - maxLenght;

        foreach (var c in line)
        {
            /*
             * Peek() --> Devuelve el elemento de arriba sin quitarlo
             * Pop() --> Quita y devuelve el elemento de arriba
             * Push() --> Añade un elemento arriba
             */
            while (stack.Count > 0 && stack.Peek() < c && toRemove > 0)
            {
                stack.Pop();
                toRemove--;
            }
            stack.Push(c);
        }

        // Si sobran elementos por eliminar
        while (toRemove > 0)
        {
            stack.Pop();
            toRemove--;
        }

        var arr = stack.ToArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}