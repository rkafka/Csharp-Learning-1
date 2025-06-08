

namespace GuidedProject5
{
    class GP5
    {

        // RJK constants
        const int MIN_Y = 1; // originally 0
        const int MIN_X = 0;
        // -------------

        public static void Execute(string[] args)
        {
            Utils.Helper.OutputTitle(" GUIDED PROJECT 5  >-<  MINI-GAME ");


            Random random = new Random();
            Console.CursorVisible = false;
            int height = Console.WindowHeight - 1;
            int width = Console.WindowWidth - 5;
            bool shouldExit = false;

            // Console position of the player
            int playerX = MIN_X;
            int playerY = MIN_Y;
            // Console position of the food
            int foodX = 0;
            int foodY = 0;
            // Available player and food strings
            string[] states = { "('-')", "(^-^)", "(X_X)" };
            string[] foods = { "@@@@@", "$$$$$", "#####" };

            // Current player string displayed in the Console
            string player = states[0];
            // Index of the current food
            int food = 0;

            InitializeGame();
            while (!shouldExit)
            {
                debugBar();
                shouldExit = Move();
                if (TerminalResized())
                {
                    Console.WriteLine("Console was resized. Program exiting.");
                    break;
                }
            }

            // Returns true if the Terminal was resized 
            bool TerminalResized()
            {
                return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
            }

            // Displays random food at a random location
            void ShowFood()
            {
                // RJK --
                int lastFoodX = foodX;
                int lastFoodY = foodY;
                Console.SetCursorPosition(lastFoodX, lastFoodY);
                for (int i = 0; i < player.Length; i++)
                {
                    Console.Write(" ");
                }
                // ------

                // Update food to a random index
                food = random.Next(0, foods.Length);

                // Update food position to a random location
                foodX = random.Next(MIN_X, width - player.Length);
                foodY = random.Next(MIN_Y, height - 1);

                // Display the food at the location
                Console.SetCursorPosition(foodX, foodY);
                Console.Write(foods[food]);
            }

            // Changes the player to match the food consumed
            void ChangePlayer()
            {
                player = states[food];
                // Clear the characters at the previous position
                int lastX = playerX;
                int lastY = playerY;
                Console.SetCursorPosition(lastX, lastY);
                for (int i = 0; i < player.Length; i++)
                {
                    Console.Write(" ");
                }
                // Keep player position within the bounds of the Terminal window
                playerX = (playerX < MIN_X) ? MIN_X : (playerX >= width ? width : playerX);
                playerY = (playerY < MIN_Y) ? MIN_Y : (playerY >= height ? height : playerY);

                // Draw the player at the new location
                Console.SetCursorPosition(playerX, playerY);
                // Console.SetCursorPosition(playerX, playerY);
                // Console.Write(player);
            }

            // Temporarily stops the player from moving
            void FreezePlayer()
            {
                System.Threading.Thread.Sleep(1000);
                player = states[0];
            }

            // Reads directional input from the Console and moves the player
            bool Move(bool increaseSpeed = false, bool banNonDirectionalInput = false)
            {
                int lastX = playerX;
                int lastY = playerY;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        playerY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        break;
                    case ConsoleKey.Escape:
                        shouldExit = true;
                        break;
                    default:
                        shouldExit = true;
                        Console.WriteLine("Nondirectional input detected. Program exiting.");
                        break;
                }

                // Clear the characters at the previous position
                Console.SetCursorPosition(lastX, lastY);
                for (int i = 0; i < player.Length; i++)
                {
                    Console.Write(" ");
                }

                // Keep player position within the bounds of the Terminal window
                playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
                // playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);
                playerY = (playerY < MIN_Y) ? MIN_Y : (playerY >= height ? height : playerY);

                // Draw the player at the new location
                Console.SetCursorPosition(playerX, playerY);

                // if(playerX == foodX && playerY == foodY) 
                // -- // if middlepoint of both player & food are the same
                // if ((playerX >= foodX - 2) && (playerX <= foodX + 2) && (playerY == foodY))
                // -- // if any of the player's 5-character-body overlaps with the midpoint
                // if((playerX-2 >= foodX -2) && (playerX+2 <= foodX+2) && (playerY == foodY))
                if ((playerX + 4 >= foodX) && (playerX - 4 <= foodX) && (playerY == foodY))
                {
                    // Console.SetCursorPosition(0, 0);
                    // Console.Write($"PLAYER: {playerX},{playerY}  |  FOOD: {foodX},{foodY}  |".PadRight(Console.WindowWidth, '-'));
                    // Thread.Sleep(1000);
                    // Console.SetCursorPosition(playerX, playerY);

                    ShowFood();
                    ChangePlayer();
                }

                Console.Write(player);

                // RJK ---
                return shouldExit;
            }

            // Clears the console, displays the food and player
            void InitializeGame()
            {
                Console.Clear();
                // RJK --
                playStartUpAnimation();
                // ------
                ShowFood();
                Console.SetCursorPosition(MIN_X, MIN_Y);
                Console.Write(player);
            }




            bool checkIfPlayerTired()
            {
                if (player == "(X_X)")
                {
                    FreezePlayer();
                    return true;
                }

                return false;
            }

            bool checkIfPlayerHappy()
            {
                if (player == "(^-^)")
                {
                    FreezePlayer();
                    return true;
                }

                return false;
            }

            void debugBar()
            {
                string coordinateDisplay = $"|  SNACKER BOY  |  PLAYER:  {playerX}, {playerY}  |  FOOD:  {foodX}, {foodY}  |";
                Console.SetCursorPosition(0, 0);
                Console.Write(coordinateDisplay.PadRight(Console.WindowWidth, '-'));
                // Thread.Sleep(1000); // debug option
                Console.SetCursorPosition(playerX, playerY);
            }
            
            void playStartUpAnimation()
            {
                //
                int animationTime = 50; // ms
                string welcomeMessage = $"Welcome to the game!  :) ";
                foreach (char letter in welcomeMessage)
                {
                    Console.Write(letter);
                    Thread.Sleep(animationTime);
                }
                // pause for effect
                Thread.Sleep(animationTime*10);
                // delete letter by letter
                int pos = welcomeMessage.Length; // index of how many characters need to be deleted
                while (pos > 0) {
                    // move back, replace with space, move back again
                    Console.Write("\b \b");
                    Thread.Sleep(animationTime);
                }
                // write debugBar();
                string coordinateDisplay = $"|  SNACKER BOY  |  PLAYER:  {playerX}, {playerY}  |  FOOD:  {foodX}, {foodY}  |".PadRight(Console.WindowWidth,'-');
                foreach (char letter in coordinateDisplay)
                {
                    Console.Write(letter);
                    Thread.Sleep(animationTime);
                }
            }

        }
    }
}