/* Problem 6.	Subset Sums
Write a program that reads from the console a number N and an array of 
 * integers given on a single line. Your task is to find all subsets within 
 * the array which have a sum equal to N and print them on the console 
 * (the order of printing is not important). Find only the unique subsets 
 * by filtering out repeating numbers first. 
 * In case there aren’t any subsets with the desired sum, print “No matching subsets.” 
 * Examples:
 * Input	            Output
 -2
-5 4 92 0 928 1 -1 4	-5 + 4 + -1 = -2
                        -5 + 4 + 0 + -1 = -2
*/

using System;
using System.Collections.Generic;
using System.Linq;

class SubSetSums
{
    // declarations
    static int[] numbers;
    static int N;
    static bool solution = false;

    private static void PrintSubset(List<int> subset)
    {
        Console.WriteLine(" {0} = {1}", string.Join(" + ", subset), N);
    }

    static void MakeSubset(int index, List<int> subset)
    {
        int sum = subset.Sum(); 
        if (sum == N) 
        {
            PrintSubset(subset);
            solution = true; // set solution to true, and we will not be printing that there is no solution
        }

        if (subset.Count == numbers.Length) // if susbset size = input array size
            return; // there is nothing more to be done, return

        for (int i = index; i < numbers.Length; i++)
        {
            subset.Add(numbers[i]); // add I-th element to the susbset list
            
            MakeSubset(i + 1, subset); // call MakeSubset recursively, every time starting from the previous index + 1
            subset.RemoveAt(subset.Count - 1); // remove last element
        }
    }

    static void Main()
    {
        // input N
        Console.Write("Please, enter a value for N: ");
        N = int.Parse(Console.ReadLine());

        // input array
        Console.WriteLine("Please enter a sequence of numbers, separated by a space: ");
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // logic: make subsets, calculate their sums, print if sum is equal to N
        Console.WriteLine("\nOutput:");
        List<int> subset = new List<int>();
        MakeSubset(0, subset);

        // if no sum matches S
        if (!solution)
            Console.WriteLine("No matching subsets.");
    }
}

