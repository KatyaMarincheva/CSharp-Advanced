/* Problem 3.	Categorize Numbers
Write a program that reads N floating-point numbers from the console. 
 * Your task is to separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) 
 * and the other containing the floating-point numbers with non-zero fraction. Print both arrays along with their 
 * minimum, maximum, sum and average (rounded to two decimal places). 
 */

using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumbers
{
    static void Main()
    {
        // declarations
        List<double> floatNumbers = new List<double>();
        List<int> roundNumbers = new List<int>();
        
        // input and categorization
        Console.Write("please, enter a value for N: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.Write("Please, enter number {0}: ", i + 1);
            double num = double.Parse(Console.ReadLine());
            int rnum = (int)num;

            if (num == rnum)
            {
                roundNumbers.Add(rnum);
            }
            else
            {
                floatNumbers.Add(num);
            }
        }

        // output
        string floats = string.Join(", ", floatNumbers);
        string rounds = string.Join(", ", roundNumbers);
        Console.WriteLine("\nOutput:");
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4}\n", floats, floatNumbers.Min(), floatNumbers.Max(), floatNumbers.Sum(), floatNumbers.Average());
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4}", rounds, roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), roundNumbers.Average());
    }
}

