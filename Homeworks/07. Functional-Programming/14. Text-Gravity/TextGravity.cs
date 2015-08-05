/* Problem 14.	 * Text Gravity
This problem is originally from the PHP Basics Exam (31 August 2014). You can test your solution here.
Write a program that takes as input a line length and text and formats the text so that it fits inside several rows, 
 * each with length equal to the given line length. Once the text is fitted, each character starts dropping as long as there is an empty space below it.
For example, we are given the text "The Milky Way is the galaxy that contains our star system" and line length of 10. 
 * If we distribute the text characters such that the text fits in lines with length 10, the result is:
 
Text characters start 'falling' until no whitespace remain under any character. 
 * The resulting text should be printed as an HTML table with each character in <td></td> tags.
Input
The input will come from the console. It will consist of two lines.
•	The first line will hold the line length.
•	The second input line will hold a string.
Output
The output consists of the HTML table. Everything should be put inside <table></table> tags. 
 * Each line should be printed in <tr></tr> tags. Each character should be printed in <td></td> tags 
 * (encode the HTML special characters with the SecurityElement.Escape() method). Print space " " in all empty cells. See the example below.
Constraints
•	The line length will be integer in the range [1 ... 30]. 
•	The text will consist [1 … 1000] ASCII characters.
 */

using System;
using System.Security;

class TextGravity
{
    static void Main()
    {
        // input
        int length = int.Parse(Console.ReadLine());
        char[] line = Console.ReadLine().ToCharArray();

        // creating a text table
        int N = (int) Math.Ceiling((double) line.Length/length);
        int M = length;
        string[,] table = new string[N, M];
        int index = 0;

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                if (index < line.Length)
                {
                    table[row, col] = line[index].ToString();
                    index++;
                }
                else
                {
                    table[row, col] = " ";
                }
            }
        }
        bool fallen = false;

        do
        {
            fallen = false;
            for (int row = 0; row < N - 1; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    if (table[row, col] != " " && table[row + 1, col] == " ")
                    {
                        table[row + 1, col] = table[row, col];
                        table[row, col] = " ";
                        fallen = true;
                    }
                }
            }
        } while (fallen);

        Console.Write("<table>");
        for (int row = 0; row < N; row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < M; col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(table[row, col]));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }
}

