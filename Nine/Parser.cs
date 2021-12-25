namespace Nine
{
    internal class Parser
    {
        private readonly string filename;

        public Parser(string filename) => this.filename = filename;

        public int[,] Parse()
        {
            var lines = File.ReadAllLines(filename).Where(l => !String.IsNullOrWhiteSpace(l)).ToArray();
            var width = lines.Max(x => x.Length);
            var length = lines.Length;
            var array = new int[width, length];
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < width; x++)
                    array[x, y] = int.Parse(lines[y][x].ToString());
            }

            return array;
        }
    }
}
