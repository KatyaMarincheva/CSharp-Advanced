/* Problem 1.	Reverse String
Write a program that reads a string from the console, reverses it and prints the result back at the console.
Input	Output
sample	elpmas
24tvcoi92	29iocvt42
 */

using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        // input
        Console.WriteLine("Please, enter a string: ");
        string input = Console.ReadLine();

        // reversing and printing
        Console.WriteLine(string.Join("", input.Reverse()));
    }
}
