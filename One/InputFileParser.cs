using System.Collections.Generic;
using System.IO;

namespace One
{

    class InputFileParser
    {
        private readonly string path;

        public InputFileParser(string path) => this.path = path;

        public IEnumerable<SweepSet> ParseSets()
        {
            var lines = ReadLines();
            return GetSets(lines);
        }

        private IReadOnlyList<string> ReadLines() => File.ReadAllLines(path);

        private IEnumerable<SweepSet> GetSets(IReadOnlyList<string> lines)
        {
            int i = 0;
            while (GetSet(lines, i++) is SweepSet set)
                yield return set;
        }

        private SweepSet? GetSet(IReadOnlyList<string> lines, int startingIndex)
        {
            if (TryParseDepth(lines, startingIndex, out var firstDepth)
                && TryParseDepth(lines, startingIndex + 1, out var secondDepth)
                && TryParseDepth(lines, startingIndex + 2, out var thirdDepth))
                return new SweepSet(firstDepth, secondDepth, thirdDepth);

            return null;
        }

        private static bool TryParseDepth(IReadOnlyList<string> lines, int index, out int depth)
        {
            depth = 0;
            if (index < 0 || lines.Count <= index)
                return false;

            return int.TryParse(lines[index], out depth);
        }
    }
}