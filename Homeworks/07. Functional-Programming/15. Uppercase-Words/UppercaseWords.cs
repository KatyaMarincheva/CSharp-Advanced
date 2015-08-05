/* Problem 15.	* Uppercase Words
This problem is originally from the PHP Basics Exam 29 August 2014 Evening. You can test your solution here.
Write a program to reverse the letters of all uppercase words in a text. In case an uppercase word stays unchanged after reversing its letters, 
 * then double each of its letters. A word is a sequence of Latin letters separated by non-letter characters (e.g. punctuation characters or digits). 
 * For example, the text "PHP5 is the latest PHP currently, YES" consists of the following words: PHP, is, the, latest, PHP, currently, YES.
Input
The input will be read from the console. It will consist of a variable number of lines, ending with the command "END".
Output
The output should hold the result text. Ensure you escape correctly the HTML special characters in the output with the SecurityElement.Escape() method.
Constraints
•	The text will be in ASCII encoding (texts in Cyrillic, Arabic, Chinese, etc. are not supported).
•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
Examples
Input
Companies like
    HP, ORACLE and IBM target their platforms for cloud-based environment.
    IList<T> implements IEnumerable<T>. GoPHP is a PHP library.
Output
Companies like
    PH, ELCARO and MBI target their platforms for cloud-based environment.
    IList&lt;TT&gt; implements IEnumerable&lt;TT&gt;. GoPHP is a PPHHPP library.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        // patterns and replacers
        List<string> patterns = new List<string>();
        List<string> replacers = new List<string>();

        while (true)
        {
            // input
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            
            MatchUppercaseWords(line, replacers, patterns);

            // replace uppercase words
            line = UppercaseWordsReplacer(patterns, line, replacers);

            // print
            Console.WriteLine(SecurityElement.Escape(line));
        }
    }

    private static string UppercaseWordsReplacer(List<string> patterns, string line, List<string> replacers)
    {
        for (int i = 0; i < patterns.Count; i++)
        {
            line = Regex.Replace(line, patterns[i], word => replacers[i]);
        }
        return line;
    }

    private static void MatchUppercaseWords(string line, List<string> replacers, List<string> patterns)
    {
        string pattern = @"(?<![a-zA-Z])([A-Z]+)(?![A-Za-z])";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(line);

        for (int i = 0; i < matches.Count; i++)
        {
            string word = matches[i].Groups[1].Value;
            string replacer = word;
            if (IsPalyndrome(word))
            {
                replacer = DoubleLettersReplacer(replacer);
            }
            else
            {
                replacer = ReverserReplacer(replacer, word);
            }
            replacers.Add(replacer);
            patterns.Add("(?<![a-zA-Z])(" + word + ")(?![A-Za-z])");
        }
    }

    private static string ReverserReplacer(string replacer, string word)
    {
        replacer = string.Join("", word.Reverse());
        return replacer;
    }

    private static string DoubleLettersReplacer(string replacer)
    {
        string patternLetter = @"[A-Z]";

        replacer = Regex.Replace(replacer, patternLetter, x => String.Format("{0}{0}", x));
        return replacer;
    }

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
}

