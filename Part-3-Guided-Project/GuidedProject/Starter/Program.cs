// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    StoreAnimalInfo(i);
}

do
{
    // display the top-level menu options
    DisplayMenu();

    readResult = Console.ReadLine();
    if (readResult == null)
        continue;

    menuSelection = readResult.ToLower();
    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            DisplayCurrentPets();
            break;
        case "2":
            // Add a new animal friend to the ourAnimals array
            AddNewAnimal();
            break;
        case "3":
            // Ensure animal ages and physical descriptions are complete
            Console.WriteLine("Challenge Project - please check back soon to see progress.");
            break;
        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            Console.WriteLine("Challenge Project - please check back soon to see progress.");
            break;
        case "5":
            // Edit an animal's age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;
        case "6":
            // Edit an animal's personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;
        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;
        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;
        default:
            continue;
    }
    Console.WriteLine("Press the Enter key to continue.");
    readResult = Console.ReadLine();
} while (menuSelection != "exit");

void DisplayMenu()
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal's age");
    Console.WriteLine(" 6. Edit an animal's personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
}

int GetPetCount()
{
    int count = 0;
    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] != "ID #: ")
            count++;
    }
    return count;
}

void DisplayCurrentPets()
{
    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] != "ID #: ")
        {
            Console.WriteLine();
            for (int j = 0; j < 6; j++)
                Console.WriteLine(ourAnimals[i, j]);
        }
    }
}

void AddNewAnimal()
{
    string anotherPet = "y";
    int petCount = GetPetCount();
    bool canManageMorePets = petCount < maxPets;

    if (canManageMorePets)
        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");

    while (anotherPet == "y" && canManageMorePets)
    {
        GetAnimalSpecies();
        GetAnimalAge();
        GetAnimalPhysicalDescription();
        GetAnimalPersonality();
        GetAnimalNickname();
        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

        StoreAnimalInfo(petCount);

        petCount++;
        canManageMorePets = petCount < maxPets;
        if (!canManageMorePets)
            break;

        Console.WriteLine("Do you want to enter info for another pet (y/n)");
        do
        {
            readResult = Console.ReadLine();
            if (readResult == null)
                continue;

            anotherPet = readResult.ToLower();
        } while (anotherPet != "y" && anotherPet != "n");
    }

    if (!canManageMorePets)
        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
}

void GetAnimalSpecies()
{
    bool validEntry = false;
    do
    {
        Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
        readResult = Console.ReadLine();
        if (readResult == null)
            continue;

        animalSpecies = readResult.ToLower();
        if (animalSpecies != "dog" && animalSpecies != "cat")
            validEntry = false;
        else
            validEntry = true;

    } while (validEntry == false);
}

void GetAnimalAge()
{
    bool validEntry = false;
    do
    {
        int petAge;
        Console.WriteLine("Enter the pet's age or enter ? if unknown");
        readResult = Console.ReadLine();
        if (readResult == null)
            continue;

        animalAge = readResult;
        if (animalAge != "?")
            validEntry = int.TryParse(animalAge, out petAge);
        else
            validEntry = true;

    } while (validEntry == false);
}

void GetAnimalPhysicalDescription()
{
    do
    {
        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
        readResult = Console.ReadLine();
        if (readResult == null)
            continue;

        animalPhysicalDescription = readResult.ToLower();
        if (animalPhysicalDescription == "")
            animalPhysicalDescription = "tbd";

    } while (animalPhysicalDescription == "");
}

void GetAnimalPersonality()
{
    do
    {
        Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
        readResult = Console.ReadLine();
        if (readResult == null)
            continue;

        animalPersonalityDescription = readResult.ToLower();
        if (animalPersonalityDescription == "")
            animalPersonalityDescription = "tbd";
    } while (animalPersonalityDescription == "");
}

void GetAnimalNickname()
{
    do
    {
        Console.WriteLine("Enter a nickname for the pet");
        readResult = Console.ReadLine();
        if (readResult == null)
            continue;

        animalNickname = readResult.ToLower();
        if (animalNickname == "")
            animalNickname = "tbd";
    } while (animalNickname == "");
}

void StoreAnimalInfo(int index)
{
    ourAnimals[index, 0] = "ID #: " + animalID;
    ourAnimals[index, 1] = "Species: " + animalSpecies;
    ourAnimals[index, 2] = "Age: " + animalAge;
    ourAnimals[index, 3] = "Nickname: " + animalNickname;
    ourAnimals[index, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[index, 5] = "Personality: " + animalPersonalityDescription;
}