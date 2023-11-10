
using static BirdCounter.BirdBase;
using static BirdCounter.BirdInFile;

namespace BirdCounter
{
    public interface IBird
    {
        string SpeciesName { get; }
        
        void AddNumber(int number);

        void AddNumber(string number);

        void AddNumber (char number);

        Statistics GetStatistics();

        event GroupObservationDelegate GroupObservationEvent;

        event FileCreatedDelegate FileCreatedEvent;

    }
}
