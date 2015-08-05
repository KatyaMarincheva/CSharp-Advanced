/* Problem 4.	First Larger Than Neighbours
Write a method that returns the index of the first element in array that is larger than its neighbours, 
 * or -1 if there's no such element. Use the method from the previous exercise.
 */

using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        // input
        int[] sequenceOne = {1, 3, 4, 5, 1, 0, 5};
        int[] sequenceTwo = {1, 2, 3, 4, 5, 6, 6};
        int[] sequenceThree = {1, 1, 1};

        // invoking the method
        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }

    private static int IndexOfFirstElementLargerThanNeighbours(int[] seq)
    {
        for (int i = 0; i < seq.Length; i++)
        {
            if (LargerThanNeighbours.IsLargerThanNeighbors(seq, i)) // invoking the method from project 03. Larger-Than-Neighbours
            {
                return i;
            }
        }
        return -1;
    }
    //private static bool IsLargerThanNeighbors(int[] nums, int i)
    //{
    //    bool isLarger = false;

    //    if (i == 0)
    //    {
    //        isLarger = nums[i + 1] < nums[i] ? true : false;
    //    }
    //    else if (i > 0 && i < nums.Length - 1)
    //    {
    //        isLarger = nums[i - 1] < nums[i] && nums[i + 1] < nums[i] ? true : false;
    //    }
    //    else
    //    {
    //        isLarger = nums[i - 1] < nums[i] ? true : false;
    //    }

    //    return isLarger;
    //}
}

