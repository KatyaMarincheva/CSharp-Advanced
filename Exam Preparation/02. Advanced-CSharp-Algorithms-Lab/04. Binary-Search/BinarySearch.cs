using System;
using System.Linq;

class BinarySort
{
    static void Main()
    {
        var array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int element = int.Parse(Console.ReadLine());

        Array.Sort(array);

        // applying the BinarySearch method
        Console.WriteLine(BinarySearch(array, element, 0, array.Length )); 
    }

    public static int BinarySearch(int[] x, int searchValue, int left, int right)
    {
        if (right < left)
        {
            return -1;
        }

        // calculating middle of array
        int mid = (left + right) >> 1;

        // move up if searchValue < ot numeber at mid position
        if (searchValue > x[mid])
        {
            return BinarySearch(x, searchValue, mid + 1, right);
        }
        // move down if searchValue < ot numeber at mid position
        else if (searchValue < x[mid])
        {
            return BinarySearch(x, searchValue, left, mid - 1);
        }

        // if searchValue = middle element, search from left to right of current subset - we might find the same value to the left from the middle
        else if (searchValue == x[mid])
        {
            for (int i = left; i < right; i++)
            {
                if (x[i] == searchValue)
                {
                    return i;
                }
            }

            return mid;
        }

        return -1;
    }
}

