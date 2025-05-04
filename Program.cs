// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Time to get familiar with C#");

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

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
int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
int bin = 0;
foreach (int items in inventory) {
    sum += items;
    Console.WriteLine($"Bin {bin++} = {items} items (Running total = {sum})");
}
Console.WriteLine($"There are {sum} total items in inventory.");