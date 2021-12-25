namespace Nine
{
    internal class RiskEvaluator
    {
        private readonly Map map;

        public RiskEvaluator(Map map) => this.map = map;

        public int SumRisks()
        {
            var lowPoints = map.GetLowPoints();
            var cumulativeRisk = lowPoints.Sum(h => 1 + h);

            return cumulativeRisk;
        }
    }
}
