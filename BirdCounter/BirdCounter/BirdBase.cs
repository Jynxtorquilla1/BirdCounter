namespace BirdCounter
{
    public abstract class BirdBase : IBird
    {
        public delegate void GroupObservationDelegate(object sender, EventArgs args);

        public event GroupObservationDelegate GroupObservationEvent;

        public BirdBase(string speciesName)
        {
            this.SpeciesName = speciesName;
        }

        public string SpeciesName { get; private set; }

        public abstract void AddNumber(int number);


        public void AddNumber(string number)
        {
            if (int.TryParse(number, out int result))
            {
                AddNumber(result);
            }
            else if (char.TryParse(number, out char charResult))
            {
                AddNumber(charResult);
            }
            else
            {
                throw new Exception("Incorrect input");
            }
        }

        public void AddNumber(char number)
        {
            switch (number)
            {
                case 'i':
                case 'I':
                    AddNumber(60);
                    break;
                case 'h':
                case 'H':
                    AddNumber(85);
                    break;
                case 'g':
                case 'G':
                    AddNumber(125);
                    break;
                case 'f':
                case 'F':
                    AddNumber(175);
                    break;
                case 'e':
                case 'E':
                    AddNumber(250);
                    break;
                case 'd':
                case 'D':
                    AddNumber(350);
                    break;
                case 'c':
                case 'C':
                    AddNumber(450);
                    break;
                case 'b':
                case 'B':
                    AddNumber(600);
                    break;
                case 'a':
                case 'A':
                    AddNumber(850);
                    break;
                default: throw new Exception("Incorrect letter");

            }
            if (GroupObservationEvent is not null)
            {
                GroupObservationEvent(this, new EventArgs());
            }
        }

        public abstract Statistics GetStatistics();

    }
}
