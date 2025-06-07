using System;
using System.Threading;


namespace BasicExperimentation
{
    public class FireWorks
    {
        // provided by ChatGPT for an intro to animating
        public static void StartShow()
        {
            Console.CursorVisible = false;
            Random rand = new Random();

            for (int firework = 0; firework < 5; firework++)
            {
                int x = rand.Next(10, Console.WindowWidth - 10);
                int height = rand.Next(5, Console.WindowHeight - 10);

                // Launch
                for (int y = Console.WindowHeight - 2; y > height; y--)
                {
                    Console.Clear();
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    Thread.Sleep(50);
                }

                // Explode
                Console.Clear();
                Console.ForegroundColor = GetRandomColor(rand);
                DrawExplosion(x, height);
                Thread.Sleep(500);
                Console.Clear();
            }

            Console.ResetColor();
            Console.CursorVisible = true;
            Console.WriteLine("🎆 Fireworks show over!");
        }

        static void DrawExplosion(int x, int y)
        {
            string[] explosion = {
                    "   *   ",
                    "  ***  ",
                    " ***** ",
                    "  ***  ",
                    "   *   "
                };

            for (int i = 0; i < explosion.Length; i++)
            {
                Console.SetCursorPosition(x - 3, y - 2 + i);
                Console.Write(explosion[i]);
            }
        }

        static ConsoleColor GetRandomColor(Random rand)
        {
            ConsoleColor[] colors = {
                    ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue,
                    ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Cyan
                };
            return colors[rand.Next(colors.Length)];
        }









        public static void StartShowWithoutClearing()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Random rng = new Random();

            for (int i = 0; i < 5; i++) // Number of fireworks
            {
                int x = rng.Next(10, width - 10);
                int y = rng.Next(5, height - 5);
                DrawFireworkBurst(x, y);
                Thread.Sleep(700);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void DrawFireworkBurst(int centerX, int centerY)
        {
            string[] pattern = new string[]
            {
                "   *   ",
                "  ***  ",
                " ***** ",
                "*** ***",
                " ***** ",
                "  ***  ",
                "   *   "
            };

            ConsoleColor[] colors = {
                ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow,
                ConsoleColor.Cyan, ConsoleColor.Green
            };

            foreach (ConsoleColor color in colors)
            {
                Console.ForegroundColor = color;
                for (int i = 0; i < pattern.Length; i++)
                {
                    int y = centerY - pattern.Length / 2 + i;
                    if (y >= 0 && y < Console.WindowHeight)
                    {
                        int x = centerX - pattern[i].Length / 2;
                        Console.SetCursorPosition(Math.Max(0, x), y);
                        Console.Write(pattern[i]);
                    }
                }
                Thread.Sleep(100);
            }

            Console.ResetColor();
        }
    }

}