/* Exercise 1 from lecture 2: Многомерни масиви, речници, множества */

using System;

class PrintTriangle
{
    static void Main()
    {
        // input 
        int n = int.Parse(Console.ReadLine());

        // invoking the method
        DrawTriangle(n);
    }

    private static void DrawTriangle(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("{0} ", j);
            }
            Console.WriteLine();
        }
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("{0} ", j);
            }
            Console.WriteLine();
        }
    }
}



