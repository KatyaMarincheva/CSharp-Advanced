/* Problem 11 – *Pyramid
You are a given pyramid of integer numbers. Your task is to print a growing sequence of integers, starting from the top of the pyramid. For example, we are given the following pyramid:
    2
  5  8
4  9 10
The first number from the top is 2. Going bottom, on the second row, the closest number larger than 2 is 5. On the third row, the closest number larger than 5 is 9. The resulting sequence is {2, 5, 9}.
If a row does not contain a number larger than the previous one, we go to the next row and search for a number greater than the previous number + 1. For example:
   6
 5  3
4 9 7
The first number is 6. On the second row we have no number greater than 6, so we go to the next row, 
 * where we look for the nearest number larger than 7 (6 + 1 = 7), which is 9. The resulting sequence is {6, 9}.
Input
The input will be read from the console. 
•	On the first line, you will get the number of lines N. 
•	On the next N you will get the rows of the pyramid. The numbers in each row are separated by one or more spaces. 
 * There will be a different number of spaces at the beginning of each line. 
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print on the console all numbers of the sequence separated by a comma and a space.
Constraints
•	The first row will contain only 1 number.
•	The rows of the pyramid will be in the range [2 … 1000].
•	The numbers in the pyramid will be integers in the range [-2147483648 … 2147483647].
•	Time limit: 0.3 sec. Memory limit: 16 MB.
Examples
Input	        Output		
3
    2
  5  8
4 9 10	        2, 5, 9		
 */

using System;
using System.Collections.Generic;
using System.Linq;

class Pyramid
{
    // declarations
    private static int lastElement;
    static void Main()
    {
        // input
        int n = int.Parse(Console.ReadLine());
        int[][] numbers = new int[n][];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        // checking for increasing sequence
        List<int> sequence = new List<int>();
        sequence.Add(numbers[0][0]);
        lastElement = numbers[0][0];

        for (int i = 1; i < n; i++)
        {
            BuildSequence(numbers, i, sequence);
        }

        // printing
        Console.WriteLine(string.Join(", ", sequence));
    }

    private static void BuildSequence(int[][] numbers, int i, List<int> sequence)
    {
        bool found = false;
        for (int j = 0; j < numbers[i].Length; j++)
        {
            Array.Sort(numbers[i]); // we need the smallest bigger number
            if (lastElement < numbers[i][j])
            {
                sequence.Add(numbers[i][j]);
                found = true;
                lastElement = sequence.Last();
                return;
            }
        }
        if (!found)
        {
            lastElement++; // if no match on the given row, next time we will be searching for the "previous number + 1"
            return;
        }
    }
}
