using System;
using System.Collections.Generic;
using System.Threading;

namespace SharkGame
{
    class Drawer
    {
// Public fields
        struct Point
        {
            public int X;
            public int Y;
        }
        public static bool gameplay = true;
        public static List<FoodAndRocks> Food = new List<FoodAndRocks>();
        public static List<FoodAndRocks> Rocks = new List<FoodAndRocks>();
        public static int PlayfieldWidth = 69;
        public static int PlayfieldHight = 24;
        public static int Score = 0;
        public static FoodAndRocks newFood;
        public static bool Hitted = false;
        public static FoodAndRocks rock = new FoodAndRocks(0, 0, "A", ConsoleColor.Gray);
        public static void Draw()
        {
// Declarations           
            Random randomGenerator = new Random();
            Console.CursorVisible = false;
            string sharkRight = ">-==^=:>";
            string sharkLeft = "<-==^=:<";
            char[] sharkR = sharkRight.ToCharArray();
            char[] sharkL = sharkLeft.ToCharArray();
            string sharkDown = "V#>\"V";
            string sharkUp = "^#<\"^";
            char[] sharkD = sharkDown.ToCharArray();
            char[] sharkU = sharkUp.ToCharArray();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

// Settings: 
            int modMovement = 0;
            int x = 0;
            int y = 5;


            while (gameplay)
            {

            // change movement direction
                if (Console.KeyAvailable)
                {
                    modMovement = ChooseModMovement(modMovement, ref gameplay);
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.Clear();

// Draw Shark !!
                int x1 = x;
                if (modMovement == 0)
                {
                    x1 = Mode0XSharkDrawer(x1, y, sharkR);
                }
                if (modMovement == 1)
                {
                    // the Shark's nose also detects the hits
                    x1 = Mode1XSharkDrawerAndHitsDetector(x1, y, sharkL);
                }
                if (modMovement == 2)
                {
                    y = Mode2YSharkDrawerAndHitsDetector(x1, y, sharkU);
                }
                if (modMovement == 3)
                {
                    y = Mode3YSharkDrawerAndHitsDetector(x1, y, sharkD);
                }
                x = x1;

                // generate food and rocks and track hits
                Hitted = false;
                {
                    ChanceGenerator(randomGenerator);
                }

                // adds new food 
                GenerateNewFoodList(PlayfieldWidth);

// Details Drawer - print food, rocks and playfield are Drawer methods main part - the rest is just settings

                // draw bottom up frames, and score
                DrawFrameworkTopAndBottom();
                PrintOnPosition(75, 6, "Score: " + Score, ConsoleColor.White);

                // draw rocks and food
                foreach (FoodAndRocks item in Food)
                {
                    PrintOnPosition(item.X, item.Y, item.S, item.color);

                }
                foreach (FoodAndRocks rock in Rocks)
                {
                    PrintOnPosition(rock.X, rock.Y, rock.S, rock.color);

                }

                // draw the rest of the playfieldplayfiled - using foreach instead of a for loop reduces the framwork trembling
                List<Point> left = new List<Point>();
                List<Point> right = new List<Point>();
                CalculateFrameworkLeftSide(left);
                CalculateFrameworkRightSide(right);      
        
                PrintFrameworkLeftRight(left, right);

                Thread.Sleep(80);
            }

            // if gameplay = false -> end game
            PrintOnPosition(75, 10, "GAME OVER!!!", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.White;
            PrintOnPosition(25, 26, "Press [enter]to exit", ConsoleColor.White);
            Music.Play();
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void ChanceGenerator(Random randomGenerator)
        {
// chance generator
            int chance = randomGenerator.Next(0, 100);

            // generate rocks
            if (chance <= 2 || chance > 45 && chance <= 47 || chance > 65 && chance <= 67)
            {
                GenerateNewRocks(randomGenerator, PlayfieldWidth, PlayfieldHight);
            }

            else if (chance > 20 && chance <= 62)
            {
                GenerateNewFood(randomGenerator, PlayfieldHight, "@");
            }
        }

        private static void PrintFrameworkLeftRight(List<Point> left, List<Point> right)
        {
            foreach (var point in left)
            {
                PrintFrameworkSides(point);
            }

            foreach (var point in right)
            {
                PrintFrameworkSides(point);
            }
        }

        private static void CalculateFrameworkLeftSide(List<Point> left)
        {
            for (int i = 0; i < 25; i++)
            {
                Point a = new Point();
                a.X = 0;
                a.Y = i;
                left.Add(a);
            }
        }

        private static void CalculateFrameworkRightSide(List<Point> right)
        {
            for (int i = 0; i < 25; i++)
            {
                Point a = new Point();
                a.X = 70;
                a.Y = i;
                right.Add(a);
            }
        }

        private static void DrawFrameworkTopAndBottom()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string('■', 70));
            Console.SetCursorPosition(0, 24);
            Console.WriteLine(new string('■', 70));
        }

        private static void PrintFrameworkSides(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write('■');
        }

        private static void GenerateNewFood(Random randomGenerator, int playfieldHight, string foodType)
        {
            newFood = new FoodAndRocks(0, randomGenerator.Next(2, playfieldHight-2), foodType, ConsoleColor.Red);

            if (Food.Count < 6)
            {
                Food.Add(newFood);
            }

            Score++;
        }

        private static void GenerateNewRocks(Random randomGenerator, int playfieldWidth, int playfieldHight)
        {
            rock = new FoodAndRocks(randomGenerator.Next(2, playfieldWidth-2),
                randomGenerator.Next(2, playfieldHight-2), "A", ConsoleColor.Gray);
            
            if (Rocks.Count < 6)
            {
                Rocks.Add(rock);
            }
        }

        private static void GenerateNewFoodList(int playfieldWidth)
        {
            List<FoodAndRocks> newList = new List<FoodAndRocks>();
            for (int i = 0; i < Food.Count; i++)
            {
                FoodAndRocks oldFood = Food[i];
                FoodAndRocks newFood = new FoodAndRocks(oldFood.X, oldFood.Y, oldFood.S, oldFood.Color);
                if (oldFood.X + 1 <= playfieldWidth)
                {
                    newFood.X = oldFood.X + 1;
                }

                if (newFood.X < playfieldWidth && newList.Count < 20)
                {
                    newList.Add(newFood);
                }
            }
            Food = newList;
        }

        private static int Mode3YSharkDrawerAndHitsDetector(int x, int y, char[] sharkD)
        {
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < sharkD.Length; i++)
            {
                if (y == PlayfieldHight - 2)
                {
                    y = 4;
                }
                y++;

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkD[i]);
                Console.SetCursorPosition(x, y);
            }
            HitsDetectorY(x, y);
            y = y - 4;
            return y;
        }

