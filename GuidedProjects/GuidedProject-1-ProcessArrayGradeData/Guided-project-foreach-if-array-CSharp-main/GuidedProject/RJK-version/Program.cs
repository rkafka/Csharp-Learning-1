using System;

// initialize variables - graded assignments 
int currentAssignments = 5;

int[] sophiaScores = {90, 86, 87, 98, 100};
int[] andrewScores = {92, 89, 81, 96, 90};
int[] emmaScores =   {90, 85, 87, 98, 68};
int[] loganScores =  {90, 95, 87, 88, 96};

decimal sophiaGrade = (decimal) sophiaScores.Sum() / currentAssignments;
decimal andrewGrade = (decimal) andrewScores.Sum() / currentAssignments;
decimal emmaGrade   = (decimal) emmaScores.Sum()   / currentAssignments;
decimal loganGrade  = (decimal) loganScores.Sum()  / currentAssignments;

Console.WriteLine("Student\t\tGrade\n");
Console.WriteLine("Sophia:\t\t" + sophiaGrade + "\tA-");
Console.WriteLine("Andrew:\t\t" + andrewGrade + "\tB+");
Console.WriteLine("Emma:\t\t" + emmaGrade + "\tB");
Console.WriteLine("Logan:\t\t" + loganGrade + "\tA-");

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
