// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Time to get familiar with C#");

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security;
using Microsoft.VisualBasic;

/* TO RUN: "dotnet build ; dotnet run" */





// Random dice = new Random(); // Random dice = new();
// int roll = dice.Next(1, 7);
// Console.WriteLine("You rolled a " + roll);
// Console.WriteLine(Math.Max(500, 600));


// Random dice = new();
// int numSides = 6;
// int roll1 = dice.Next(1, numSides+1);
// int roll2 = dice.Next(1, numSides+1);
// int roll3 = dice.Next(1, numSides+1);
// Console.WriteLine($"You rolled {roll1}, {roll2}, and {roll3}");
// int score = roll1 + roll2 + roll3;
// if ( (roll1 == roll2) || (roll1 == roll3) || (roll2 == roll3) ) {
//     score += 2;
//     if((roll1 == roll2) && (roll1== roll3)) {
//         score += 6;
//     }
// }
// // if(score >= 15) {Console.WriteLine($"Congratulations! You won, scoring {score} points.");}
// // else {Console.WriteLine($"Sorry. You needed {15-score} more points to win.");}
// Console.WriteLine($"Your total was {score} points!");
// if(score >= 16)      {Console.WriteLine("You win a new car!");}
// else if(score >= 10) {Console.WriteLine("You win a new laptop!");}
// else if(score == 7)  {Console.WriteLine("You win a trip for two!");}
// else                 {Console.WriteLine("You win a kitten!");}


// Random rng = new();
// int daysUntilExpiration = rng.Next(12);
// int discountPercentage = 0;
// string message = "";
// if(daysUntilExpiration <= 10) {
//     message = "Your subscription will expire soon. Renew now!";
//     if(daysUntilExpiration <= 5) {
//         message = $"Your subscription expires in {daysUntilExpiration} days.";
//         discountPercentage = 10;
//         if(daysUntilExpiration==1) {
//             message = "You subscription expires within a day!";
//             discountPercentage = 20;
//         }
//         else if(daysUntilExpiration == 0) {
//             message = "Your subscription has expired.";
//             discountPercentage = 0;
//         }
//     }
// }
// if(message.Length > 0) {
//     if(discountPercentage > 0) {
//         message += $"\nRenew now and save {discountPercentage}%!";
//     }
//     Console.WriteLine(message);
// }


/* ARRAYS */

// string[] fraudulentOrderIDs = ["A123", "B456", "C789"];
// Console.WriteLine($@"
// First: {fraudulentOrderIDs[0]}
// Second: {fraudulentOrderIDs[1]}
// Third: {fraudulentOrderIDs[2]}
// ");
// Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.\n");

// string[] names = { "Ryan", "Robert", "Richard" };
// foreach (string name in names) {
//     Console.WriteLine(name);
// }

// int[] inventory = { 200, 450, 700, 175, 250 };
// int sum = 0;
// int bin = 0;
// foreach (int items in inventory) {
//     sum += items;
//     Console.WriteLine($"Bin {bin++} = {items} items (Running total = {sum})");
// }
// Console.WriteLine($"There are {sum} total items in inventory.");

// string[] orderIDs = {"B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"};
// foreach (string orderID in orderIDs) {
//     if(orderID.StartsWith('B')) {
//         Console.WriteLine(orderID);
//     }
// }

// static void Main(string[] args) {

// }

namespace WorkWithVariableData {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\n[] Work with Variable Data in C# [] > | . . .\n");
            
            integralTypes(); // integral types
            floatingPointTypes(); // floating point types
            referenceTypes();
                
        }

        /**
         *  Integral types
         *  - signed and unsigned integral types
         *  - min/max values for each type
         */
        static void integralTypes() {

            Console.WriteLine("Signed integral types:");
            Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");
            Console.WriteLine("");

            Console.WriteLine("Unsigned integral types:");
            Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
            Console.WriteLine("");
        }

        static void floatingPointTypes() {
            Console.WriteLine("Floating point types:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
            Console.WriteLine("");
        }
        static void referenceTypes() {
            int[] ref_A= new int[1];
            ref_A[0] = 2;
            int[] ref_B = ref_A;
            ref_B[0] = 5;
            Console.WriteLine("--Reference Types--");
            Console.WriteLine($"ref_A[0]: {ref_A[0]}");
            Console.WriteLine($"ref_B[0]: {ref_B[0]}");
        }
    }
}

namespace AddingLogicToConsoleApplications {
    class Program {
        static void Execute(string[] args) {
            Console.WriteLine("\n[] Adding Logic to Console Applications in C# [] > | . . .\n");
            
            /* Tests, uncomment as desired */
            // booleanTests();
            // coinFlip();
            // businessRules();
            // codeBlocksAndVariableScope();
            // challengeActivity();
            // moduleAssessment();
            // switchCaseTests(); // BRANCH FLOW USING SWITCH CASE
            // iterationLoops(); // FOR, FOREACH LOOPS
            // challengeActivity_ForLoops();
            // whileLoops(); // WHILE, DO-WHILE LOOPS

            /* end of test options */

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }


