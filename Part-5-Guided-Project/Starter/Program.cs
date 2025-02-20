using System;

string[] pettingZoo = 
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

PlanSchoolVisit("School A");
PlanSchoolVisit("School B", 3);
PlanSchoolVisit("School C", 2);

// Randomize the pettings zoo array
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

// Assign an already randomized animal set to a subset group
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

// Print the animal groups
void PrintGroup(string[,] group)
{
    int numGroups = group.GetLength(0);
    int numAnimals = group.GetLength(1);

    for (int i = 0; i < numGroups; i++)
    {
        Console.Write($"Group {i + 1}: ");
        for(int j = 0; j < numAnimals; j++)
            Console.Write($"{group[i, j]}  ");

        Console.WriteLine();
    }
}

// Plan a school visit for any school with a variable number of groups (default 6)
void PlanSchoolVisit(string schoolName, int groups = 6)
{
    RandomizeAnimals();
    string[,] group = AssignGroup(groups);
    Console.WriteLine(schoolName);
    PrintGroup(group);
    Console.WriteLine();
}