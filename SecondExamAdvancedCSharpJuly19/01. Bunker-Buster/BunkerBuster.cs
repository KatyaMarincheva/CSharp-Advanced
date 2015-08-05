namespace _01.Bunker_Buster
{
    using System;
    using System.Linq;

    class BunkerBuster
    {
        private static int bombRow;
        private static int bombColumn;
        private static int bombPower;
        private static double damagePower;
        private static int destroyedBunkersCount = 0;
        private static double damageDone = 0;

        static void Main()
        {
            int[] spotDimetions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = spotDimetions[0];
            int m = spotDimetions[1];

            int[][] spot = new int[n][];

            for (int i = 0; i < n; i++)
            {
                spot[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "cease fire!")
                {
                    break;
                }

                string[] commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bombRow = int.Parse(commandArgs[0]);
                bombColumn = int.Parse(commandArgs[1]);
                bombPower = (int)commandArgs[2][0];
                damagePower = Math.Round((double)bombPower / 2, 0, MidpointRounding.AwayFromZero);

                ApplyDamage(n, m, spot);
            }

            // PrintSpotMatrix(n, m, spot);

            AssessDamage(n, m, spot);

            damageDone = ((double)destroyedBunkersCount / (n * m)) * 100;

            Console.WriteLine("Destroyed bunkers: {0}{1}Damage done: {2} %", destroyedBunkersCount, Environment.NewLine, damageDone.ToString("F1"));
        }

        private static void AssessDamage(int n, int m, int[][] spot)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (spot[row][col] <= 0)
                    {
                        destroyedBunkersCount++;
                    }
                }
            }
        }

        private static void ApplyDamage(int n, int m, int[][] spot)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (!IsInsideBombRadius(row, col, bombRow, bombColumn))
                    {
                        continue;
                    }

                    if (row == bombRow && col == bombColumn)
                    {
                        spot[row][col] -= bombPower;
                    }
                    else
                    {
                        spot[row][col] -= (int) damagePower;
                    }
                }
            }
        }

        private static void PrintSpotMatrix(int n, int m, int[][] spot)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write("{0} ", spot[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInsideBombRadius(int row, int col, int bombRow, int bombCol)
        {
            return
                (row <= bombRow + 1 && row >= bombRow - 1)
                && (col <= bombCol + 1 && col >= bombCol - 1);
        }
    }
}