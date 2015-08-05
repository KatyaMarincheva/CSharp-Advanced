/* Problem 11.	 * String Matrix Rotation
This problem is originally from the JavaScript Basics Exam (28 July 2014). You may check your solution here.
You are given a sequence of text lines. Assume these text lines form a matrix of characters 
 * (pad the missing positions with spaces to build a rectangular matrix). Write a program to rotate the matrix by 90, 180, 270, 360, … degrees. 
 * Print the result at the console as sequence of strings. Examples:
Input	Rotate(90)	Rotate(180)	Rotate(270)
hello
softuni
exam	 	 	 
 			
Input
The input is read from the console:
•	The first line holds a command in format "Rotate(X)" where X are the degrees of the requested rotation.
•	The next lines contain the lines of the matrix for rotation.
•	The input ends with the command "END".
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print at the console the rotated matrix as a sequence of text lines.
Constraints
•	The rotation degrees is positive integer in the range [0…90000], where degrees is multiple of 90.
•	The number of matrix lines is in the range [1…1 000].
•	The matrix lines are strings of length 1 … 1 000.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class StringMatrixRotation
{
    static void Main()
    {
        // initial database
        List<string> lines = new List<string>();

        // input
        string[] command = Console.ReadLine().Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries);

        while (true)
        {
            string input = Console.ReadLine();

            if (input != "END")
            {
                lines.Add(input);
            }
            else
            {
                break;
            }
        }

        // converting input lines into a 2D matrix
        int firstDim = lines.Count;

        var sorted = from s in lines
                     orderby s.Length descending 
                     select s;
        int secondDim = sorted.First().Length;

        char[,] matrix = To2D(lines, firstDim, secondDim);
        //PrintMatrix(matrix); // uncomment if you want to see how the initial matrix looks like

        // apply the rotation
        int degrees = int.Parse(command[1]);

        switch (degrees % 360)
        {
            case 0: PrintMatrix(matrix); break;
            case 90: Rotate90(matrix); break;
            case 180: Rotate180(matrix); break;
            case 270: Rotate270(matrix); break;
        }
    }

    static char[,] To2D(List<string> source, int N, int M)
    {

        var result = new char[N, M];
        for (int i = 0; i < N; ++i)
        {
            for (int j = 0; j < M; ++j)
            {
                result[i, j] = source[i].PadRight(M, ' ')[j];
            }
        }
        return result;
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void Rotate90(char[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(1); rows++)
        {
            for (int cols = matrix.GetLength(0) - 1; cols >= 0; cols--)
            {
                Console.Write(matrix[cols, rows]);
            }
            Console.WriteLine();
        }
    }

    private static void Rotate180(char[,] matrix)
    {
        for (int rows = matrix.GetLength(0) - 1; rows >= 0 ; rows--)
        {
            for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
            {
                Console.Write(matrix[rows, cols]);
            }
            Console.WriteLine();
        }
    }

    private static void Rotate270(char[,] matrix)
    {
        for (int rows = matrix.GetLength(1) - 1; rows >= 0; rows--)
        {
            for (int cols = 0; cols < matrix.GetLength(0); cols++)
            {
                Console.Write(matrix[cols, rows]);
            }
            Console.WriteLine();
        }
    }
}

