/* Problem 3.	Matrix shuffling
Write a program which reads a string matrix from the console and performs certain operations with its elements. 
 * User input is provided like in the problem above – first you read the dimensions and then the data. Remember, 
 * you are not required to do this step first, you may add this functionality later.  
Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates in the matrix. 
 * In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less). 
 * You should swap the values at the given coordinates (cell [x1, y1] with cell [x2, y2]) and print the matrix at each step 
 * (thus you'll be able to check if the operation was performed correctly). 
If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist), 
 * print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered. Examples:
Input	
2
3
1
2
3
4
5
6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END	
 * 
Output
(after swapping 1 and 5):
5 2 3
4 1 6
Invalid input!
(after swapping 2 and 4):
5 4 3
2 1 6
 */

using System;

class MatrixShuffling
{
    static void Main()
    {
        // input
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        string[,] matrix = new string[N,M];
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }
        //PrintMatrix(matrix);

        // reading commands
        while (true)
        {
            string input = Console.ReadLine();
            string[] command;

            if (input != "END")
            {
                command = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "swap" && command.Length == 5)
                {
                    // get coordinates
                    int x1 = int.Parse(command[1]);
                    int y1 = int.Parse(command[2]);
                    int x2 = int.Parse(command[3]);
                    int y2 = int.Parse(command[4]);

                    if (ValidateCoordinates(x1, N, x2, y1, M, y2))
                    {
                        // swap
                        string temp = matrix[x1, y1];
                        matrix[x1, y1] = matrix[x2, y2];
                        matrix[x2, y2] = temp;

                        // print
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!"); // in case of wrong coordinates
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!"); // in case of no swap command, or wrong number of coordinates
                }
            }
            else
            {
                break; // break if command = "END"
            } 
        }  
    }

    private static bool ValidateCoordinates(int x1, int N, int x2, int y1, int M, int y2)
    {
        bool validX1 = x1 >= 0 && x1 < N;
        bool validX2 = x2 >= 0 && x2 < N;
        bool validY1 = y1 >= 0 && y1 < M;
        bool validY2 = y2 >= 0 && y1 < M;

        return validX1 && validX2 && validY1 && validY2;
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

