using System.ComponentModel;

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

// RJK add
string speciesPrefix = "Species: ";
string idPrefix = "ID #: ";
string agePrefix = "Age: ";
string physicalPrefix = "Physical description: ";
string personalityPrefix = "Personality: ";
string nicknamePrefix = "Nickname: ";

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

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

string[] menuOptions = {
                "ERROR <- option zero should not be visible",
                "List all of our current pet information",
                "Add a new animal friend to the ourAnimals array",
                "Ensure animal ages and physical descriptions are complete",
                "Ensure animal nicknames and personality descriptions are complete",
                "Edit an animal’s age",
                "Edit an animal’s personality description",
                "Display all cats with a specified characteristic",
                "Display all dogs with a specified characteristic",
                "Exit the program"
            };

// display the top-level menu options
do
{
    Console.Clear();

    // display the menu options
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    for (int i = 1; i < menuOptions.Length; i++)
    {
        Console.WriteLine($" {i}. {menuOptions[i]}");
    }
    Console.WriteLine();

    // get the user's menu selection
    Console.Write("Enter your selection number --->  ");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }
    Console.WriteLine($"You selected menu option {menuSelection} ({menuOptions[int.Parse(menuSelection)]}).\n");

    // handle menu selection requested by the user
    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }
            //
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                    }
                    validEntry = (animalSpecies == "dog" || animalSpecies == "cat") ? true : false;
                } while (validEntry == false);

                // set animal ID
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // set animal age
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age in years (or enter '?' if unknown)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalAge = readResult.ToLower();

                    if (animalAge != "?")
                        validEntry = int.TryParse(animalAge, out petAge);
                    else
                        validEntry = true;
                } while (validEntry == false);

                // set animal physical description
                do
                {
                    Console.WriteLine("Enter a physical description of the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                            animalPhysicalDescription = "tbd";
                    }
                } while (animalPhysicalDescription == "");

                // set animal personality description
                do
                {
                    Console.WriteLine("Enter a personality description of the pet (likes, dislikes, tricks, energy level, etc.)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                            animalPersonalityDescription = "tbd";
                    }
                } while (animalPersonalityDescription == "");

                // set animal nickname
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                            animalNickname = "tbd";
                    }
                } while (animalNickname == "");

                // add the new pet to the ourAnimals array
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                petCount++;

                // check to add more pets
                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet? (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        /* "Ensure animal ages and physical descriptions are complete" */
        case "3":
            Console.WriteLine("Ensuring animal ages and physical descriptions are complete ...");

            for (int i = 0; i < maxPets; i++)
            {
                // Skip over any animal in the array with a pet ID set to the default val
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    bool validEntry = false;
                    // print ID
                    Console.WriteLine(ourAnimals[i, 0]);

                    // handle Age
                    string currentAge = ourAnimals[i, 2].Substring(agePrefix.Length);
                    if (!int.TryParse(currentAge, out int petAge))
                    {
                        do
                        {
                            Console.Write($"      |-[INPUT]-> Pet's age in years:  ");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult.ToLower();
                                validEntry = int.TryParse(animalAge, out petAge);
                                ourAnimals[i, 2] = "Age: " + petAge.ToString();
                            }
                        } while (validEntry == false);
                        Console.WriteLine($"      |---> {ourAnimals[i, 0].Substring(idPrefix.Length)}'s " +
                                          $"age updated to {petAge.ToString()}.");
                    }
                    else
                    {
                        Console.WriteLine($"      | Age: {currentAge}");
                    }

                    // handle Physical Description

                    string currentDesc = ourAnimals[i, 4].Substring(physicalPrefix.Length);
                    if (currentDesc.Length < 15)
                    {
                        validEntry = false;
                        string newDescription = "";
                        do
                        {
                            Console.Write($"      |-[INPUT]-> Physical description of the pet (15+ characters):  ");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                newDescription = readResult.ToLower();
                                ourAnimals[i, 4] = physicalPrefix + newDescription;
                            }
                        } while (newDescription.Length < 15);
                        Console.WriteLine($"      |---> {ourAnimals[i, 0].Substring(idPrefix.Length)}'s " +
                                          $"desc updated to {newDescription}.");
                    }
                    else
                    {
                        Console.WriteLine($"      | {physicalPrefix}{currentDesc}");
                    }
                }
            }

            Console.WriteLine("Age & physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        //
        case "4":
            Console.WriteLine("Ensuring animal nicknames and personality descriptions are complete ...");

            for (int i = 0; i < maxPets; i++)
            {
                // Skip over any animal in the array with a pet ID set to the default val
                if (ourAnimals[i, 0] != "ID #: ") {
                    // print ID
                    Console.WriteLine(ourAnimals[i, 0]);

                    // handle nickname
                    string currentNickName = ourAnimals[i, 3].Substring(nicknamePrefix.Length);
                    if (currentNickName == "" || currentNickName == "tbd") {
                        string newNickName = "";
                        do
                        {
                            Console.Write($"      |-[INPUT]-> Pet's nickname:  ");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                newNickName = readResult.ToLower();
                                ourAnimals[i, 3] = nicknamePrefix + newNickName;
                            }
                        } while (newNickName.Length < 3);
                        Console.WriteLine($"      |---> {ourAnimals[i, 0].Substring(idPrefix.Length)}'s " +
                                          $"nickname updated to \"{newNickName}\"");
                    }
                    else
                        Console.WriteLine($"      | Nickname: {currentNickName}");
                        

                    // handle Personality Description
                    string currentDesc = ourAnimals[i, 5].Substring(personalityPrefix.Length);
                    if (currentDesc.Length < 15) {
                        string newDescription = "";
                        do {
                            Console.Write($"      |-[INPUT]-> Personality description (15+ chars):  ");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                newDescription = readResult.ToLower();
                                ourAnimals[i, 5] = personalityPrefix + newDescription;
                            }
                        } while (newDescription.Length < 15);
                        Console.WriteLine($"      |---> {ourAnimals[i, 0].Substring(idPrefix.Length)}'s " +
                                          $"desc updated to \"{newDescription}\"");
                    }
                    else
                        Console.WriteLine($"      | {personalityPrefix}{currentDesc}");
                }
            }

            Console.WriteLine("Nickname & personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        //
        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            
            
            Console.Write("Please enter the animal ID of the pet whose age you want to edit.\nOptions:");
            for (int i = 0; i < maxPets; i++) {
                // Skip over any animal in the array with a pet ID set to the default val
                if (ourAnimals[i, 0] != "ID #: ") {
                    // [ID#] = "nickname", age
                    Console.Write($"  [{ourAnimals[i, 0].Substring(idPrefix)}] = \"{ourAnimals[i, 3].Substring(nicknamePrefix)},\" {ourAnimals[i, 2].Substring(agePrefix)} years old\n");
                }
            }

            string? animalIDToEdit = "";
            int desiredIndex = -1;
            do {
                animalIDToEdit = Console.ReadLine();
                for(int i = 0; i < maxPets; i++) {
                    if( ourAnimals[i,0] == (idPrefix+animalIDToEdit)) {
                        desiredIndex = i;
                        break;
                    }
                }
            } while(animalIDToEdit != "exit" && desiredIndex == -1);
            
            bool valid5 = false;

            // handle Age
            string currentAge = ourAnimals[desiredIndex, 2].Substring(agePrefix.Length);
            int petAge = -1;
            do
            {
                Console.Write($"      |-[INPUT]-> Pet's age in years:  ");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult.ToLower();
                    valid5 = int.TryParse(animalAge, out petAge);
                    ourAnimals[desiredIndex, 2] = "Age: " + petAge.ToString();
                }
            } while (valid5 == false);
            Console.WriteLine($"      |---> {ourAnimals[desiredIndex, 0].Substring(idPrefix.Length)}'s " +
                                $"age updated to {petAge.ToString()}.");

            
            // Done, return to the main menu
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            
            
            // Done, return to the main menu
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            
            
            // Done, return to the main menu
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress.");
            
            
            // Done, return to the main menu
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "9":
            // signal to exit the program
            menuSelection = "exit";
            break;
        default:
            break;
    }
    // // pause code execution
    // Console.WriteLine("Press the Enter key to continue.");
    // readResult = Console.ReadLine();
} while (menuSelection != "exit");
