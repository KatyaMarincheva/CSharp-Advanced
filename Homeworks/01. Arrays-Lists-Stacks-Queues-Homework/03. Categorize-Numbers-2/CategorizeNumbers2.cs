/* Problem 3.	Categorize Numbers
Write a program that reads N floating-point numbers from the console. 
 * Your task is to separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) 
 * and the other containing the floating-point numbers with non-zero fraction. Print both arrays along with their 
 * minimum, maximum, sum and average (rounded to two decimal places). 
 */

using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumbers2
{
    static void Main()
    {
        // input
        string input = "1.2 -4 5.00 12211 93.003 4 2.2";
        double[] numbers = input.Split(' ').Select(double.Parse).ToArray();

        // catogorizing
        List<double> floatNumbers = new List<double>();
        List<int> roundNumbers = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            double num = numbers[i];
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

        // printing
        string floats = string.Join(", ", floatNumbers);
        string rounds = string.Join(", ", roundNumbers);
        Console.WriteLine("Input:");
        Console.WriteLine(input);
        Console.WriteLine("\nOutput:");
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}\n", floats, floatNumbers.Min(), floatNumbers.Max(), floatNumbers.Sum(), floatNumbers.Average());
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", rounds, roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), (double)roundNumbers.Average());
    }
}

