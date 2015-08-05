/* Problem 6.	** Extract Hyperlinks
This problem is originally from the JavaScript Basics Exam (27 July 2014). You may check your solution here.
Write a program to extract all hyperlinks (<href=…>) from a given text. The text comes from the console on a variable 
 * number of lines and ends with the command "END". Print at the console the href values in the text.
The input text is standard HTML code. It may hold many tags and can be formatted in many different forms (with or without whitespace). 
 * The <a> elements may have many attributes, not only href. You should extract only the values of the href attributes of all <a> elements.
Input	
The input data comes from the console. It ends when the "END" command is received. 
Output
Print at the console the href values in the text, each at a separate line, in the order they come from the input.
Constraints
•	The input will be well formed HTML fragment (all tags and attributes will be correctly closed).
•	Attribute values will never hold tags and hyperlinks, e.g. "<img alt='<a href="hello">' />" is invalid.
•	Commented links are also extracted.
•	The number of input lines will be in the range [1 ... 100].
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	
<a href="http://softuni.bg" class="new"></a>
END	
 * 
 Output
 http://softuni.bg
 */

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _06.Extract_Hyperlinks
{
    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            // input
            string inputLine;
            StringBuilder sb = new StringBuilder();
            while (!((inputLine = Console.ReadLine()) == "END"))
            {
                sb.Append(inputLine);
            }
            string text = sb.ToString();

            // logic
            string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            Regex users = new Regex(pattern);
            MatchCollection matches = users.Matches(text);

            // print
            foreach (Match hyperlink in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (hyperlink.Groups[i].Length > 0)
                    {
                        Console.WriteLine(hyperlink.Groups[i]);
                    }
                }
            }
        }
    }
}
