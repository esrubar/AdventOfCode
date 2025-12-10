namespace _2025.Day7;

public static class Day7
{
    public static void Solve()
    {
        var input = File.ReadAllLines("Day7/Input.txt");

        var result = Part1(input);
        Console.WriteLine("Resultado: " + result);
    }

    private static long Part1(string[] input)
    {
        var positions = new List<(int row, int col)>();
        var position =
            input
                .SelectMany((line, row) =>
                    line.Select((ch, col) => new { row, col, ch }))
                .Where(x => x.ch == 'S')
                .Select(x => (x.row, x.col))
                .First();
        positions.Add(position);
        var result = 0L;

        for (var i = 0; i < positions.Count; i++)
        {
            var row = positions[i].row;
            var col = positions[i].col;
            
            if (row == input.Length - 1) break;
            
            var isEmpty = input[row + 1][col] != '^';
            if (isEmpty)
            {
                if (!positions.Contains((row + 1, col)))
                {
                    positions.Add((row + 1, col));
                }
            }
            else
            {
                result++;
                if (!positions.Contains((row + 1, col - 1)))
                {
                    positions.Add((row + 1, col - 1));
                }
                if (!positions.Contains((row + 1, col + 1)))
                {
                    positions.Add((row + 1, col + 1));
                }
            }
        }
        

        return result;
    }
}