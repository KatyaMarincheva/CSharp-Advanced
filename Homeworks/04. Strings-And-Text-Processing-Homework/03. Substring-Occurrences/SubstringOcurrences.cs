/* Problem 3.	Count Substring Occurrences
Write a program to find how many times a given string appears in a given text as substring. 
 * The text is given at the first input line. The search string is given at the second input line. 
 * The output is an integer number. Please ignore the character casing. Overlapping between occurrences is allowed. 
 * Examples:
Input	Output
Welcome to the Software University (SoftUni)! Welcome to programming. Programming is wellness for developers, said Maxwell.
wel	4
aaaaaa
aa	5
ababa caba
aba	3
Welcome to SoftUni
Java	0
 */

using System;
using System.Linq;

class SubstringOcurrences
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string subString = Console.ReadLine();

        int count = text.Select((c, i) => text.Substring(i)).Count(x => x.StartsWith(subString, StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine(count);
    }
}