        static void whileLoops() {
            // Random random = new Random();
            // int current = random.Next(1, 11);

            // do {
            //     current = random.Next(1, 11);
            //     if (current >= 8) 
            //         continue;
            //     Console.WriteLine(current);
            // } while (current != 7);

            // textGame1(); // text-based game simulation

            string? readResult;
            bool validEntry = false;
            Console.Write("Enter a string containing at least three characters:  ");
            do {
                readResult = Console.ReadLine();
                if(readResult != null) {
                    if(readResult.Length >= 3) 
                        validEntry = true;
                    else
                        Console.WriteLine("Your input is invalid, please try again.");
                }
            } while(validEntry == false);

            Console.Write($"\nEnter an integer value between 5 and 10:  ");
            do {
                int inputInteger;
                if(int.TryParse(Console.ReadLine(), out inputInteger)) {
                    if(inputInteger >= 5 && inputInteger <= 10) {
                        Console.WriteLine($"Your input value {inputInteger} was accepted.");
                        break;
                    }
                    else
                        Console.WriteLine("Your input was not in the correct range (5-10), please try again.");
                } else {
                    Console.WriteLine("Your input was not an integer, please try again.");
                }
            } while(true);

            Console.Write("\nEnter your role name (Administrator, Manager, User):  ");
            do {
                string? role = Console.ReadLine();
                if(role == "Administrator" || role == "Manager" || role == "User") {
                    Console.WriteLine($"Your input value ({role}) has been accepted.");
                    break;
                } else {
                    Console.WriteLine("Your input was not a valid role name, please try again.");
                }
            } while(true);



            string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
            int stringsCount = myStrings.Length;

            string myString = "";
            int periodLocation = 0;

            for (int i = 0; i < stringsCount; i++)
            {
                myString = myStrings[i];
                periodLocation = myString.IndexOf(".");

                string mySentence;
                // extract sentences from each string and display them one at a time
                while (periodLocation != -1)
                {
                    // first sentence is the string value to the left of the period location
                    mySentence = myString.Remove(periodLocation);
                    // the remainder of myString is the string value to the right of the location
                    myString = myString.Substring(periodLocation + 1);
                    // remove any leading white-space from myString
                    myString = myString.TrimStart();
                    // update the comma location and increment the counter
                    periodLocation = myString.IndexOf(".");

                    Console.WriteLine(mySentence);
                }
            
                mySentence = myString.Trim();
                Console.WriteLine(mySentence);
            }
        }

