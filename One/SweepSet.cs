namespace One
{
    class SweepSet
    {
        private readonly int firstReading;
        private readonly int secondReading;
        private readonly int thirdReading;

        public int Sum => firstReading + secondReading + thirdReading;

        public SweepSet(int firstReading, int secondReading, int thirdReading)
        {
            this.firstReading = firstReading;
            this.secondReading = secondReading;
            this.thirdReading = thirdReading;
        }
    }
}