        private static int Mode2YSharkDrawerAndHitsDetector(int x, int y, char[] sharkU)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < sharkU.Length; i++)
            {
                if (y == 1)
                {
                    y = PlayfieldHight - 4;
                }
                y--;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkU[i]);
                Console.SetCursorPosition(x, y);
            }
            HitsDetectorY(x, y);
            y = y + 4;
            return y;
        }

        private static int Mode1XSharkDrawerAndHitsDetector(int x, int y, char[] sharkL)
        {
            if (x == 0)
            {
                x = 62;
            }
            Console.SetCursorPosition(x, y);
            for (int i = sharkL.Length - 1; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkL[i]);
            }
            HitsDetectorX(x, y);
            x--;
            return x;
        }

        private static void HitsDetectorX(int x, int y)
        {
            for (int i = 0; i < Food.Count; i++)
            {
                if ((x == Food[i].X || x == Food[i].X - 1 || x == Food[i].X + 1) && y == Food[i].Y)
                {
                    Hitted = true;
                    Score += 40000;
                    Food.Remove(Food[i]);
                    Thread thread = new Thread(Music.Play);
                    thread.Start();
                }
            }
            for (int j = 0; j < Rocks.Count; j++)
            {
                if ((x == Rocks[j].X || x == Rocks[j].X - 1 || x == Rocks[j].X + 1) && y == Rocks[j].Y)
                {
                    gameplay = false;
                }
            }
        }

        private static void HitsDetectorY(int x, int y)
        {
            for (int i = 0; i < Food.Count; i++)
            {
                if ((y == Food[i].Y || y == Food[i].Y - 1 || y == Food[i].Y + 1) && x == Food[i].X)
                {
                    Hitted = true;
                    Score += 40000;
                    Food.Remove(Food[i]);
                    Thread thread = new Thread(Music.Play);
                    thread.Start();
                }
            }
            for (int j = 0; j < Rocks.Count; j++)
            {
                if ((y == Rocks[j].Y || y == Rocks[j].Y - 1 || y == Rocks[j].Y + 1) && x == Rocks[j].X)
                {
                    gameplay = false;
                }
            }
        }

        private static int Mode0XSharkDrawer(int x, int y, char[] sharkR)
        {
            if (x == 62)
            {
                x = 0;
            }
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < sharkR.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkR[i]);
            }
            x++;

            return x;
        }

        private static int ChooseModMovement(int modMovement, ref bool gameplay)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                modMovement = 0;
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                modMovement = 1;
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                modMovement = 2;
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                modMovement = 3;
            }
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                gameplay = false;
                Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    gameplay = true;
                }
            }
            return modMovement;
        }

        public static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(s);
        }
    }
}
