/* Problem 2.	String Length
Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, 
 * the rest of the characters should be filled with *. Print the resulting string on the console.
Examples:
Input	                                                                                            Output
Welcome to SoftUni!	                                                                                Welcome to SoftUni!*
a regular expression (abbreviated regex or regexp and sometimes called a rational expression) 
 * is a sequence of characters that forms a search pattern	                                        a regular expression
C#	                                                                                                C#******************
 */

using System;

class StringLength
{
    static void Main()
    {
        // input
        Console.WriteLine("Please, enter a string:");
        string input = Console.ReadLine().Trim();

        // logic
        string output = input.Length > 20 ? input.Substring(0, 20) : input.PadRight(20, '*');

        // printing
        Console.WriteLine(output);
    }
}