        static bool textGame1() {
            int heroHP = 10;
            int monsterHP = 10;
            Random random = new();
            bool deathOccurred = true; // assume a kill occurs

            Console.WriteLine("You happen upon a monster. A randomized fight begins - enter to continue, 'run' to retreat.\nGood luck!\n\n");
            // loop while both Hero and Monster are alive
            do {
                if(Console.ReadLine() == "run") {
                    Console.WriteLine($"You ran away. You have escaped from the monster. ({heroHP} HP remaining)"); 
                    deathOccurred = false; // no kill occurs
                    break;
                }
                int attack = random.Next(1, 11); // attack value is 1-10
                monsterHP -= attack; // Hero attacks Monster
                Console.WriteLine($"You injured the monster for {attack} HP. It now has {monsterHP} HP.");

                if(monsterHP > 0) {
                    attack = random.Next(1, 11); // attack value is 1-10
                    heroHP -= attack; // Monster attacks Hero
                    Console.WriteLine($"You were hurt, losing {attack} HP. They now have {heroHP} HP.");
                }
            } while(heroHP > 0 && monsterHP > 0);  
            
            //
            if(deathOccurred) { 
                Console.WriteLine($"Hero HP: {heroHP} | Monster HP: {monsterHP}");
                Console.WriteLine($"{(heroHP > 0 ? "You have slain the beast. Congratulations, hero!" : "Oh no! You've been eaten by the monster.")}");
            }

            return deathOccurred && monsterHP <= 0; // return true if monster is dead
        }


        static void challengeActivity_ForLoops() {
            for (int i = 1; i <= 100; i++) {
                Console.Write(i);
                if(i%3==0 || i%5==0) {
                    Console.Write(" - ");
                    if (i % 3 == 0)
                        Console.Write("Fizz");
                    if (i % 5 == 0)
                        Console.Write("Buzz");
                }
                Console.WriteLine();
            }
        }


        static void iterationLoops() {
            // BASIC FOR (using index) + conditional break
            for(int i = 0; i < 10; i++) {
                Console.WriteLine($"For loop: {i}");
                if(i == 5) {
                    Console.WriteLine("Breaking out of the loop.");
                    break; // exit the loop
                }
            }

            // FOR (using length of string) vs FOREACH
            string[] names = {"Aaron", "Ben" , "Chris", "Dani"};
            for (int i = names.Length - 1; i >= 0; i--) {
                Console.WriteLine($"For loop: {names[i]}");
            }
            foreach(string name in names) {
                Console.WriteLine($"Foreach loop: {name}");
            }

            // FOR loop, with replacement by index during iteration
            for (int i = 0; i < names.Length; i++) {
                Console.WriteLine($"For loop: {(names[i].StartsWith("A") ? "A-A-Ron, say it right!" : names[i] )}");
                // inefficent but funnier
                if(names[i].StartsWith("A")) 
                    names[i] = "A-A-Ron";
            }
        }

        static void switchCaseTests() {
            // SKU = Stock Keeping Unit. 
            // SKU value format: <product #>-<2-letter color code>-<size code>
            string sku = "01-MN-L";
            string[] product = sku.Split('-');

            string type = "";
            string color = "";
            string size = "";

            // determining product type
            switch(product[0]) {
                case "01":
                    type = "Sweat shirt"; break;
                case "02":
                    type = "T-Shirt"; break;
                case "03":
                    type = "Sweat pants"; break;
                default:
                    type = "Other"; break;
            }

            //determining product color
            switch (product[1]) {
                case "BL":
                    color = "Black"; break;
                case "MN":
                    color = "Maroon"; break;
                default:
                    color = "White"; break;
            }

            switch (product[2]) {
                case "S":
                    size = "Small"; break;
                case "M":
                    size = "Medium"; break;
                case "L":
                    size = "Large"; break;
                default:
                    size = "One Size Fits All"; break;
            }

            Console.WriteLine($"Product: {size} {color} {type}");
            
            // int employeeLevel = 200;
            // string employeeName = "John Smith";
            // string title = "";
            // switch (employeeLevel)
            // {
            //     case 100:
            //     case 101:
            //         title = "Junior Associate";
            //         break;
            //     case 200:
            //         title = "Senior Associate";
            //         break;
            //     case 300:
            //         title = "Manager";
            //         break;
            //     case 400:
            //         title = "Senior Manager";
            //         break;
            //     default:
            //         title = "Associate";
            //         break;
            // }
            // Console.WriteLine($"{employeeName}, {title}");
        }

        static void moduleAssessment() {
            int int1 = 1;
            if(int1 > 0) {
                int int2 = 8;
                int1 += int2;
            }
            Console.WriteLine($"Q2:  int1 = {int1}");
        }

        static void challengeActivity() {
            /* ORIGINAL CODE -- TO-FIX! */
            // int[] numbers = { 4, 8, 15, 16, 23, 42 };
            // foreach (int number in numbers){
            //     int total;
            //     total += number;
            //     if (number == 42)
            //         bool found = true;
            // }
            // if (found) 
            //     Console.WriteLine("Set contains 42");
            // Console.WriteLine($"Total: {total}");
            
            int[] numbers = { 4, 8, 15, 16, 23, 42 };

            int total = 0;
            bool found = false;
            // loop through the array and calculate the total
            foreach (int number in numbers) {
                total += number;
                // denote if 42 is found in the list of numbers
                if (number == 42)
                    found = true;
            }
            if (found) 
                Console.WriteLine("Set contains 42");
            Console.WriteLine($"Total: {total}");
        }
        
        static void codeBlocksAndVariableScope() {
            bool flag = true;
            int number = 0;
            if(flag) {
                number = 20;
                Console.WriteLine($"Inside the code block, number = {number}");
            }
            number = 10;
            Console.WriteLine($"Outside the code block, number = {number}");
        
            int int1 = 5;
            if(int1 > 0) {
                int int2 = 6;
                int1 += int2;
            }
            Console.WriteLine($"int1 = {int1}"); // int2 is not accessible here, so this will throw an error
        }


        /**
         *  Business rules simulation
         *  - string comparison [string.Contains() method]
         *  - conditional operator (ternary)
         */
        static void businessRules() {
            // gatjhering string for permission (no validation)
            Console.Write("Enter a permission level (Admin, Manager, User): ");
            string permission = Console.ReadLine();
            if(permission == null || permission.Length == 0)
                permission = "Admin|Manager";
            Console.WriteLine($"You entered {((permission=="Admin|Manager")?"(default) ":"")}{permission}");
            // gathering integer for level (no validation)
            Console.Write("Enter a level: "); 
            int level = int.Parse(Console.ReadLine()); 
            Console.WriteLine("You entered " + level);

            if(permission.Contains("Admin"))
                Console.WriteLine($"Welcome, {((level > 55) ? "Super " : "")}Admin user.");
            else if(permission.Contains("Manager") && level >= 20)
                Console.WriteLine("Contact an Admin for access.");
            else
                Console.WriteLine("You do not have sufficient privileges.");
        }   


        /**
         *  Coin flip simulation
         *  - Random class, Next() method for 50/50 RNG
         *  - Conditional operator (ternary)
         */
        static void coinFlip() {
            Random random = new();
            int flip = random.Next(2); // 0 or 1
            Console.WriteLine($"You flipped a coin and got {((flip == 0) ? "Heads" : "Tails")}.");
        }


        /**
         *  Boolean tests
         *  - string comparison
         *  - conditional operator (ternary)
         */
        static void booleanTests() {
            string value1 = " a";
            string value2 = "A ";
            Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

            int saleAmount = 1000;
            Console.WriteLine($"Discount = {(saleAmount > 1000 ? 100 : 50)}");
        }
    }
}

