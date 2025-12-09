namespace _2025.Day4;

public static class Day4
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day4/Input.txt");
        var rows = input.Length;
        var cols = input[0].Length;

        // Desplazamientos a las 8 direcciones
        var dirs = new[,]
        {
            {-1, -1}, {-1, 0}, {-1, 1},
            { 0, -1},          { 0, 1},
            { 1, -1}, { 1, 0}, { 1, 1}
        };

        int accessible = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (input[i][j] != '@')
                    continue;

                var count = 0;

                // Cuenta vecinos @
                for (var d = 0; d < 8; d++)
                {
                    var ni = i + dirs[d, 0];
                    var nj = j + dirs[d, 1];

                    if (ni < 0 || ni >= rows || nj < 0 || nj >= cols) continue;
                    if (input[ni][nj] == '@')
                        count++;
                }

                if (count < 4)
                    accessible++;
            }
        }

        Console.WriteLine("Result: " + accessible);
    }

}