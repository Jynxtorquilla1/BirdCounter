namespace BirdCounter
{
    internal class BirdInMemory : BirdBase
    {

        public override event FileCreatedDelegate FileCreatedEvent;
        public BirdInMemory(string speciesName) : base(speciesName)
        {
        }

        private List<int> birdNumbers = new List<int>();

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

        public override void AddNumber(string number)
        {
            base.AddNumber(number);
        }

        public override void AddNumber(char number)
        {
            base.AddNumber(number);
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
