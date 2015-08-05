/* Problem 8 – *Lego Blocks
This problem is from the Java Basics Exam (8 February 2015). You may check your solution here.
You are given two jagged arrays. Each array represents a Lego block containing integers. 
 * Your task is first to reverse the second jagged array and then check if it would fit perfectly in the first jagged array.  
The picture above shows exactly what fitting arrays mean. If the arrays fit perfectly 
 * you should print out the newly made rectangular matrix. If the arrays do not match (they do not form a rectangular matrix) 
 * you should print out the number of cells in the first array and in the second array combined. The examples below should help you understand the assignment better.
Input
The first line of the input comes as an integer number n saying how many rows are there in both arrays. 
 * Then you have 2 * n lines of numbers separated by whitespace(s). The first n lines are the rows of the first jagged array; 
 * the next n lines are the rows of the second jagged array. There might be leading and/or trailing whitespace(s).
Output
You should print out the combined matrix in the format:
[elem, elem, …, elem]
[elem, elem, …, elem]
[elem, elem, …, elem]
If the two arrays do not fit you should print out : The total number of cells is: count
Constraints
•	The number n will be in the range [2 … 10].
•	Time limit: 0.3 sec. Memory limit: 16 MB.
Examples
Input	                Output
2
1 1 1 1 1 1
2 1 1 3
1 1
2 2 2 3	                [1, 1, 1, 1, 1, 1, 1, 1]
                        [2, 1, 1, 3, 3, 2, 2, 2]
 */

using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        // input
        int N;
        int[][] first;
        int[][] second;
        GetInputN(out N, out first, out second);

        // checking if the arrays fit
        int cellsCount;
        var fitting = CheckIfArraysFit(first, second, N, out cellsCount);

        // output
        if (!fitting)
        {
            Console.WriteLine("The total number of cells is: {0}", cellsCount);
        }
        else
        {
            PrintMatrix(N, second, first);
        }
    }

    private static void GetInputN(out int N, out int[][] first, out int[][] second)
    {
        N = int.Parse(Console.ReadLine());
        first = new int[N][];
        second = new int[N][];
        char[] charSeparators = new char[] { ' ' };
        for (int i = 0; i < N; i++)
        {
            first[i] =
                Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        for (int i = 0; i < N; i++)
        {
            second[i] =
                Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }

    private static void PrintMatrix(int N, int[][] second, int[][] first)
    {
        for (int i = 0; i < N; i++)
        {
            Array.Reverse(second[i]);
            Console.WriteLine("[{0}, {1}]", string.Join(", ", first[i]), string.Join(", ", second[i]));
        }
    }

    private static bool CheckIfArraysFit(int[][] first, int[][] second, int N, out int cellsCount)
    {
        int a = first[0].Length;
        int b = second[0].Length;
        int c = a + b;
        bool fitting = true;
        cellsCount = c;

        for (int i = 1; i < N; i++)
        {
            a = first[i].Length;
            b = second[i].Length;
            cellsCount += a + b;
            if (a + b != c)
            {
                fitting = false;
            }
        }
        return fitting;
    }
}
