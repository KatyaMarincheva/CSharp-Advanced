/*Problem 10 – Clearing Commands
As a janitor at SoftUni you have the task to clean all the garbage, left by the students every day. The problem is you can only move through the maze of tables, chairs, internet cables and power plugs following the commands SoftUni team has left at the end of the day.
You are given a matrix, holding 1 or more strings of ASCII characters. The strings will come from the console, each on a separate line. These strings will contain all the garbage and commands by the SoftUni team. Your task is to find and execute all the clearing commands within the matrix. The commands are initiated by the following characters:
1.	">" – Removes the characters to the right and replaces each one with a single space (" ").
2.	"<" – Removes the characters to the left and replaces each one with a single space (" ").
3.	"v" – Removes the characters below and replaces each one with a single space (" ").
4.	"^" – Removes the characters above and replaces each one with a single space (" ").
Every command is executed until it reaches another command character or the matrix borders are reached.
Input
The input will be read from the console. Each line will be a string of equal length, holding ASCII characters. The input will end with the command "END".
Output
The output should consist of <p> tags, each holding a row of the matrix (a string).
Note: Make sure you escape all the special characters within the <p> tags with the SecurityElement.Escape method.
 * http://stackoverflow.com/questions/8331119/escape-invalid-xml-characters-in-c-sharp
Constraints
•	The strings will contain any ASCII character.
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	
**********
**>****v**
**********
**********
**^****<**
v*********
END 	
 * 
Output
<p>**********</p>
<p>**>    v**</p>
<p>** **** **</p>
<p>** **** **</p>
<p>**^    <**</p>
<p>v*********</p>		
*/

using System;
using System.Collections.Generic;
using System.Security;

class ClearingCommands
{
    static void Main()
    {
        string commandSymbols = "><^v";
        List<char[]> matrix = new List<char[]>();

        while (true)
        {
            string line = Console.ReadLine().Trim(' ');

            if (line == "END")
            {
                break;
            }

            matrix.Add(line.ToCharArray());
        }

        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                int currentRow;
                int currentCol;
                //string currentCell = matrix[currentRow][currentCol].ToString();
                switch (matrix[row][col])
                {
                    case '<':
                        currentRow = row;
                        currentCol = col - 1;
                        while (currentCol >= 0 && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                        {
                            matrix[currentRow][currentCol] = ' ';
                            currentCol--;
                        }
                        break;

                    case '>':
                        currentRow = row;
                        currentCol = col + 1;
                        while (currentCol < matrix[currentRow].Length && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                        {
                            matrix[currentRow][currentCol] = ' ';
                            currentCol++;
                        }
                        break;
                    case 'v':
                        currentRow = row + 1;
                        currentCol = col;
                        while (currentRow < matrix.Count && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                        {
                            matrix[currentRow][currentCol] = ' ';
                            currentRow++;
                        }
                        break;
                    case '^':
                        currentRow = row - 1;
                        currentCol = col;
                        while (currentRow >= 0 && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                        {
                            matrix[currentRow][currentCol] = ' ';
                            currentRow--;
                        }
                        break;
                }
            }
        }
        PrintMatrix(matrix);
    }

    private static void PrintMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(new string(matrix[row])));
        }
    }
}



