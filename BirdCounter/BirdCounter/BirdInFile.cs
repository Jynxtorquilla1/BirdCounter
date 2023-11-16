using System.Reflection.Metadata.Ecma335;

namespace BirdCounter
{
    internal class BirdInFile : BirdBase
    {
        private string fileName;

        //public override event FileCreatedDelegate FileCreatedEvent;
        //public  delegate void FileCreatedDelegate(string message);

        public BirdInFile(string speciesName) : base(speciesName)
        {
            fileName = $"{speciesName}.txt";

            while (!File.Exists($"{speciesName}.txt"))
            {
                using (var writer = new StreamWriter(fileName, true))
                {
                    //FileCreatedEvent += FileCreated;
                    //FileCreatedEvent?.Invoke(this, new EventArgs());
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

        //void FileCreated(object sender, EventArgs args)
        //{
        //    Console.WriteLine("new file has been created");
        //}        

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