namespace _2025.Day6;

public static class Day6
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day6/Input.txt");

        var result = Part1(input);
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
}