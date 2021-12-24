using System.Collections;

namespace Eight.Lib
{
    internal class Word : IEquatable<Word>, IEnumerable<char>
    {
        private readonly string text;

        public Word(string text) => this.text = text;

        public IEnumerable<Number> PossibleNumbersByLength() => Number.All.Where(x => x.Segments.Length == text.Length);

        public bool Equals(Word? other) => other is not null && new HashSet<char>(text).SetEquals(other.text);

        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var c in text)
                hash.Add(c);

            return hash.ToHashCode();
        }

        public override bool Equals(object? obj) => Equals(obj as Word);

        public override string ToString() => text;

        public IEnumerator<char> GetEnumerator() => ((IEnumerable<char>)text).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)text).GetEnumerator();
    }
}
