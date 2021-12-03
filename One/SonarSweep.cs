using System.Collections.Generic;

namespace One
{
    class SonarSweep
    {
        private readonly IEnumerator<SweepSet> depthsEnumerator;

        private SweepSet? currentSet;
        private int numberOfIncreases;

        public SonarSweep(IEnumerable<SweepSet> depths) => depthsEnumerator = depths.GetEnumerator();

        public int CountIncreases()
        {
            while (depthsEnumerator.MoveNext())
                CheckCurrentDepth();

            return numberOfIncreases;
        }

        private void CheckCurrentDepth()
        {
            if (currentSet is SweepSet set && set.Sum < depthsEnumerator.Current.Sum)
                numberOfIncreases++;

            currentSet = depthsEnumerator.Current;
        }
    }
}
