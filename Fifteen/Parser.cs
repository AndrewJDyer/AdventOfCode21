namespace Fifteen;

internal class Parser
{
    private readonly string path;

    public Parser(string path) => this.path = path;

    public int[,] Parse()
    {
        var lines = File.ReadAllLines(path);
        var height = lines.Length;
        var width = lines.Max(x => x.Length);

        return GetArray(lines, height, width);
    }

    private static int[,] GetArray(string[] lines, int height, int width)
    {
        var array = new int[width, height];
        for (int y = 0; y < height; y++)
        {
            if (lines[y] is not string line)
                continue;

            for (int x = 0; x < width; x++)
                array[x, y] = int.Parse(line[x].ToString());
        }

        return array;
    }
}
