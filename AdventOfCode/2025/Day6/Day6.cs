namespace _2025.Day6;

public static class Day6
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day6/Input.txt");

        var result = Part3(input);
        Console.WriteLine("Resultado: " + result);
    }

    private static long Part1(string[] input)
    {
        var matrix = input.Select(r => r.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var finalResult = 0L;

        for (var c = 0; c < cols; c++)
        {
            var result = 0L;
            var operation = matrix[rows - 1][c];

            for (var r = 0; r < rows - 1; r++)
            {
                switch (operation)
                {
                    case "+":
                        result += long.Parse(matrix[r][c]);
                        break;
                    case "*":
                        var element = long.Parse(matrix[r][c]);
                        if (result == 0) result = 1;
                        result *= element;
                        break;
                }
            }

            finalResult += result;
        }

        return finalResult;
    }

    private static long Part3(string[] lines)
    {
        var rows = lines.Length;
        var cols = lines.Max(l => l.Length);

        Console.WriteLine("Hola".PadRight(6, '.'));

        // PadRight para que todas las líneas tengan el mismo ancho
        for (var r = 0; r < rows; r++)
        {
            lines[r] = lines[r].PadRight(cols);
        }

        long grandTotal = 0;
        var currentNumbers = new List<long>();
        var currentOp = '+'; // default

        for (var c = 0; c < cols; c++)
        {
            // Comprueba si columna vacía
            var allSpaces = true;
            for (var r = 0; r < rows - 1; r++) // fila de operadores no cuenta
            {
                if (lines[r][c] == ' ') continue;
                allSpaces = false;
                break;
            }

            if (allSpaces)
            {
                if (currentNumbers.Count <= 0) continue;
                var value = (currentOp == '*')
                    ? currentNumbers.Aggregate(1L, (a, b) => a * b)
                    : currentNumbers.Sum();

                grandTotal += value;
                currentNumbers.Clear();
            }
            else
            {
                // Reconstruir número vertical de arriba a abajo
                var numStr = "";
                for (var r = 0; r < rows - 1; r++)
                {
                    var ch = lines[r][c];
                    if (char.IsDigit(ch))
                        numStr += ch;
                }

                if (numStr.Length > 0)
                    currentNumbers.Add(long.Parse(numStr));

                // Leer operador en la fila final
                var opChar = lines[rows - 1][c];
                if (opChar is '+' or '*')
                    currentOp = opChar;
            }
        }

        // Procesar cualquier número pendiente al final
        if (currentNumbers.Count <= 0) return grandTotal;

        var value2 = (currentOp == '*')
            ? currentNumbers.Aggregate(1L, (a, b) => a * b)
            : currentNumbers.Sum();
        grandTotal += value2;


        return grandTotal;
    }
}