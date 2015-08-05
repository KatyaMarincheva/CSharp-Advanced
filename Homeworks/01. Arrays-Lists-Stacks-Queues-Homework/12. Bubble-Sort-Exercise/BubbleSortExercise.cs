/* Exercise from lecture 1: Структури от данни - масиви, списъци, опашки, стекове */

using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please, enter a couple of numbers, all in one line, separated by a space:");
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // sorting
        bool swapped = false;
        do
        {
            swapped = false;

            for (int i = 1; i < inputArr.Length; i++)
            {
                if (inputArr[i - 1] > inputArr[i])
                {
                    Swap(inputArr, i - 1, i);
                    swapped = true;
                }
            }
        } while (swapped);

        // printing
        string sortedArr = string.Join(", ", inputArr);
        Console.WriteLine("Output:\n[{0}]", sortedArr);
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[j];
        arr[j] = arr[i];
        arr[i] = temp;
    }
}

