using System;

class StuckNumbers
{
    static void Main(string[] args)
    {
        // input
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

        // logic
        bool stuckNums = false;
        for (int p1 = 0; p1 < n; p1++)
        {
            for (int p2 = 0; p2 < n; p2++)
            {
                for (int p3 = 0; p3 < n; p3++)
                {
                    for (int p4 = 0; p4 < n; p4++)
                    {
                        if (p1 != p2 && p1 != p3 && p1 != p4 && p2 != p3 && p2 != p4 && p3 != p4)
                        {
                            // output option 1
                            stuckNums = CheckForStuckNumbers(numbers, p1, p2, p3, p4, stuckNums);
                        }
                    }
                }
            }
        }

        // ouput option 2
        if (!stuckNums)
        {
            Console.WriteLine("No");
        }
    }

    private static bool CheckForStuckNumbers(string[] numbers, int p1, int p2, int p3, int p4, bool stuckNums)
    {
        string left = numbers[p1] + numbers[p2];
        string right = numbers[p3] + numbers[p4];
        if (left == right)
        {
            PrintStuckNumbers(numbers, p1, p2, p3, p4);
            stuckNums = true;
        }
        return stuckNums;
    }

    private static void PrintStuckNumbers(string[] numbers, int p1, int p2, int p3, int p4)
    {
        Console.WriteLine("{0}|{1}=={2}|{3}", numbers[p1], numbers[p2], numbers[p3], numbers[p4]);
    }
}
