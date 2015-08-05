/* Problem 5.	Longest Increasing Sequence
Write a program to find all increasing sequences inside an array of integers. 
 * The integers are given on a single line, separated by a space. 
 * Print the sequences in the order of their appearance in the input array, each at a single line. 
 * Separate the sequence elements by a space. 
 * Find also the longest increasing sequence and print it at the last line. 
 * If several sequences have the same longest length, print the left-most of them. Examples:
Input	                Output
2 3 4 1 50 2 3 4 5	    2 3 4
                        1 50
                        2 3 4 5
                        Longest: 2 3 4 5
 */

using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        // declarations
        int numberLongest = 0;
        int bestCount = 0;
        int longestCount = 0;

        // input
        Console.WriteLine("Please, enter a sequence of strings, all in one line, separated by a space:");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // logic
        List<List<int>> sequences = new List<List<int>>();
        Console.WriteLine("\nOutput:");

        for (int i = 0; i < array.Length - 1; i++)
        {
            // searching for current increasing sequence
            var count = CountSequence(i, array);

            if (count >= bestCount)
            {
                bestCount = count;
                int number = i;
                i += count - 1;

                // printing current increasing sequence
                PrintSequence(number, bestCount, array);

                // checking if the current increasing sequence is longer than the longest one
                if (bestCount > longestCount)
                {
                    // storing the start and end index of the longest increasing sequence
                    longestCount = bestCount;
                    numberLongest = number;
                }

                // so that we can restart the search for current increasing sequences
                bestCount = 0;

            }
        }

        // output
        Console.Write("Longest: ");
        PrintSequence(numberLongest, longestCount, array);
    }

    private static void PrintSequence(int number, int bestCount, int[] array)
    {
        for (int l = number; l <= number + bestCount - 1; l++)
        {
            Console.Write("{0} ", array[l]);
        }
        Console.WriteLine();
    }

    private static int CountSequence(int i, int[] array)
    {
        int count = 1;
        int j = i + 1;
        int k = i;
        while (array[k] < array[j])
        {
            count++;
            j++;
            k++;
            if (j >= array.Length)
            {
                break;
            }
        }
        return count;
    }
}
