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

string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };

Console.WriteLine("Student\t\tGrade\n");
int[] studentScores = new int[5];
foreach (string name in studentNames)
{
    switch(name)
    {
        case "Sophia":
            studentScores = sophiaScores;
            break;
        case "Andrew":
            studentScores = andrewScores;            
            break;
        case "Emma":
            studentScores = emmaScores;
            break;
        case "Logan":
            studentScores = loganScores;
            break;
        default:
            Console.WriteLine("ERR <----------------------------X");
            Console.ReadLine();
            break;
    }
    decimal studentGrade = (decimal) studentScores.Sum() / currentAssignments;
    Console.WriteLine($"{name}:\t\t" + studentGrade + "\t" + determineLetterGrade(studentGrade));
}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();

string determineLetterGrade(decimal grade) {
    string letterGrade = "";
    if (grade >= 90)
        letterGrade = "A";
    else if (grade >= 80)
        letterGrade = "B";
    else if (grade >= 70)
        letterGrade = "C";
    else if (grade >= 60)
        letterGrade = "D";
    else
        letterGrade = "F";

    grade = grade % 10;
    if (grade >= 7)
        letterGrade += "+";
    else if (grade < 3)
        letterGrade += "-";

    return letterGrade;
}