using BirdCounter;

Console.WriteLine("Welcome to BirdCounter application!");
Console.WriteLine("");

Console.WriteLine("Enter full Latin or polish species name:");
// tutaj event że plik istnieje lub nie, albo if i writteline albo Exception że nie istnieje i powstanie nowy.
var speciesNameReaded = Console.ReadLine();

Console.WriteLine("press T key to work with temporary data");
Console.WriteLine("press S key to get instant statistics of data stored in file");
Console.WriteLine("press U  key to create new set of data or update existing file");
// Jeśli podał T lub U to wyświetl: Console.WriteLine("pres Q key to quit and get statistics ");
Console.WriteLine("");

var input = Console.ReadLine();
if (input == "T" || input == "t")
{
    var bird = new BirdInMemory(speciesNameReaded);   
    while (true)
    {
        Console.WriteLine("Enter subsequent numbers of observed individuals:");
        var inputNumber = Console.ReadLine();
        if (inputNumber == "S")
        {
            break;
        }
        else
        {
            try
            {
                bird.AddNumber(inputNumber);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    var statistics = bird.GetStatistics();
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
    Console.WriteLine($"Sum: {statistics.Sum}");
    Console.WriteLine($"Avarage: {statistics.Avarage}");
    Console.WriteLine($"Number of input data: {statistics.Count}");

}
else
{
    var bird = new BirdInFile(speciesNameReaded);
    var statistics = bird.GetStatistics();
}






//var statistics = bird.GetStatistic();

//Console.WriteLine("Enter subsequent numbers of observed individuals:"); // or paste paste coma separated set of data
// event dodano do pliku lub dodano do pamięci

//Console.WriteLine("(Avarage number of birds counted by one observer)");
