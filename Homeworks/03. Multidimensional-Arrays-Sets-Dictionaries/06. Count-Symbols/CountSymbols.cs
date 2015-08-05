/* Problem 6.	Count Symbols
Write a program that reads some text from the console and counts the occurrences of each character in it. 
 * Print the results in alphabetical (lexicographical order). 
 */

using System;
using System.Collections.Generic;
using System.Linq;

class LettersCount
{
    static void Main()
    {
        // input
        Console.WriteLine("Please, enter a text with letters to count: ");
        string text = Console.ReadLine();

        // this dictionary will hold the pairs: symbol (key) -> count (value)
        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (!symbols.ContainsKey(text[i])) 
            {
                symbols.Add(text[i], text.Count(x => x == text[i]));
            }
        }

        // printing
        foreach (var pair in symbols)
        {
            Console.WriteLine("{0}: {1} time/s",
                pair.Key, pair.Value);
        }
    }
}


