using System;

namespace GuidedProject1_RJK {
    class GuidedProject1 {
        // function to determine letter grade
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

        static void Main(string[] args) {
            // initialize variables - graded assignments 
            int currentAssignments = 5;

            int[] sophiaScores = {90, 86, 87, 98, 100};
            int[] andrewScores = {92, 89, 81, 96, 90};
            int[] emmaScores =   {90, 85, 87, 98, 68};
            int[] loganScores =  {90, 95, 87, 88, 96};

            string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };

            int[] sophiaExtraCredit = {94, 90, 0};
            int[] andrewExtraCredit = {89, 0,  0};
            int[] emmaExtraCredit =   {89, 89, 89};
            int[] loganExtraCredit =  {96, 0,  0};

            Console.WriteLine("Student\t\tGrade\n");
            int[] studentScores = new int[5];
            int[] extraCreditScores = new int[3];
            foreach (string name in studentNames)
            {
                switch(name)
                {
                    case "Sophia":
                        studentScores = sophiaScores;
                        extraCreditScores = sophiaExtraCredit;
                        break;
                    case "Andrew":
                        studentScores = andrewScores;  
                        extraCreditScores = andrewExtraCredit;          
                        break;
                    case "Emma":
                        studentScores = emmaScores;
                        extraCreditScores = emmaExtraCredit;
                        break;
                    case "Logan":
                        studentScores = loganScores;
                        extraCreditScores = loganExtraCredit;
                        break;
                    default:
                        Console.WriteLine("ERR <----------------------------X");
                        Console.ReadLine();
                        break;
                }
                decimal adjustedSum = (decimal) studentScores.Sum() + (extraCreditScores.Sum()*.1m);
                decimal studentGrade = adjustedSum / currentAssignments;
                GuidedProject1 gp1 = new GuidedProject1();
                Console.WriteLine($"{name}:\t\t" + studentGrade + "\t" + gp1.determineLetterGrade(studentGrade));
            }

            Console.WriteLine("Press the Enter key to continue");
            Console.ReadLine();
        }
    }

    
}