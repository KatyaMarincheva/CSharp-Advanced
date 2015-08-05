using System;
using System.Linq;

class InsertionSort
{
    static void Main()
    {
        var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        InsertionSorting(line);

        Console.WriteLine(string.Join(" ", line));
    }

    private static void InsertionSorting(int[] line)
    {
        int temp, j;

        for (int i = 1; i < line.Length; i++)
        {
            temp = line[i];

            j = i - 1;

            // looping from i to 0 and swapping until necessary
            while (j >= 0 && line[j] > temp)
            {
                line[j + 1] = line[j];

                j--;
            }


            line[j + 1] = temp;
        }
    }
}
