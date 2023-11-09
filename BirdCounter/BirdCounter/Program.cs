﻿using BirdCounter;


Console.WriteLine("Welcome to BirdCounter application!");
Console.WriteLine("");

Starter();

void Starter()
{
    string speciesName = "";
    Console.WriteLine("Enter full species name:");
    RunProgram(speciesName);
}

void RunProgram(string speciesName)
{
    ReadSpeciesName(out speciesName);
    CheckFileExists(speciesName);
    PrintMenu();

    while (true)
    {
        var input = Console.ReadLine()!;
        var inputUpper = input.ToUpper();

        if (inputUpper == "T")
        {
            var bird = NewBirdInMemory(speciesName);
            bird.ObservationAdded += ObservationAdded;
            NumberReader(bird, speciesName);
            PrintStatistics(bird);
            ContinueDecision();
        }
        else if (inputUpper == "U")
        {
            var speciesNameLower = speciesName.ToLower();
            var bird = NewBirdInFile(speciesNameLower);
            bird.ObservationAdded += ObservationAdded;
            NumberReader(bird, speciesName);
            PrintStatistics(bird);
            ContinueDecision();
        }
        else if (inputUpper == "Q")
        {
            BirdInFile bird = NewBirdInFile(speciesName);
            PrintStatistics(bird);
            ContinueDecision();
        }
        else if (inputUpper == "N")
        {
            Console.Clear();
            Console.WriteLine("BirdCounter new sesion");
            Console.WriteLine("------------------------------------------------------");
            Starter();
        }
        else if (inputUpper == "G")
        {
            Console.WriteLine(" I: 50-70 H: 71-100 G: 101-150 F: 151-200, E: 201-300, D: 301-400, C: 401-500, B: 501-700, A: 700-1000");
            Console.WriteLine("now please chose another key from menu");
            continue;
        }
        else
        {
            Console.WriteLine("Incorrect value - chose key from menu");
            continue;
        }
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
    Console.WriteLine("Press any other key to exit the pllication");
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

static void PrintMenu()
{
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("press T key to work with temporary data");
    Console.WriteLine("press U key to create new file with set of data or update existing file");
    Console.WriteLine("press Q key anytime to to quit and get statistics");
    Console.WriteLine("press N key anytime to start new sesion");
    Console.WriteLine("press G key to display group observation codes");

    Console.WriteLine("------------------------------------------------------");
}

static void ReadSpeciesName(out string speciesName)
{
    speciesName = Console.ReadLine();
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
        Console.WriteLine("Enter subsequent numbers of observed individuals:"); // event - dodano do pliku lub dodano do pamięci
        var inputNumber = Console.ReadLine();
        var inputNumUpper = inputNumber.ToUpper();
        if (inputNumUpper == "Q")
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
        Console.WriteLine("can not calcucalte statistics because there are no data provided");
        ContinueDecision();
    }
    else
    {
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine($"Sum: {statistics.Sum}");
        Console.WriteLine($"Avarage single observation: {statistics.Avarage}");
        Console.WriteLine($"Number of input data: {statistics.Count}");
    }

}

void ObservationAdded(object sender, EventArgs args)
{
    Console.WriteLine("An observation has been aded");
}


// testy jednostkowe
// switch
// hermetyzacja





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