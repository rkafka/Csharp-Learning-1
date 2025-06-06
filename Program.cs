// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Time to get familiar with C#");

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.VisualBasic;
using primary;

Console.WriteLine();
// CastingAndConverting.Execute(args);
// ArrayOperations.Execute(args);
// formatAlphaNumericData.Execute(args);
modifyStringsWithBuiltInMethods.Execute(args);
Console.WriteLine();

/* TO RUN: "dotnet build ; dotnet run" */


namespace primary {

    class modifyStringsWithBuiltInMethods
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine("Modifying Strings with Built-In Methods [] > ...\n");
            // indexOfAndSubstring();
            // Console.WriteLine();
            // indexOfAndLastIndexOf();
            // Console.WriteLine();
            // RemoveAndReplace();
            ExtractReplaceRemove();
            Console.WriteLine();
        }

        static void ExtractReplaceRemove()
        {
            const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";
            string quantity = "";
            string output = "";

            // Your work here
            // char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int openingPosition = input.IndexOf("<span>") + "<span>".Length;
            int closingPosition = input.IndexOf("</span>");
            quantity = input.Substring(openingPosition, closingPosition-openingPosition);

            output = input.Remove(input.IndexOf("<div>"), "<div>".Length);
            output = output.Replace("</div>", "");
            output = output.Replace("trade", "reg");
            //

            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Output:   " + output);
        }

        static void RemoveAndReplace()
        {
            // Remove() to get rid of John Smith and its following padding
            string data = "12345John Smith          5000  3  ";
            string updatedData = data.Remove(5, 20);
            Console.WriteLine(updatedData);

            // Replace() to replace instances of "--" with "-" and "-" with nothing
            string message = "This--is--ex-amp-le--da-ta";
            message = message.Replace("--", " ");
            message = message.Replace("-", "");
            Console.WriteLine(message);
        }

        static void indexOfAndLastIndexOf()
        {
            string message = "hello there!";
            int firstH = message.IndexOf('h');
            int lastH = message.LastIndexOf('h');
            Console.WriteLine($"For the message: '{message}', the first 'h' is at position {firstH} and the last 'h' is at position {lastH}.");
            Console.WriteLine();

            message = "(What if) I am (only interested) in the last (set of parentheses)?";
            int openingPosition = message.LastIndexOf('(') + "(".Length;
            int closingPosition = message.LastIndexOf(')');
            int length = closingPosition - openingPosition;
            Console.WriteLine($"Getting last from: '{message}'");
            Console.WriteLine(message.Substring(openingPosition, length) + "\n");

            while (message.Contains('('))
            {
                openingPosition = message.IndexOf('(') + "(".Length;
                if (openingPosition >= message.Length | openingPosition == -1 | openingPosition == 0)
                    break;
                closingPosition = message.IndexOf(')');
                // take out substring from message and output current results
                string result = message.Substring(openingPosition, closingPosition - openingPosition);
                message = message.Substring(closingPosition + 1).TrimStart(); // increment once to escape closing parenthesis
                Console.WriteLine($"{result.PadRight(18)} << remaining message:   {message}");
            }
            Console.ReadLine();


            message = "Help (find) the {opening symbols}";
            Console.WriteLine($"Searching THIS Message: {message}");
            char[] openSymbols = { '[', '{', '(' };
            int startPosition = 5;

            openingPosition = message.IndexOfAny(openSymbols);
            Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");
            openingPosition = message.IndexOfAny(openSymbols, startPosition);
            Console.WriteLine($"Found WITH using startPosition {startPosition}:  {message.Substring(openingPosition)}");



            message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
            // The IndexOfAny() helper method requires a char array of characters. 
            // You want to look for:
            openSymbols = new char[] { '[', '{', '(' };
            // You'll use a slightly different technique for iterating through 
            // the characters in the string. This time, use the closing 
            // position of the previous iteration as the starting index for the 
            //next open symbol. So, you need to initialize the closingPosition 
            // variable to zero:
            closingPosition = 0;

            while (true)
            {
                openingPosition = message.IndexOfAny(openSymbols, closingPosition);
                if (openingPosition == -1) break;
                string currentSymbol = message.Substring(openingPosition, 1);

                // Now  find the matching closing symbol
                char matchingSymbol = ' ';
                switch (currentSymbol)
                {
                    case "[":
                        matchingSymbol = ']';
                        break;
                    case "{":
                        matchingSymbol = '}';
                        break;
                    case "(":
                        matchingSymbol = ')';
                        break;
                }

                // To find the closingPosition, use an overload of the IndexOf method to specify 
                // that the search for the matchingSymbol should start at the openingPosition in the string. 
                openingPosition += 1;
                closingPosition = message.IndexOf(matchingSymbol, openingPosition);

                // Finally, use the techniques you've already learned to display the sub-string:
                length = closingPosition - openingPosition;
                Console.WriteLine(message.Substring(openingPosition, length));
            }

        }

        static void indexOfAndSubstring()
        {
            string msg = "Find what is (inside the parantheses) desired.";

            int openingPosition = msg.IndexOf('(');
            int closingPosition = msg.IndexOf(')');

            openingPosition += 1;
            int lengthToSubstr = closingPosition - openingPosition;

            Console.WriteLine($"{openingPosition}, {closingPosition}:\t\"{msg.Substring(openingPosition, lengthToSubstr)}\"");


            const string openSpan = "<span>";
            const string closeSpan = "</span>";

            msg = "What is the value <span>between the tags</span> as you understand it?";
            openingPosition = msg.IndexOf(openSpan);
            closingPosition = msg.IndexOf(closeSpan);
            openingPosition += openSpan.Length;
            lengthToSubstr = closingPosition - openingPosition;
            Console.WriteLine($"{openingPosition}, {closingPosition}:\t\"{msg.Substring(openingPosition, lengthToSubstr)}\"");
        }
    }

    class formatAlphaNumericData
    {
        public static void Execute(string[] args)
        {
            string breakLine = "".PadRight(40);

            //
            // StringFormattingBasics();
            // Console.WriteLine(breakLine);

            // PaddingAndAlignment();
            // Console.WriteLine(breakLine);

            //
            StringInterpolationToFormLetter();
        }

        static void StringInterpolationToFormLetter()
        {
            string customerName = "Ms. Barros";
            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            // Your logic here
            string message = $"Dear {customerName},\n\n";
            message += $"As a customer of our {currentProduct} offering we are excited to tell you about a new \nfinancial product that would dramatically increase your return.\n\n";
            message += $"Currently, you own {currentShares:N2} at a return of {currentReturn:P2}.\n\n";
            message += $"Our new product, {newProduct} offers a return of {newReturn:P2}. ";
            message += $"Given your current \nvolume, your potential profit would be {newProfit:C2}.\n\n";
            Console.Write(message);
            //

            Console.WriteLine("Here's a quick comparison:\n");

            string comparisonMessage = "";

            // Your logic here
            comparisonMessage += currentProduct.PadRight(20) + $"{currentReturn:P2}".PadRight(10) + $"{currentProfit:C2}\n";
            comparisonMessage += newProduct.PadRight(20) + $"{newReturn:P2}".PadRight(10) + $"{newProfit:C2}";
            //

            Console.WriteLine(comparisonMessage);
        }

        static void PaddingAndAlignment()
        {
            // Intro to padding
            string input = "Pad this";
            Console.WriteLine(input.PadLeft(12));
            Console.WriteLine(input);
            Console.WriteLine(input.PadLeft(5));
            Console.WriteLine(input.PadRight(12) + input + "\n");
            // Overloaded version
            Console.WriteLine(input.PadLeft(12, '-'));
            Console.WriteLine(input.PadRight(12, '-') + "\n");

            //
            string paymentID = "769C";
            string payeeName = "Mr. George Romero";
            decimal paymentAmount = 5000.00m;
            var formattedLine = paymentID.PadRight(6);
            formattedLine += payeeName.PadRight(24);
            formattedLine += $"{paymentAmount:C2}".PadLeft(10);
            Console.WriteLine("".PadLeft(40, '-'));
            Console.WriteLine(formattedLine);
        }

        static void StringFormattingBasics()
        {
            string first = "Hello";
            string second = "World";
            string result = string.Format("{0} {1}!", first, second);
            Console.WriteLine(result);
            Console.WriteLine("{0} {0} {1} {0} -test", first, second);
            Console.WriteLine($"{first} {second}");

            decimal price = 123.45m;
            int discount = 50;
            Console.WriteLine($"Price: {price:C} (Save {discount:C})");
            decimal measurement = 123456.78912m;
            Console.WriteLine($"Measurement: {measurement:N2} units");

            decimal tax = .36785m;
            Console.WriteLine($"Tax rate: {tax:P}");

            Console.WriteLine();
            price = 67.55m;
            decimal salePrice = 59.99m;
            string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price.", (price - salePrice), price);
            Console.WriteLine(yourDiscount);
        }
    }

    class ArrayOperations
    {
        public static void Execute(string[] args)
        {
            // SortAndReverse();
            // ClearAndResize();
            // SplitAndJoin();
            // ReverseWordsInASentence();
            ParseSortTagOrders();

        }

        static void ParseSortTagOrders()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            //
            string[] orders = orderStream.Split(",");
            //
            Array.Sort(orders);
            //
            foreach (string order in orders)
            {
                Console.WriteLine($"{order}{(order.Length == 4 ? "" : "\t- Error")}");
            }
        }

        static void ReverseWordsInASentence()
        {
            string pangram = "The quick brown fox jumps over the lazy dog";
            // split from full setnence in substrings of each word
            string[] words = pangram.Split(" ");
            // reverse the words
            string[] reversedWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)// word in words)
            {
                char[] cArray = words[i].ToCharArray();
                Array.Reverse(cArray);
                reversedWords[i] = String.Join("", cArray);
            }
            // join the reveresed words together
            string result = String.Join(" ", reversedWords);
            // output
            Console.WriteLine(result);
        }

        static void SplitAndJoin()
        {
            // Reversing 
            string value = "abc123";
            char[] valueArray = value.ToCharArray();
            Array.Reverse(valueArray);
            string result = new string(valueArray);
            Console.WriteLine(result);

            result = string.Join(",", valueArray);
            Console.WriteLine(result);

            string[] items = result.Split(',');
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }

        static void ClearAndResize()
        {
            string[] pallets = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("Before: " + pallets[0]);

            Array.Clear(pallets, 0, 2);
            Console.WriteLine("After: " + pallets[0] + "\n");

            Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            if (pallets[0] != null)
                Console.WriteLine("\n" + pallets[0].ToLower());
            else
                Console.WriteLine("\nOh no darn it failed (as expected).");

            Array.Resize(ref pallets, 6);
            Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");
            pallets[4] = "C01";
            pallets[5] = "C02";
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Array.Resize(ref pallets, 3);
            Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");

        }

        static void SortAndReverse()
        {
            string[] pallets = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("Original:");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Console.WriteLine("\nSorted...");
            Array.Sort(pallets);
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Console.WriteLine("\nReversed...");
            Array.Reverse(pallets);
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }
        }
    }

    class CastingAndConverting
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine("[] Casting and Converting in C# [] > | . . .\n");

            // WhyCastingAndStrings();
            // CastingVsConverting();
            // TryParsing();
            // miniChallenge1();
            miniChallenge2();


        }

        static void miniChallenge2()
        {
            int value1 = 11;
            decimal value2 = 6.2m;
            float value3 = 4.3f;

            // Your code here to set result1
            int result1 = Convert.ToInt32(value1 / value2);
            // Hint: You need to round the result to nearest integer (don't just truncate)
            Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

            // Your code here to set result2
            decimal result2 = value2 / (decimal)value3;
            //
            Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

            // Your code here to set result3
            float result3 = value3 / value1;
            //
            Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
        }

        static void miniChallenge1()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };

            /* RULES:
                1) IF the value is alphabetical, concatenate into a message
                2) IF the value is numeric, add it to the total
            */
            string message = "";
            decimal total = 0m;

            foreach (string value in values)
            {
                if (decimal.TryParse(value, out decimal number))
                    total += number;
                else
                    message += value;
            }

            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Total: {total}");

        }

        static void TryParsing()
        {
            // WILL CAUSE AN EXCEPTION
            // string name = "Bob";
            // Console.WriteLine(int.Parse(name)); // throws FormatException
            // ➥ System.FormatException: 'Input string was not in a correct format.'

            string value = "102";
            int result = -1;
            //
            if (int.TryParse(value, out result))
            {
                Console.WriteLine($"Parsed value: {result}");
            }
            else
            {
                Console.WriteLine("Failed to parse the value.");
            }
            Console.WriteLine($"Result+50 = {result + 50}\n");

            value = "CAN'T PARSE THIS";
            result = -1;
            // TryParse will not throw an exception, but will return false
            if (int.TryParse(value, out result))
            {
                Console.WriteLine($"Parsed value: {result}");
            }
            else
            {
                Console.WriteLine("Failed to parse the value.");
            }
            if (result >= 0)
                Console.WriteLine($"Result+50 = {result + 50}");

        }

        static void WhyCastingAndStrings()
        {
            int first = 2;
            string second = "4";
            string result = first + second;
            Console.WriteLine("string = int + string  -->  " + result + "\n");

            decimal myDecimal = 1.23456789m;
            float myFloat = (float)myDecimal;
            Console.WriteLine($"Decimal: {myDecimal}");
            Console.WriteLine($"Float  : {myFloat}\n");

            int first2 = 5;
            int second2 = 7;
            string result2 = first2.ToString() + second2.ToString();
            Console.WriteLine($"ToString -> {result2}");
            string value1 = "5";
            string value2 = "7";
            int resultC = Convert.ToInt32(value1) * Convert.ToInt32(value2);
            Console.WriteLine($"Convert.ToInt32() -> {resultC}");
        }

        static void CastingVsConverting()
        {
            // Casting vs Converting
            Console.WriteLine("Casting vs Converting:");
            // Casting is a direct conversion, which truncates decimal values
            Console.WriteLine("\t[Casting]");
            int valCasted1 = (int)1.5m; // casting, truncates
            Console.WriteLine("\t\t(int)1.5m  \t\t   = " + valCasted1);
            int valCasted2 = (int)1.99m; // casting, truncates
            Console.WriteLine("\t\t(int)1.99m \t\t   = " + valCasted2);
            // Converting w/ Convert.ToInt32() rounds the value to the nearest whole number
            Console.WriteLine("\t[Converting]");
            int valConverted1 = Convert.ToInt32(1.5m); // converting, rounds (up in this case)
            Console.WriteLine("\t\tConvert.toInt32(1.5m)      = " + valConverted1);
            int valConverted2 = Convert.ToInt32(1.499999m); // converting, rounds (down in this case)
            Console.WriteLine("\t\tConvert.toInt32(1.499999m) = " + valConverted2);
        }
    }
}


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

namespace WorkWithVariableData
{
    class Program
    {
        static void Execute(string[] args)
        {
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
        static void integralTypes()
        {

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

        static void floatingPointTypes()
        {
            Console.WriteLine("Floating point types:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
            Console.WriteLine("");
        }
        static void referenceTypes()
        {
            int val_A = 2;
            int val_B = val_A;
            val_B = 5;

            Console.WriteLine("--Value Types--");
            Console.WriteLine($"val_A: {val_A}");
            Console.WriteLine($"val_B: {val_B}");

            int[] ref_A = new int[1];
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
            string? permission = Console.ReadLine();
            if(permission == null || permission.Length == 0)
                permission = "Admin|Manager";
            Console.WriteLine($"You entered {((permission=="Admin|Manager")?"(default) ":"")}{permission}");
            // gathering integer for level (no validation)
            Console.Write("Enter a level: "); 
            string? levelInput = Console.ReadLine();
            int? level = null;
            if (!string.IsNullOrEmpty(levelInput))
            {
                level = int.Parse(levelInput);
            }
            else
            {
                Console.WriteLine("No input provided. Defaulting level to 0.");
                level = 0;
            }
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

