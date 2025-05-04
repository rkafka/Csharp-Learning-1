// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Time to get familiar with C#");

using System.Numerics;

// Random dice = new Random(); // Random dice = new();
// int roll = dice.Next(1, 7);
// Console.WriteLine("You rolled a " + roll);
// Console.WriteLine(Math.Max(500, 600));

Random dice = new();
int numSides = 6;
int roll1 = dice.Next(1, numSides+1);
int roll2 = dice.Next(1, numSides+1);
int roll3 = dice.Next(1, numSides+1);
Console.WriteLine($"You rolled {roll1}, {roll2}, and {roll3}");
int score = roll1 + roll2 + roll3;
if ( (roll1 == roll2) || (roll1 == roll3) || (roll2 == roll3) ) {
    score += 2;
    if((roll1 == roll2) && (roll1== roll3)) {
        score += 6;
    }
}
// if(score >= 15) {Console.WriteLine($"Congratulations! You won, scoring {score} points.");}
// else {Console.WriteLine($"Sorry. You needed {15-score} more points to win.");}
Console.WriteLine($"Your total was {score} points!");
if(score >= 16)      {Console.WriteLine("You win a new car!");}
else if(score >= 10) {Console.WriteLine("You win a new laptop!");}
else if(score == 7)  {Console.WriteLine("You win a trip for two!");}
else                 {Console.WriteLine("You win a kitten!");}
