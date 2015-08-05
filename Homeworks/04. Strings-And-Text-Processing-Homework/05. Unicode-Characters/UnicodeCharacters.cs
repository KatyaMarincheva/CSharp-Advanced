/* Problem 5.	Unicode Characters
Write a program that converts a string to a sequence of C# Unicode character literals. Examples:
Input	Output
Hi!	\u0048\u0069\u0021
What?!?	\0057\0068\0061\0074\003f\0021\003f
SoftUni	\0053\006f\0066\0074\0055\006e\0069
 */

using System;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();
        foreach (var chr in input)
        {
            Console.Write("\\u{0:x4}", (int)chr);
        }
        Console.WriteLine();
    }
}

