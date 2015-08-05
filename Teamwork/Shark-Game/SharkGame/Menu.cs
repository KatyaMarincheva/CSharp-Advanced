using System;

namespace SharksGame
{
    public class Intro
    {
        public static void Menu()
        {
            int MenuBarKeys = 0;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            bool menu = true;
            int mod = 0;
            while (menu)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (MenuBarKeys < 2)
                        {
                            MenuBarKeys++;
                        }

                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (MenuBarKeys > 0)
                        {
                            MenuBarKeys--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (MenuBarKeys == 0)
                        {
                            menu = false;
                        }
                        else if (MenuBarKeys == 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Use arrow keys to control SHARK.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Don't let the scary rocks hit you.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("They're standing still anyway.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Eat some nasty people that get in your way and you might get a second life");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Or third...");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Have a nice game experience!!!");
                            System.Threading.Thread.Sleep(3000);

                        }
                        else if (MenuBarKeys == 2)
                        {
                            Environment.Exit(0);
                        }

                    }
                }
                PrintSharkLogo(mod);
                PrintSharkLogo2(mod);
                MenuButtons(MenuBarKeys);
                MenuMargin(mod);
                System.Threading.Thread.Sleep(120);
                mod++;
                Console.Clear();
            }
        }
        

        public static void PrintOnPosition(int x, int y, string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void PrintSharkLogo(int mod)
        {
            string shark = @"    _________         .    .  
       (..       \_    ,  |\  /|
        \       0  \  /|  \ \/ /
         \______    \/ |   \  /
            vvvv\    \ |   /  |
            \^^^^  ==   \_/   |
             `\_   ===    \.  |
             / /\_   \ /      |
             |/   \_  \|      /
                    \________/";
            if (mod % 2 == 0)
            {
                PrintOnPosition(4, 4, shark, ConsoleColor.Cyan);

            }
            else
            {
                PrintOnPosition(4, 4, shark, ConsoleColor.Blue);

            }
        }
        public static void PrintSharkLogo2(int mod)
        {
            string logo = @".|'''|  '||  ||`      /.\      '||'''|, '||  //' 
             ||       ||  ||      // \\      ||   ||  || //   
             `|'''|,  ||''||     //...\\     ||...|'  ||<<    
              .   ||  ||  ||    //     \\    || \\    || \\   
              |...|' .||  ||. .//       \\. .||  \\. .||  \\.";
            if (mod % 2 == 0)
            {
                PrintOnPosition(13, 16, logo, ConsoleColor.Cyan);

            }
            else
            {
                PrintOnPosition(13, 16, logo, ConsoleColor.Blue);

            }
        }
        public static void MenuButtons(int modulation)
        {

            if (modulation == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
            }
            else if (modulation == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
            }
            else if (modulation == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
            }

        }
        public static void MenuMargin(int mod)
        {
            string UpAndDown = new string('=', 13);
            Console.SetCursorPosition(41, 4);
            Console.Write(UpAndDown);
            Console.SetCursorPosition(41, 12);
            Console.Write(UpAndDown);
        }

    }
}


