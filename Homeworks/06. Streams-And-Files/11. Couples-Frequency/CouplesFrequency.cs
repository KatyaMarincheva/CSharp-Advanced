/* Problem 11.	* Couples Frequency
Couple	Occurrences	Percentage
3 4	3 times	30.00%
4 2	2 times	20.00%
2 3	2 times	20.00%
2 1	1 times	10.00%
1 12	1 times	10.00%
12 2	1 times	10.00%
Write a program that reads a sequence of n integers and calculates and prints the frequencies of all couples of two consecutive numbers. 
 * For example, for the input sequence { 3 4 2 3 4 2 1 12 2 3 4 }, we have 10 couples (6 distinct), shown on the right with 
 * their occurrence counts and frequencies (in percentage).
Input
The input data should be read from the console. At the first line, we have the input sequence of integers, separated by a space.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print all distinct couples of two consecutive numbers (without duplicates) found in the input sequence 
 * (from left to right) along with their frequency of appearance in the input sequence 
 * (in percentages, with two decimal digits, with traditional rounding). Use the format: "couple -> percentage" (see the examples below). Beware of formatting!
Constraints
•	All input numbers will be integers in the range [-100 000 … 100 000].
•	The count of the numbers will be in the range [2..1000].
•	Time limit: 0.5 sec. Memory limit: 16 MB.
Examples
Input		
3 4 2 3 4 2 1 12 2 3 4	
Output		
3 4 -> 30.00%
4 2 -> 20.00%
2 3 -> 20.00%
2 1 -> 10.00%
1 12 -> 10.00%
12 2 -> 10.00%		
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class CouplesFrequency
{
    static void Main()
    {
        // input
        string[] sequence = Console.ReadLine().Split(new[] { ' ' });

        // storage
        Dictionary<string, int> dict = new Dictionary<string, int>();

        // looping through the couples
        int L = sequence.Length;
        for (int i = 0; i < L - 1; i++)
        {
            string couple = string.Join(" ", sequence.Skip(i).Take(2));

            if (!dict.ContainsKey(couple))
            {
                dict.Add(couple, 0);
            }
            dict[couple]++;
        }

        // sort and print
        int totalNumberOfCouples = L - 1;
        foreach (KeyValuePair<string, int> item in dict)
        {
            Console.WriteLine("{0} -> {1}", item.Key, ((double)item.Value / totalNumberOfCouples).ToString("0.00%"));
        }
    }
}



