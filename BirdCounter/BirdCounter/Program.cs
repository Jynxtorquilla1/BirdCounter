using BirdCounter;

Console.WriteLine("Welcome to BirdCounter application!");
Console.WriteLine("");
Console.WriteLine("Enter full species name:");
// tutaj event że plik istnieje lub nie, albo if i writteline albo Exception że nie istnieje i powstanie nowy.
var speciesNameReaded = Console.ReadLine();
Console.WriteLine("press T key to work with temporary data");
Console.WriteLine("press S key to get instant statistics of data stored in file");
Console.WriteLine("press U  key to create new set of data or update existing file");
Console.WriteLine("press Q  key anytime, to to quit and get statistics");
// Jeśli podał T lub U to wyświetl: Console.WriteLine("pres Q key to quit and get statistics ");

var input = Console.ReadLine();
var inputUpper = input.ToUpper();

if (input == "T")
{
    BirdInMemory bird = NewBirdInMemory();
    NumberReader(bird);
}
if (input == "U")
{
    BirdInFile bird = NewBirdInFile();
    NumberReader(bird);
}


BirdInMemory NewBirdInMemory()
{
    var speciesName = speciesNameReaded;
    var bird = new BirdInMemory(speciesName);
    return bird;
}


BirdInFile NewBirdInFile()
{
    var speciesName = speciesNameReaded;
    var bird = new BirdInFile(speciesName);
    return bird;
}

static void NumberReader(IBird bird)
{
    while (true)
    {
        Console.WriteLine("Enter subsequent numbers of observed individuals:"); // event dodano do pliku lub dodano do pamięci
        var inputNumber = Console.ReadLine();
        var inputNumUpper = inputNumber.ToUpper();
        if (inputNumUpper == "S" || inputNumUpper == "Q")
        {
            break;
        }
        else
        {
            try
            {
                bird.AddNumber(inputNumUpper);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    PrintStatistics(bird);
}

static void PrintStatistics(IBird bird)
{
    var statistics = bird.GetStatistics();
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
    Console.WriteLine($"Sum: {statistics.Sum}");
    Console.WriteLine($"Avarage single observation: {statistics.Avarage}");
    Console.WriteLine($"Number of input data: {statistics.Count}");
}