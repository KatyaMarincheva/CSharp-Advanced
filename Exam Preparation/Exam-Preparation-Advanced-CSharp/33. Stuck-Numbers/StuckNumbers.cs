/* Problem 9.	* Stuck Numbers
This problem is from the Java Basics Exam (1 June 2014). You may check your solution here.
You are given n numbers. Write a program to find among these numbers all sets of 4 numbers {a, b, c, d}, such that a|b == c|d, where a ≠ b ≠ c ≠ d. Assume that "a|b" means to append the number b after a. We call these numbers {a, b, c, d} stuck numbers: if we append a and b, we get the same result as if we appended c and d. Note that the numbers a, b, c and d should be distinct (a ≠ b ≠ c ≠ d).
Input
The input comes from the console. The first line holds the count n. The next line holds n integer numbers, separated by a space. The input numbers will be distinct (no duplicates are allowed).
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print at the console all stuck numbers {a, b, c, d} found in the input sequence in format "a|b==c|d" (without any spaces), each at a separate line. The order of the output lines is not important. Print "No" in case no stuck numbers exist among the input sequence of numbers.
Constraints
•	The count n will be an integer number in the range [1 … 50].
•	The input numbers will be distinct integers in the range [0 … 9999].
•	Time limit: 0.5 sec. Memory limit: 16 MB.
Examples
Input	
5
2 51 1 75 25	
 * 
Output
2|51==25|1
25|1==2|51		
 */

using System;

class StuckNumbers
{
    static void Main(string[] args)
    {
        // input
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

        // logic
        bool stuckNums = false;
        for (int p1 = 0; p1 < n; p1++)
        {
            for (int p2 = 0; p2 < n; p2++)
            {
                for (int p3 = 0; p3 < n; p3++)
                {
                    for (int p4 = 0; p4 < n; p4++)
                    {
                        if (p1 != p2 && p1 != p3 && p1 != p4 && p2 != p3 && p2 != p4 && p3 != p4)
                        {
                            // output option 1
                            stuckNums = CheckForStuckNumbers(numbers, p1, p2, p3, p4, stuckNums);
                        }
                    }
                }
            }
        }

        // ouput option 2
        if (!stuckNums)
        {
            Console.WriteLine("No");
        }
    }

    private static bool CheckForStuckNumbers(string[] numbers, int p1, int p2, int p3, int p4, bool stuckNums)
    {
        string left = numbers[p1] + numbers[p2];
        string right = numbers[p3] + numbers[p4];
        if (left == right)
        {
            PrintStuckNumbers(numbers, p1, p2, p3, p4);
            stuckNums = true;
        }
        return stuckNums;
    }

    private static void PrintStuckNumbers(string[] numbers, int p1, int p2, int p3, int p4)
    {
        Console.WriteLine("{0}|{1}=={2}|{3}", numbers[p1], numbers[p2], numbers[p3], numbers[p4]);
    }
}