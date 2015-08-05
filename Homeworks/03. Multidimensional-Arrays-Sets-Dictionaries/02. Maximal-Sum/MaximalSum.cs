using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] dimentions = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        int N = dimentions[0];
        int M = dimentions[1];
        int[][] source = new int[N][];
        int[,] matrix = new int[N,M ];

        for (int row = 0; row < N; row++)
        {
            source[row] =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

        matrix = To2D(source);
        // sum calculation declarations
        int maxSum = int.MinValue;
        int tmpSum = 0;
        int maxRow = 0;
        int maxCol = 0;

        for (int row = 0; row < N - 2; row++)
        {
            for (int col = 0; col < M - 2; col++)
            {
                // calculate sum for every 3 * 3 square
                tmpSum = CalcSum(row, col, matrix);

                // stop if the max sum is reached
                if (tmpSum > maxSum)
                {
                    maxRow = row;
                    maxCol = col;
                    maxSum = tmpSum;
                }
            }
        }

        // print the matrix
        Console.WriteLine("\n   Sum = {0}", maxSum);
        PrintMatrix(matrix, maxRow, maxCol);
    }

    private static void PrintMatrix(int[,] matrix, int maxRow, int maxCol)
    {
        for (int rows = maxRow; rows <= maxRow + 2; rows++)
        {
            for (int cols = maxCol; cols <= maxCol + 2; cols++)
            {
                Console.Write("{0,4}", matrix[rows, cols]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    // takes a starting point and calculates the sum in starting cell + 2 cells to the right, starting cell plus 2 cells down
    static int CalcSum(int startRow, int startCol, int[,] matrix)
    {
        int sum = 0;
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                sum = sum + matrix[row, col];
            }
        }

        return sum;
    }

    static T[,] To2D<T>(T[][] source)
    {
        int FirstDim = source.Length;
        int SecondDim = source.GroupBy(row => row.Length).Single().Key; 

        var result = new T[FirstDim, SecondDim];
        for (int i = 0; i < FirstDim; ++i)
        {
            for (int j = 0; j < SecondDim; ++j)
            {
                result[i, j] = source[i][j];
            }
        }
        return result;
    }
}

