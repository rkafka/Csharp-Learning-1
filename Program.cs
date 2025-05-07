// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Time to get familiar with C#");

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security;

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


namespace AddingLogicToConsoleApplications {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\n[] Adding Logic to Console Applications in C# [] > | . . .\n");
            
            /* Tests, uncomment as desired */
            // booleanTests();
            // coinFlip();
            // businessRules();
            // codeBlocksAndVariableScope();
            // challengeActivity();
            moduleAssessment();
            /* end of test options */

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
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

