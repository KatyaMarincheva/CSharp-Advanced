/* Problem 1.	Series of Letters
Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
Input	                    Output
aaaaabbbbbcdddeeeedssaa	    abcdedsa
 */

using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        //  The regex will match any character (.) and \\1+ will match whatever was captured in the first group.
        var text = Console.ReadLine();
        var regex = new Regex(@"(.)\1+");
        Console.WriteLine(regex.Replace(text, "$1"));
    }
}

