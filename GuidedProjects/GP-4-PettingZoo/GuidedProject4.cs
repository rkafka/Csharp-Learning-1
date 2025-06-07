using System;

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
            string[,] group = AssignGroup();
            PrintGroup(group);
        }

        static void RandomizeAnimals(PettingZoo PZ)
        {
            Random rng = new();
            for (int i = 0; i < PZ.Animals.Length; i++)
            {
                // retrieve random index
                int r = rng.Next(i, PZ.Animals.Length);
                // perform swap
                string temp = PZ.Animals[i];
                PZ.Animals[i] = PZ.Animals[r];
                PZ.Animals[r] = temp;
            }
        }
        static void TestRandomizeAnimals()
        {
            
        }

        static string[,] AssignGroup()
        {
            return new string[0, 0];
            Console.WriteLine("\n\nFUNCTION 'AssignGroup()' NOT COMPLETE\n");
        }

        static void PrintGroup(string[,] group)
        {
            School p = new School("A");
            Console.WriteLine("\n\nFUNCTION 'PrintGroup()' NOT COMPLETE\n");
        }



    }

    public class School {
        public string Name;
        public int NumVisitingGroups;

        // Constructor
        public School(string name, int numVisitingGroups = 6) {
            Name = "School " + name;
            NumVisitingGroups = numVisitingGroups;
        }
        // ToString Override
        public override string ToString()
        {
            return $"{Name}, with {NumVisitingGroups} visiting groups";
        }
    }

    public class PettingZoo {
        public string Name;
        public string[] Animals;

        public static string[] DefaultAnimalList = {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };

        // Constructor
        public PettingZoo(string name, string[]? animals=null)
        {
            Name = name;
            Animals = (animals == null) ? animals : (string[])DefaultAnimalList.Clone();
        }
    }
}
