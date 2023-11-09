
using static BirdCounter.BirdBase;

namespace BirdCounter
{
    public interface IBird
    {
        string SpeciesName { get; }
        
        void AddNumber(int number);

        void AddNumber(string number);

        void AddNumber (char number);

        Statistics GetStatistics();

        event ObservationAddedDelegate ObservationAdded;
    }
}
