/* Problem 5.	Reverse Number
Write a method that reverses the digits of a given floating-point number.
Input	    Output
256         652
123.45      54.321
0.12	    21
 */

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // input
        double inputNum = double.Parse(Console.ReadLine());

        // output
        double reversed = GetReversedNumber(inputNum);
        Console.WriteLine(reversed);
    }

    private static double GetReversedNumber(double inputNum)
    {
        bool isNegative = inputNum < 0;
        string input = string.Join("", inputNum.ToString().TrimStart('-').Reverse());
        double number = double.Parse(input);
        return isNegative ? -number : number;
    }
}
