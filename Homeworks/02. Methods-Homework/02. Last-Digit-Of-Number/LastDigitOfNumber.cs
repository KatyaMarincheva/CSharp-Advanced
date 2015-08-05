/* Problem 2.	Last Digit of Number
Write a method that returns the last digit of a given integer as an English word. 
 * Test the method with different input values. Ensure you name the method properly.
 */

using System;

class LastDigitOfNumber
{
    static void Main()
    {
        // input
        Console.Write("\nPlease, enter an integer number: ");
        int number = int.Parse(Console.ReadLine());

        // invoking the method
        Console.WriteLine("Output: {0}", GetLastDigitAsWord(number));
    }

    private static string GetLastDigitAsWord(int num)
    {
        string[] digitAsWord = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        int digit = num%10;

        return digitAsWord[digit];
    }
}

