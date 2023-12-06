namespace BirdCounter
{
    public class BirdInMemory : BirdBase
    {

        public BirdInMemory(string speciesName) : base(speciesName)
        {
        }

        private List<int> birdNumbers = new();

        public override void AddNumber(int number)
        {
            if (number >= 1)
            {
                birdNumbers.Add(number);
            }
            else
            {
                throw new Exception("incorrect value");
            }
        }             

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var number in birdNumbers)
            {
                statistics.CalculateStatistics(number);
            }
            return statistics;
        }
    }
}
