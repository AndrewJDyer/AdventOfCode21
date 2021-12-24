namespace Eight.Lib
{
    internal class PotentialCharMappings
    {
        private static readonly IEnumerable<Segment> allSegments = Enum.GetValues<Segment>();

        private readonly Dictionary<char, List<Segment>> potentialMappings = GetInitialPotentialMappings();
        private readonly Dictionary<char, Segment> finalisedMappings = new();

        public IEnumerable<Segment> GetPossibleSegments(char c) => potentialMappings[c];

        public void RegisterFinalisedWord(Word word, Number number)
        {
            var possibilities = ReducePossibilities(word, number);
            var impossibleSegments = Enum.GetValues<Segment>().Except(possibilities.Segments);
            foreach (var c in possibilities.Chars)
                RemoveSegmentsFromChar(c, impossibleSegments);

            //now remove these segments from other chars
            foreach (var c in potentialMappings.Keys.Except(possibilities.Chars))
                RemoveSegmentsFromChar(c, possibilities.Segments);
        }

        public void RegisterWordPossibilities(Word word, IEnumerable<Number> possibleNumbers)
        {
            var possibilities = ReducePossibilities(word, possibleNumbers.SelectMany(x => x.Segments));
            foreach (var c in possibilities.Chars)
                RemoveSegmentsFromChar(c, Enum.GetValues<Segment>().Except(possibilities.Segments));
        }

        private (IEnumerable<char> Chars, IEnumerable<Segment> Segments) ReducePossibilities(Word word, Number number)
            => ReducePossibilities(word, number.Segments);

        private (IEnumerable<char> Chars, IEnumerable<Segment> Segments) ReducePossibilities(IEnumerable<char> chars, IEnumerable<Segment> segments)
        {
            var possibleChars = chars.ToList();
            var possibleSegments = segments.ToList();
            foreach (var finalisedMapping in finalisedMappings)
            {
                possibleChars.Remove(finalisedMapping.Key);
                possibleSegments.Remove(finalisedMapping.Value);
            }

            return (possibleChars, possibleSegments);
        }

        private void RemoveSegmentsFromChar(char c, IEnumerable<Segment> segmentsToRemove)
        {
            if (finalisedMappings.ContainsKey(c))
                return;

            var potentialSegments = potentialMappings[c];
            foreach (var segment in segmentsToRemove)
                potentialSegments.Remove(segment);

            if (potentialSegments.Count == 0)
                throw new InvalidOperationException("No segments left for character " + c);
            if (potentialMappings.Count == 1)
                finalisedMappings[c] = potentialSegments[0];

            foreach (var segment in Enum.GetValues<Segment>())
            {
                var possibleChars = potentialMappings.Keys.Where(c => potentialMappings[c].Contains(segment)).ToList();
                if (possibleChars.Count == 1)
                {
                    potentialMappings[possibleChars[0]] = new List<Segment> { segment };
                }

                if (possibleChars.Count == 0)
                    throw new InvalidOperationException("No chars for segment " + segment);
            }
        }

        public IEnumerable<Number> Filter(Word word, IEnumerable<Number> numbersToFilter)
            => numbersToFilter.Where(x => IsPossibleMapping(word, x));

        private bool IsPossibleMapping(Word word, Number number)
        {
            var possibilities = ReducePossibilities(word, number);
            return IsPossibleMapping(possibilities.Chars.ToList(), possibilities.Segments.ToList());
        }

        private bool IsPossibleMapping(IReadOnlyList<char> chars, IReadOnlyList<Segment> segments)
        {
            if (chars.Count > segments.Count)
                return false;

            if (chars.Count == 1)
                return potentialMappings[chars[0]].Any(segments.Contains);

            var reductionChar = chars[0];
            foreach (var segment in potentialMappings[reductionChar].Intersect(segments))
            {
                var reducedSegments = segments.ToList();
                reducedSegments.Remove(segment);
                if (IsPossibleMapping(chars.Skip(1).ToList(), reducedSegments))
                    return true;
            }

            return false;
        }

        private static Dictionary<char, List<Segment>> GetInitialPotentialMappings()
        {
            var mappings = new Dictionary<char, List<Segment>>();
            AddInitialCharOptions(mappings, 'a', 'b', 'c', 'd', 'e', 'f', 'g');

            return mappings;
        }

        private static void AddInitialCharOptions(Dictionary<char, List<Segment>> potentialMappings, params char[] chars)
        {
            foreach (char c in chars)
                AddInitialCharOptions(potentialMappings, c);
        }

        private static void AddInitialCharOptions(Dictionary<char, List<Segment>> potentialMappings, char c)
            => potentialMappings[c] = allSegments.ToList();
    }
}
