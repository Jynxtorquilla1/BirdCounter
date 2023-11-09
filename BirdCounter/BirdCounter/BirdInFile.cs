namespace BirdCounter
{
    internal class BirdInFile : BirdBase
    {
        private string fileName;

        public override event ObservationAddedDelegate ObservationAdded;

        public BirdInFile(string speciesName) : base(speciesName)
        {
            fileName = $"{speciesName}.txt";            
        }

        
        public override void AddNumber(int number)
        {
            if (number >= 1)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(number);
                }
                if (ObservationAdded is not null)
                {
                    ObservationAdded(this, new EventArgs());
                }
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
            if (File.Exists(fileName))
            {
                                
                using( var reader = File.OpenText(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line == string.Empty) continue;

                        if (int.TryParse(line, out int number))
                        {
                            statistics.CalculateStatistics(number);
                        }
                        else
                        {
                            throw new Exception("file contains invalid data");
                        } 
                            
                    }
                }
                
            }

            return statistics;
        }
    }
}
