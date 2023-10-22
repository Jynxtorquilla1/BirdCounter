using BirdCounter;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Welcome to BirdCounter application!");
Console.WriteLine("");

Starter();

//public delegate void StarterDelegate();

void Starter()
{    
    string speciesName = "";
    RunProgram(speciesName);
}

void RunProgram(string speciesName)
{
    while (true)
    {
        Console.WriteLine("Enter full species name:");       
        ReadSpeciesName(out speciesName);
        PrintMenu();

        var input = Console.ReadLine();
        var inputUpper = input.ToUpper();

        if (inputUpper == "T")
        {

            BirdInMemory bird = NewBirdInMemory(speciesName);
            NumberReader(bird, speciesName);
            PrintStatistics(bird);
            ContinueDecision();            
        }
        else if (inputUpper == "U")
        {
            BirdInFile bird = NewBirdInFile(speciesName);
            NumberReader(bird, speciesName);
            PrintStatistics(bird);
            ContinueDecision();
        }
        else if (inputUpper == "S" || inputUpper == "Q")
        {
            BirdInFile bird = NewBirdInFile(speciesName);
            PrintStatistics(bird);
            break;
        }
        else if (inputUpper == "N")
        {            
            continue;
        }
        else
        {
            Console.WriteLine("Incorrect value - chose key from menu"); // poprawić na jakiś wyjątek 
            break;
        }
    }
}

void ContinueDecision()
{
    Console.WriteLine("===============================================");
    Console.WriteLine("Do you want to continue your work? Tap Y for Yes or N for No");
    Console.WriteLine("If you chose Y previus data will be deleted");
    Console.WriteLine("===============================================");

    var answer = Console.ReadLine();
    var answerUpper = answer.ToUpper();
    if (answerUpper == "Y")
    {        
        Console.Clear();
        Console.WriteLine("BirdCounter new sesion");
        Starter();
    }
    else
    {
        Environment.Exit(0);
    }
}

static void PrintMenu()
{
    Console.WriteLine("press T key to work with temporary data");
    Console.WriteLine("press S key to get instant statistics of data stored in file");
    Console.WriteLine("press U key to create new set of data or update existing file");
    Console.WriteLine("press Q key anytime, to to quit and get statistics");
    Console.WriteLine("press N to start working with next species data");
}

static void ReadSpeciesName(out string speciesName)
{
    speciesName = Console.ReadLine();
}

BirdInMemory NewBirdInMemory(string speciesName)
{
    //string speciesNameReaded = ReadSpeciesName();
    var bird = new BirdInMemory(speciesName);
    return bird;
}

BirdInFile NewBirdInFile(string speciesName)
{
    //string speciesNameReaded = ReadSpeciesName();
    var speciesNameLower = speciesName.ToLower();
    var bird = new BirdInFile(speciesNameLower);
    return bird;
}

void NumberReader(IBird bird, string speciesName)
{
    while (true)
    {
        Console.WriteLine("Enter subsequent numbers of observed individuals:"); // event - dodano do pliku lub dodano do pamięci
        var inputNumber = Console.ReadLine();
        var inputNumUpper = inputNumber.ToUpper();
        if (inputNumUpper == "S" || inputNumUpper == "Q")
        {            
            break;
        }
        else if (inputNumUpper == "N")
        {
            Console.Clear();
            Starter();
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
// 


// switch(inputUpper)
//{
//    case var inp when inp == "T":
//        BirdInMemory bird = NewBirdInMemory();
//        NumberReader(bird, speciesName);
//        PrintStatistics(bird);
//        break;
//    case var inp when inp == "U":
//        BirdInFile bird = NewBirdInFile();
//        NumberReader(bird, speciesName);
//        PrintStatistics(bird);
//        break;
//}