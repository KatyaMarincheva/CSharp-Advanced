/* Exercise 2: Multiply matrices, from lecture 2: Многомерни масиви, речници, множества */
using System;

class Program
{
    static void Main()
    {
        // matrix 1
        int[,] table1 =
        {
            {2, 3},
            {4, 5},
            {6, 8}
        };
        // matrix 2
        int[,] table2 =
        {
            {2, 3},
            {1, 5}
        };

        // multiplying the above 2 matrices
        int[,] multiplied = MultiplyMatrices(table1, table2);

        // printing
        for (int row = 0; row < multiplied.GetLength(0); row++)
        {
            for (int col = 0; col < multiplied.GetLength(1); col++)
            {
                Console.Write("{0, 4}", multiplied[row, col]);
            }
            Console.WriteLine();
        }

    }
    public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
        for (int row = 0; row < result.GetLength(0); row++)
        {
            for (int col = 0; col < result.GetLength(1); col++)
            {
                for (int k = 0; k < matrix2.GetLength(1); k++) 
                {
                    result[row, col] += matrix1[row, k] * matrix2[k, col];
                }
            }
        }
        return result;
    }
}

