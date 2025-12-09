namespace _2025.Day4;

public static class Day4
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day4/Input.txt");
        var rows = input.Length;
        var cols = input[0].Length;
        
        var dirs = new[,]
        {
            {-1, -1}, {-1, 0}, {-1, 1},
            { 0, -1},          { 0, 1},
            { 1, -1}, { 1, 0}, { 1, 1}
        };
        
        //var result = Part1(input, cols, rows, dirs);
        var result = Part2(input, rows, cols, dirs);
        Console.WriteLine("Result: " + result);
    }

    private static int Part1(string[] input, int cols, int rows, int[,] dirs)
    {
        var accessible = 0;

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

        return accessible;
    }
    
    private static int Part2(string[] input, int cols, int rows, int[,] dirs)
    {
        
        var matrix = input.Select(line => line.ToCharArray()).ToArray();
        
        int accessible;
        var result = 0;
        var positionsToChange = new List<string>();
        
        do
        {
            accessible = 0;
            positionsToChange.Clear();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i][j] != '@')
                        continue;

                    var count = 0;

                    for (var d = 0; d < 8; d++)
                    {
                        var ni = i + dirs[d, 0];
                        var nj = j + dirs[d, 1];

                        if (ni < 0 || ni >= rows || nj < 0 || nj >= cols) continue;
                    
                        if (matrix[ni][nj] == '@')
                            count++;
                    }

                    if (count >= 4) continue;
                    accessible++;
                    positionsToChange.Add(i + "," + j);
                }
            }
            result += accessible;
            
            foreach (var pos in positionsToChange)
            {
                var parts = pos.Split(',');
                var i = int.Parse(parts[0]);
                var j = int.Parse(parts[1]);

                matrix[i][j] = '.';
            }
            
        } while (accessible >= 1);


        return result;
    }

}