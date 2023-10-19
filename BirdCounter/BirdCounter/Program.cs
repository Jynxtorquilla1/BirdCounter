using BirdCounter;

Console.WriteLine("Welcome to BirdCounter application!");
Console.WriteLine("");
Console.WriteLine("Enter full species name:");

string speciesName;
ReadSpeciesName(out speciesName);
//ReadSpeciesName();
//var speciesNameReaded = Console.ReadLine();
PrintMenu();


var input = Console.ReadLine();
var inputUpper = input.ToUpper();

while (true)
{
    if (inputUpper == "T")
    {
        BirdInMemory bird = NewBirdInMemory();
        NumberReader(bird);
        PrintStatistics(bird);
    }
    else if (inputUpper == "U")
    {
        BirdInFile bird = NewBirdInFile();
        NumberReader(bird);
        PrintStatistics(bird);
    }
    else if (inputUpper == "S" || inputUpper == "Q")
    {
        BirdInFile bird = NewBirdInFile();
        PrintStatistics(bird);
        break;
    }
    else if (inputUpper == "N")
    {
        ReadSpeciesName(out speciesName);
    }
    else
    {        
        Console.WriteLine("Incorrect value - chose key from menu"); // poprawić na jakiś wyjątek 
        break;
    }
}

static void PrintMenu()
{
    Console.WriteLine("press T key to work with temporary data");
    Console.WriteLine("press S key to get instant statistics of data stored in file");
    Console.WriteLine("press U  key to create new set of data or update existing file");
    Console.WriteLine("press Q  key anytime, to to quit and get statistics");
}

static void ReadSpeciesName(out string speciesName)
{
    speciesName = Console.ReadLine();
}

BirdInMemory NewBirdInMemory()
{
    //string speciesNameReaded = ReadSpeciesName();
    var bird = new BirdInMemory(speciesName);
    return bird;
}

BirdInFile NewBirdInFile()
{
    //string speciesNameReaded = ReadSpeciesName();
    var speciesNameLower = speciesName.ToLower();
    var bird = new BirdInFile(speciesNameLower);
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
            PrintStatistics(bird);
            break;
        }
        else
        {
            try
            {
                bird.AddNumber(inputNumUpper); // albo break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
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

//if fileExists dla nazwy/ event że plik istnieje 

// "N" -> program od nowa
// walidacja do liter z mentu + wyjątek
// tworzenie update i otwieranie pliku z nazwami
// zakresy dla liter - podgląd w konsoli
