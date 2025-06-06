namespace GuidedProject3 {
    class GP3 {

        // defaults
        const decimal defaultDonation = 45.00m;

        public static void Execute(string[] args)
        {
            // #1 the ourAnimals array will store the following: 
            string animalSpecies = "";
            string animalID = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";
            // RJK add
            string suggestedDonation = "";
            //

            // #2 variables that support data entry
            int maxPets = 8;
            string? readResult;
            string menuSelection = "";
            //
            decimal decimalDonation = 0.00m;
            //

            // #3 array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 7];

            // #4 create sample data ourAnimals array entries
            for (int i = 0; i < maxPets; i++)
            {
                switch (i)
                {
                    case 0:
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        suggestedDonation = "85.00";
                        break;

                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "gus";
                        suggestedDonation = "49.99";
                        break;

                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "snow";
                        suggestedDonation = "40.00";
                        break;

                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "3";
                        animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                        animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                        animalNickname = "Lion";
                        suggestedDonation = "";
                        break;

                    default:
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;

                }

                ourAnimals[i, 0] = "ID #: " + animalID;
                ourAnimals[i, 1] = "Species: " + animalSpecies;
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                // ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;

                if (!decimal.TryParse(suggestedDonation, out decimalDonation))
                    decimalDonation = defaultDonation;
                ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";

            }



            // #5 display the top-level menu options
            do
            {
                // NOTE: the Console.Clear method is throwing an exception in debug sessions
                Console.Clear();

                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Display all dogs with a specified characteristic");
                Console.WriteLine();
                Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                // use switch-case to process the selected menu option
                switch (menuSelection)
                {
                    case "1":
                        // list all pet info
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 0] != "ID #: ")
                            {
                                Console.WriteLine();
                                for (int j = 0; j <= 6; j++)
                                {
                                    Console.WriteLine(ourAnimals[i, j]);
                                }
                            }
                        }
                        Console.WriteLine("\n\rPress the Enter key to continue");
                        readResult = Console.ReadLine();

                        break;

                    case "2":
                        // Display all dogs with a specified characteristic

                        string input = "";
                        string[] dogCharacteristics = new string[1];
                        while (input == "")
                        {
                            // Prompt user to enter physical characteristics to search for
                            Console.WriteLine($"\nEnter one or more comma-separated dog characteristics to search for");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                input = readResult.ToLower().Trim();
                                dogCharacteristics = input.Split(",");
                                for(int i = 0;  i < dogCharacteristics.Length;  i++)
                                    dogCharacteristics[i] = dogCharacteristics[i].Trim();
                            }

                        }
                        Console.WriteLine();

                        // for searching animation
                        string[] searchingIcons = {".  ", ".. ", "..."};
                        string[] searchingIconsUpdated = { "/  ", "-- ", " --", "  \\", "  /", " --", "-- ", "\\  ", "   " };


                        bool noMatchesDog = true;
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 1].Contains("dog"))
                            {
                                string dogDescription = " |  " + ourAnimals[i, 4] + "\n |  " + ourAnimals[i, 5];

                                bool currentDogMatches = false;
                                foreach (string characteristic in dogCharacteristics)
                                {
                                    // This is so pointless the search is instant
                                    //   It literally just slows the mechanism down...
                                    // But here's the updated search progress indicator that was requested
                                    for (int timer = 3; timer >= 0; timer--)
                                    {
                                        foreach (string icon in searchingIconsUpdated)
                                        {
                                            Console.Write($"\rsearching our dog '{ourAnimals[i, 3].Replace("Nickname: ", "")}' for ");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write(characteristic);
                                            Console.ResetColor();
                                            Console.Write($" {icon} ");
                                            // Console.Write($"\rsearching our dog '{ourAnimals[i, 3].Replace("Nickname: ", "")}' "
                                            //             + $"for {characteristic} {icon}");
                                            Thread.Sleep(100);
                                        }
                                    }
                                    // clearing line
                                    Console.Write($"\r{new string(' ', Console.WindowWidth - 1)}");
                                    Console.Write("\r"); // could be done as part of prior statement

                                    if (dogDescription.Contains(characteristic))
                                    {
                                        noMatchesDog = false;
                                        currentDogMatches = true;
                                        Console.Write($"\rOur dog '{ourAnimals[i, 3].Replace("Nickname: ", "")}' is a \'");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(characteristic);
                                        Console.ResetColor();
                                        Console.WriteLine("' match!");
                                    }
                                }
                                if (currentDogMatches)
                                {
                                    // Console.WriteLine($" |  {ourAnimals[i, 3]}\n{dogDescription}\n");
                                    Console.WriteLine($" |  {ourAnimals[i, 3]}");
                                    string[] descriptionWords = dogDescription.Split(" ");
                                    foreach (string word in descriptionWords)
                                    {
                                        bool wordFound = false;
                                        string cleanedWord = word.TrimEnd('.', ',', '!', '?', '\n');
                                        foreach (string characteristic in dogCharacteristics)
                                        {
                                            if (cleanedWord.Equals(characteristic, StringComparison.OrdinalIgnoreCase))
                                            {
                                                wordFound = true;
                                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(cleanedWord);
                                                Console.ResetColor();
                                                Console.Write(" ");
                                            }
                                            else if (cleanedWord.Contains(characteristic))
                                            {
                                                wordFound = true;
                                                int index = cleanedWord.IndexOf(characteristic);
                                                Console.Write(cleanedWord.Substring(0, index));
                                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(cleanedWord.Substring(index, characteristic.Length));
                                                Console.ResetColor();
                                                Console.Write(cleanedWord.Substring(index + characteristic.Length));
                                            }
                                        }
                                        // Write the word if it does not contain desired characteristic keyword(s)
                                        if (!wordFound)
                                        {
                                            // Add a space after the word IF it doesn't end in a newline.
                                            Console.Write($"{word} ");//{((word[word.Length-1] == '\n') ? "" : " ")}");
                                        }
                                    }
                                    // insert a break line to separate the text.
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        if (noMatchesDog) {
                            Console.Write($"Sorry! None of our dogs are a match for '{input}'\n");
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    default:
                        break;
                }

            } while (menuSelection != "exit");
        }
    }
}