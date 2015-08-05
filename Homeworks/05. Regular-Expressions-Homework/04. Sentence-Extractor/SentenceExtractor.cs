/* Problem 4.	Sentence Extractor
Write a program that reads a keyword and some text from the console and prints all sentences from the text, 
 * containing that word. A sentence is any sequence of words ending with '.', '!' or '?'. Examples:
Input	
is
This is my cat! And this is my dog. We happily live in Paris – the most beautiful city in the world! Isn’t it great? Well it is :)	
 * 
Output
This is my cat!
And this is my dog.
 */

using System;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        // input 
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        // logic - check if substring is a sentence, and if it contains the word
        MatchCollection matches = IsSentence(text);

        foreach (Match sentence in matches)
        {
            string x = sentence.ToString();
            if (IsWordInSentence(x, word))
            {
                // printing
                Console.WriteLine(x.Trim());
            }
        }
    }

    private static bool IsWordInSentence(string sentence, string word)
    {
        return Regex.Matches(sentence, string.Format(@"\b{0}\b", word), RegexOptions.IgnoreCase).Count != 0;
    }

    private static MatchCollection IsSentence(string text)
    {
        string pattern = @"([^.!?]+(?=[.!?])[.!?])";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);
        return matches;
    }
}

