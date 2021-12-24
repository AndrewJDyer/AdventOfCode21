namespace Eight.Lib
{
    internal class PotentialWordMappings
    {
        private readonly Dictionary<Word, Number> finalisedMappings = new();
        private readonly PotentialCharMappings charMap = new();

        public Number GetValue(Word word)
        {
            if (finalisedMappings.TryGetValue(word, out var number))
                return number;

            var possibleVals = GetPossibleNumbers(word).ToList();
            return possibleVals.Count switch
            {
                1 => possibleVals[0],
                0 => throw new InvalidOperationException("No possible numbers for word " + word),
                _ => throw new InvalidOperationException("Too many possible numbers for word " + word)
            };
        }

        public void RegisterWord(Word word)
        {
            if (finalisedMappings.ContainsKey(word))
                return;

            var possibleNumbers = GetPossibleNumbers(word);
            RegisterWord(word, possibleNumbers);
        }

        private IEnumerable<Number> GetPossibleNumbers(Word word)
            => NarrowDownNumbersFromCharMap(word, word.PossibleNumbersByLength().Except(finalisedMappings.Values));

        private void RegisterWord(Word word, IEnumerable<Number> possibleNumbers)
        {
            var count = possibleNumbers.Count();
            if (count == 0)
                throw new InvalidOperationException("No possible numbers for word " + word);

            if (count == 1)
                RegisterFinalisedMapping(word, possibleNumbers.Single());
            else
                charMap.RegisterWordPossibilities(word, possibleNumbers);
        }

        private void RegisterFinalisedMapping(Word word, Number number)
        {
            finalisedMappings[word] = number;
            charMap.RegisterFinalisedWord(word, number);
        }

        private IEnumerable<Number> NarrowDownNumbersFromCharMap(Word word, IEnumerable<Number> initialPossibilities)
            => charMap.Filter(word, initialPossibilities);
    }
}
