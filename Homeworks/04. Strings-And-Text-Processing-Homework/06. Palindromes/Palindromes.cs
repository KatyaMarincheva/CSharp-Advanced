/* Problem 6.	Palindromes
Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe and prints them on the console on a single line, 
 * separated by comma and space. Use spaces, commas, dots, question marks and exclamation marks as word delimiters. 
 * Print only unique palindromes, sorted lexicographically.
Example:
Input	Output
Hi,exe? ABBA! Hog fully a string. Bob	a, ABBA, exe
 */

using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    private static bool IsPalyndrome(string word)
    {
        if (word.Length == 1)
            return true;
        int len = word.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (word[i] != word[len - i - 1])
                return false;
        }
        return true;
    }

    static void Main()
    {
        char[] delimiters = { ' ', ',', '.', '?', '!' };
        SortedSet<string> palyndromes = new SortedSet<string>();
        List<string> words = Console.ReadLine().
            Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (string word in words)
        {
            if (IsPalyndrome(word))
                palyndromes.Add(word);
        }
        Console.WriteLine(string.Join(", ", palyndromes));
    }
}

