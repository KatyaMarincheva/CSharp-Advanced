/* Problem 2.	Sort Array of Numbers Using Selection Sort
Write a program to sort an array of numbers and then print them back on the console. 
 * The numbers should be entered from the console on a single line, separated by a space. 
 * Refer to the examples for problem 1.
Condition: Do not use the built-in sorting method, you should write your own. Use the selection sort algorithm. 
Hint: To understand the sorting process better you may use a visual aid, e.g. Visualgo.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SortArrayUsingSelectionSort
{
    static void Main()
    {
        // input
        char[] charSeparators = new char[] { ' ' };
        Console.WriteLine("Please, enter a couple of numbers, all in one line, separated by a space:");
        int[] inputArr = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        // logic
        var sorted = SelectionSort(inputArr);

        // printing
        string result = string.Join(", ", sorted);
        Console.WriteLine("Output:\n[{0}]", result);
    }

    private static List<int> SelectionSort(int[] inputArr)
    {
        List<int> tempList = inputArr.ToList(); 
        List<int> sorted = new List<int>(); 

        while (tempList.Count != 0)
        {
            int x = tempList.Min();
            sorted.Add(x);
            tempList.Remove(x);
        }
        return sorted;
    }
}

