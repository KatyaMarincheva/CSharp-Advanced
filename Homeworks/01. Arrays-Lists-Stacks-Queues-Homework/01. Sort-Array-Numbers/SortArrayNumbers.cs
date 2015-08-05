/* Problem 1.	Sort Array of Numbers
Write a program to sort an array of numbers and then print them back on the console. 
 * The numbers should be entered from the console on a single line, separated by a space. 
 * Examples:
Input	             Output
6 5 4 10 -3 120 4	-3 4 4 5 6 10 120
10 9 8	             8 9 10
 */

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // input
        Console.WriteLine("Please, enter several numbers, all in one line, separated by a space:");
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        // sorting
        Array.Sort(inputArr);

        // printing
        string sortedArr = string.Join(" ", inputArr);
        Console.WriteLine("Output:\n{0}", sortedArr);
    }
}

