namespace Eleven;

internal class Parser
{
    private readonly string path;

    public Parser(string path) => this.path = path;

    public int[,] Parse()
    {
        var lines = File.ReadAllLines(path).Where(l => l != "").ToList();
        var width = lines.Max(l => l.Length);
        var length = lines.Count;
        var array = new int[width, length];
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
                array[x, y] = int.Parse(lines[y][x].ToString());
        }

        return array;
    }
}
