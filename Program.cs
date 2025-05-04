// See https://aka.ms/new-console-template for more information
Console.WriteLine("Time to get familiar with C#");

Random dice = new Random(); // Random dice = new();
int roll = dice.Next(1, 7);
Console.WriteLine("You rolled a " + roll);
Console.WriteLine(Math.Max(500, 600));