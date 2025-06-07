using System;
using System.Net.Mime;

namespace GuidedProject4 {
    class GP4
    {
        /*
            PROJECT OVERVIEW
            
            You're developing an application for the Contoso Petting Zoo that coordinates school visits. 
            The Contoso Petting Zoo is home to 18 different species of animals. At the zoo, visiting 
            students are assigned to groups, and each group has a set of animals assigned to it. After 
            visiting their set of animals, the students will rotate groups until they've seen all the 
            animals at the petting zoo.

            By default, the students are divided into 6 groups. 
            However, there are some classes that have a small or large number of students, so the 
            number of groups must be adjusted accordingly. The animals should also be randomly assigned 
            to each group, so as to keep the experience unique.

            DESIGN SPECIFICATIONS
            - There will be three visiting schools
                - School A has six visiting groups (the default number)
                - School B has three visiting groups
                - School C has two visiting groups
            - For each visiting school, perform the following tasks
                - Randomize the animals
                - Assign the animals to the correct number of groups
                - Print the school name
                - Print the animal groups
        */

        public static void Execute(string[] args)
        {
            // var group = AssignGroup();
            // string[,] group = AssignGroup();

            PettingZoo PZ = new("Contoso");

            // School schoolA = new("A");
            // RandomizeAnimals(PZ);
            // PZ.RandomizeAnimals();
            // int start = 0;
            // int end = PZ.NumAnimals / schoolA.NumGroups;
            // for (int groupNum = 0; groupNum < schoolA.NumGroups; groupNum++)
            // {
            //     schoolA.Groups[groupNum].AssignGroup(PZ.Animals[start..end]);
            // }
            // schoolA.Output(); 
            School schoolA = new("A");
            GenerateVisitingGroups(schoolA, PZ);
            School schoolB = new("B", 3);
            GenerateVisitingGroups(schoolB, PZ);
            School schoolC = new("C", 2);
            GenerateVisitingGroups(schoolC, PZ);
            // PrintGroup();

            // PrintGroup(group);
        }

        public static void GenerateVisitingGroups(School curSchool, PettingZoo PZ)
        {
            PZ.RandomizeAnimals();
            int start = 0;
            int end = PZ.NumAnimals / curSchool.NumGroups;
            for (int groupNum = 0; groupNum < curSchool.NumGroups; groupNum++)
            {
                curSchool.Groups[groupNum].AssignGroup(PZ.Animals[start..end]);
            }
            curSchool.Output(); 
        }

        // static void RandomizeAnimals(PettingZoo PZ)
        // {
        //     Random rng = new();
        //     for (int i = 0; i < PZ.Animals.Length; i++)
        //     {
        //         // retrieve random index
        //         int r = rng.Next(i, PZ.Animals.Length);
        //         // perform swap
        //         string temp = PZ.Animals[i];
        //         PZ.Animals[i] = PZ.Animals[r];
        //         PZ.Animals[r] = temp;
        //     }
        // }
        // static void TestRandomizeAnimals()
        // {
        //     Utils.Helper.OutputTitle("Testing RandomizeAnimals()");
        //     PettingZoo tempPZ = new PettingZoo("temp");

        //     foreach (string animal in tempPZ.Animals)
        //         Console.Write($"{animal} ");
        //     Console.WriteLine();

        //     tempPZ.RandomizeAnimals();
        // }

        // static string[,] AssignGroup()
        // {
        //     return new string[0, 0];
        //     Console.WriteLine("\n\nFUNCTION 'AssignGroup()' NOT COMPLETE\n");
        // }

        static void PrintGroup(string[,] group)
        {
            School p = new School("A");
            Console.WriteLine("\n\nFUNCTION 'PrintGroup()' NOT COMPLETE\n");
        }
    }
    public class Group(int groupNumber, int numAnimals = -1) {
        public int GroupNumber = groupNumber;
        public int NumAnimals = numAnimals;
        public string[]? Animals = new string[numAnimals];

        public void AssignGroup(string[] animals)
        {
            if (animals == null)
            {
                Console.WriteLine("\n\nERROR in AssignGroup()\n\n");
                return;
            }
            for (int i = 0; i < NumAnimals; i++)
            {
                Animals[i] = animals[i];
            }
        }
        
        // ToString Override
        public override string ToString()
        {
            return $"Group #{GroupNumber}: {string.Join(", ", Animals)}";
        }
    }

    public class School
    {
        public string Name;
        public int NumGroups;
        public Group[] Groups;

        // Constructor
        public School(string name, int numGroups = 6)
        {
            Name = "School " + Utils.Helper.CapitalizeFirstLetter(name);
            NumGroups = numGroups;

            Groups = new Group[NumGroups];
            for (int groupNumber = 1; groupNumber <= NumGroups; groupNumber++)
                Groups[groupNumber] = new Group(groupNumber);
        }
        // ToString Override
        public override string ToString()
        {
            return $"{Name}, with {NumGroups} visiting groups:";
        }

        public void Output()
        {
            Console.WriteLine($"{Name}");
            // Console.WriteLine($"{string.Join("\n",Groups)}");
            foreach (Group group in Groups)
            {
                Console.WriteLine($"{group}");
            }
        }
    }

    public class PettingZoo(string name = "Contoso", string[]? animals = null)
    {
        public string Name = Utils.Helper.CapitalizeFirstLetter(name) + " Petting Zoo";
        public string[]? Animals = (animals == null) ? animals : (string[])DefaultAnimalList.Clone();
        public int NumAnimals = DefaultAnimalList.Length;

        public static string[] DefaultAnimalList = {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };

        public void RandomizeAnimals()
        {
            Random rng = new();
            for (int i = 0; i < Animals.Length; i++)
            {
                // retrieve random index
                int r = rng.Next(i, Animals.Length);
                // perform swap
                string temp = Animals[i];
                Animals[i] = Animals[r];
                Animals[r] = temp;
            }
        }
        public static void TestRandomizeAnimals()
        {
            Utils.Helper.OutputTitle("Testing RandomizeAnimals()");
            PettingZoo tempPZ = new PettingZoo("temp");

            foreach (string animal in tempPZ.Animals)
                Console.Write($"{animal} ");
            Console.WriteLine();

            tempPZ.RandomizeAnimals();
        }
    }
}
