/* Problem 7 – *Sorted Subset Sums
Modify the program you wrote for the previous problem to print the results in the following way: 
 * each line should contain the operands (numbers that form the desired sum) 
 * in ascending order; the lines containing fewer operands should be printed before those with more operands; 
 * when two lines have the same number of operands, the one containing the smallest operand should be printed first. 
 * If two or more lines contain the same number of operands and have the same smallest operand, the order of printing is not important. 
 * Example:
 * Input	            Output
 -2
-5 4 92 0 928 1 -1 4	-5 + -1 + 4 = -2
                        -5 + -1 + 0 + 4 = -2
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums 
{
    // declarations
    static List<List<int>> subsets = new List<List<int>>();
    static int[] numbers;
    static int N;
    static bool solution = false;

    static void Main()
    {
        // input
        Console.Write("Please, enter a value for N: ");
        N = int.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter a sequence of numbers, separated by a space: ");
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

        // logic
        Array.Sort(numbers);
        Console.WriteLine("\nOutput:");

        List<int> subset = new List<int>();
        MakeSubset(0, subset);

        var sorted = subsets.OrderBy(x => x.Count);

        // printing
        PrintSubsets(sorted);

        if (!solution)// if no sum matches N
            Console.WriteLine("No matching subsets.");
    }

    private static void PrintSubsets(IEnumerable<List<int>> sorted)
    {
        foreach (var item in sorted)
        {
            Console.WriteLine(" {0} = {1}", string.Join(" + ", item), N);
        }
    }

    static void MakeSubset(int index, List<int> subset)
    {
        if (subset.Sum() == N && subset.Count > 0) 
        {
            subsets.Add(new List<int>(subset));
            solution = true; // set solution to true, and we will not be printing that there is no solution
        }

        for (int i = index; i < numbers.Length; i++)
        {
            subset.Add(numbers[i]);
            MakeSubset(i + 1, subset); // call MakeSubset recursively, every time starting from the previous index + 1
            subset.RemoveAt(subset.Count - 1); // remove last element
        }
    }
}
