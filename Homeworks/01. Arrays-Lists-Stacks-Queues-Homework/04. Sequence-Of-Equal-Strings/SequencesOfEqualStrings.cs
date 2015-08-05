/* Problem 4.	Sequences of Equal Strings
Write a program that reads an array of strings and finds in it all sequences of equal elements 
 * (comparison should be case-insensitive). The input strings are given as a single line, separated by a space. 
 *  * Examples:
 * Input	            Output
hi yes yes yes bye	    hi
                        yes yes yes
                        bye
 */

using System;
using System.Linq;

class SequencesOfEqualStrings
{
    static void Main()
    {
        Console.WriteLine("Please, enter a sequence of strings, all in one line, separated by a space:");
        string[] input = Console.ReadLine().Split(' ').ToArray();

        // printing sequences
        // this method works with neighbour equal strings
        Console.WriteLine("\nOutput:");
        Console.Write("{0} ", input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                Console.Write("{0} ", input[i]);
            }
            else
            {
                Console.Write("\n{0} ", input[i]);
            }
        }
        Console.WriteLine();
    }
}

