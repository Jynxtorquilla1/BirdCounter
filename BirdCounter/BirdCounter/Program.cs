using BirdCounter;

Console.WriteLine("Welcome to the BirdCounter application!");
Console.WriteLine("------------------------------------------------------");
Console.WriteLine("Here you can enter the bird counting data of particular observations or form different observers");
Console.WriteLine("In order to obtain bird species count statistics");
Console.WriteLine("------------------------------------------------------");

Console.WriteLine("");

Starter();

void Starter()
{
    Console.WriteLine("Enter full bird species name:");
    RunProgram();
}

void RunProgram()
{
    string speciesName = ReadSpeciesName();
    CheckFileExists(speciesName);
    PrintMenu();

    IBird bird = null;

    while (true)
    {
        var input = Console.ReadLine()!.ToUpper();        

        switch (input)
        {
            case "T":
                bird = NewBirdInMemory(speciesName);
                bird.GroupObservationEvent += GroupObservationAdded;
                break;

            case "U":
                try
                {
                    var speciesNameLower = speciesName.ToLower();
                    bird = NewBirdInFile(speciesNameLower);
                    bird.GroupObservationEvent += GroupObservationAdded;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
                break;

            case "S":
                if (File.Exists($"{speciesName}.txt"))
                {
                    var speciesNameLower = speciesName.ToLower();
                    bird = NewBirdInFile(speciesNameLower);
                    bird.GroupObservationEvent += GroupObservationAdded;
                    PrintStatistics(bird);
                    FileUpdateDecision(bird, speciesName);
                }
                else
                {
                    Console.WriteLine("There is no file with data or any data provided directly to calculate statistics");
                    Console.WriteLine("please select T or Y key from the menu to enter new data");

                }
                break;

            case "N":
                Console.Clear();
                Console.WriteLine("BirdCounter new session");
                Console.WriteLine("------------------------------------------------------");
                Starter();
                break;

            case "G":
                Console.WriteLine("     key letter - estimated range of number of individuals observed");
                Console.WriteLine("     I: 50-70 H: 71-100 G: 101-150 F: 151-200, E: 201-300, D: 301-400, C: 401-500, B: 501-700, A: 700-1000");
                Console.WriteLine("     please select key T or key U from the menu to start editing data");
                continue;

            default:
                Console.WriteLine("Incorrect key - select the key from menu");
                continue;
        }

        if (bird != null)
        {
            NumberReader(bird, speciesName);
            PrintStatistics(bird);
            ContinueDecision();
        }
        else
        {
            continue;
        }
    }
}

static string ReadSpeciesName()
{
    return Console.ReadLine();
}

BirdInMemory NewBirdInMemory(string speciesName)
{
    return new BirdInMemory(speciesName);
}

BirdInFile NewBirdInFile(string speciesName)
{
    return new BirdInFile(speciesName);
}

void NumberReader(IBird bird, string speciesName)
{
    while (true)
    {
        Console.WriteLine("Enter consecutive numbers of individuals observed:");
        var inputNumber = Console.ReadLine();
        var inputNumUpper = inputNumber.ToUpper();
        if (inputNumUpper == "S")
        {
            if (bird is BirdInFile)
            {
                PrintStatistics(bird);
                FileUpdateDecision(bird, speciesName);
                break; 
            }
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
                bird.AddNumber(inputNumUpper);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

void PrintStatistics(IBird bird)
{
    var statistics = bird.GetStatistics();

    if (statistics.Count == 0)
    {
        Console.WriteLine("Statistics cannot be calculated as no data is provided");
        ContinueDecision();
    }
    else
    {
        Console.WriteLine($"Bird species: {bird.SpeciesName}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine($"Sum: {statistics.Sum}");
        Console.WriteLine($"Avarage single observation: {Math.Round(statistics.Avarage)}");
        Console.WriteLine($"Number of input data: {statistics.Count}");
    }

}

void CheckFileExists(string speciesName)
{

    if (File.Exists($"{speciesName}.txt"))
    {
        Console.WriteLine($"File named '{speciesName}' already exists in the default folder.");
    }
    else
    {
        Console.WriteLine($"File named '{speciesName}' does not exist in the default folder.");
    }
}

void ContinueDecision()
{
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Do you want to continue your work?");
    Console.WriteLine("Press Y key to start new sesion");
    Console.WriteLine("Press any other key to exit the application");
    Console.WriteLine("------------------------------------------------------");

    var answer = Console.ReadLine()!;
    var answerUpper = answer.ToUpper();
    if (answerUpper == "Y")
    {
        Console.Clear();
        Console.WriteLine("BirdCounter new sesion");
        Console.WriteLine("------------------------------------------------------");
        Starter();
    }
    else
    {
        Environment.Exit(0);
    }
}

void FileUpdateDecision(IBird bird, string speciesName)
{
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Do you want to add new data to this file?");
    Console.WriteLine("Press Y key to complete the data in the file");
    Console.WriteLine("Press any other key to quit the session or start new sesion");
    Console.WriteLine("------------------------------------------------------");

    var answer = Console.ReadLine()!;
    var answerUpper = answer.ToUpper();
    if (answerUpper == "Y")
    {
        NumberReader(bird, speciesName);
        PrintStatistics(bird);
        ContinueDecision();
    }
    else
    {
        ContinueDecision();
    }
}

static void PrintMenu()
{
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("press T key to work with temporary data");
    Console.WriteLine("press U key to create a new data set file or to update an existing file");
    Console.WriteLine("press S key anytime to get instant statistics from file or from supplied data");
    Console.WriteLine("press N key anytime to start new session");
    Console.WriteLine("press G key to display group observation codes");
    Console.WriteLine("------------------------------------------------------");
}

void GroupObservationAdded(object sender, EventArgs args)
{
    Console.WriteLine("group observation has been added");
}






