using System;

string[] pettingZoo = 
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

// Randomize the pettings zoo array
RandomizeAnimals();

// Assign a randomized animal set to a subset group
string[,] group = AssignGroup();

// Print the school name
Console.WriteLine("School A");

// Print the animal groups
//PrintGroup(group);

void RandomizeAnimals()
{
    Random random = new Random();

    for (int i = 0; i < pettingZoo.Length; i++)
    {
        int r = random.Next(i, pettingZoo.Length);

        string temp = pettingZoo[i];
        pettingZoo[i] = pettingZoo[r];
        pettingZoo[r] = temp;
    }
}

string [,] AssignGroup(int groups = 6)
{
    int animalsPerGroup = pettingZoo.Length / groups;
    string[,] result = new string[groups, animalsPerGroup];
    int start = 0;
    
    for (int i = 0; i < groups; i++)
    {
        for (int j = 0; j < animalsPerGroup; j++)
        {
            result[i, j] = pettingZoo[start++];
        }
    }

    return result;
}

/* TEST DISPLAY */
foreach (string animal in pettingZoo)
    Console.WriteLine(animal);