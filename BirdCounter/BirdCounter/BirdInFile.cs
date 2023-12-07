namespace BirdCounter
{
    public class BirdInFile : BirdBase
    {
        private string fileName;

        public BirdInFile(string speciesName) : base(speciesName)
        {
            fileName = $"{speciesName}.txt";

            while (!File.Exists($"{speciesName}.txt"))
            {
                using (var writer = new StreamWriter(fileName, true))
                {
                    if (File.Exists($"{speciesName}.txt"))
                    {
                        Console.WriteLine("New file has been created");
                    }
                    else
                    {
                        throw new Exception("File has not been created because of unknown error. Try again");
                    }
                }
            }

        }

        public override void AddNumber(int number)
        {
            if (number >= 1)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(number);
                }
            }
            else
            {
                throw new Exception("incorrect value");
            }
        }      

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if (File.Exists(fileName))
            {

                using (var reader = File.OpenText(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == string.Empty) continue;

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