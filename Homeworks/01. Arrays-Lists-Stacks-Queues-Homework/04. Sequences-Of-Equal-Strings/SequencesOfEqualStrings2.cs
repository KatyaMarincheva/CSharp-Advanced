/* Problem 4.	Sequences of Equal Strings
Write a program that reads an array of strings and finds in it all sequences of equal elements 
 * (comparison should be case-insensitive). The input strings are given as a single line, separated by a space. 
 * Examples:
 * Input	            Output
hi yes yes yes bye	    hi
                        yes yes yes
                        bye
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SequencesOfEqualStrings2
{
    static void Main()
    {
        // input
        Console.WriteLine("Please, enter a sequence of strings, all in one line, separated by a space:");
        string[] input = Console.ReadLine().Split(' ').ToArray();

        // composing a dictionary of strings and their respective counts
        // this method doesn't take into considerations the strings position within the input string array
        Dictionary<string, int> equalStrings = new Dictionary<string, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (!equalStrings.ContainsKey(input[i]))
            {
                equalStrings.Add(input[i], AppearanceCount(input, input[i]));
            }
        }

        // printing
        Console.WriteLine("\nOutput:");
        foreach (KeyValuePair<string, int> pair in equalStrings)
        {
            string temp = pair.Key + " ";
            Console.WriteLine(string.Concat(Enumerable.Repeat(temp, pair.Value)));
        }
    }

    static int AppearanceCount(string[] arr, string X)
    {
        // counting how many times number appears in the input array
        int counter = arr.Count(n => n == X);

        return counter;
    } 
}

