/* Problem 12 – Phone Numbers
You are given a string, holding ASCII characters. Find all name -> phone number pairs, format them and print them in an ordered list as list items.
The name should be at least one letter long, can contain only letters and should always start with an uppercase letter.
The phone number should be at least two digits long, should start and end with a digit (might also start with “+”) 
 * and might contain the following symbols in it: “(“, “)”, “/”, “.”, “-”, “ “ (left and right bracket, slash, dot, dash and whitespace).
Between a name and the phone number there might be any number of symbols, other than letters and “+”.
Between the name -> phone number pairs there might be any number of ASCII symbols. 
The output format should be <b>[name]:</b> [phone number] (there is one space between the name and the phone number). 
 * Clear any characters other than digits and “+” from the number when printing the output.
Input
The input will be read from the console. It will consist of several lines holding the input string. The command "END" denotes the end of input.
Output
The output should hold the resulting ordered list (on a single line), or a single paragraph, holding “No matches!”
Constraints
•	The numbers string will hold only ASCII characters (no Unicode). 
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input
Angel$(*^#029661234!@#Pesho ,.' +3592/9653241;'“:{},.
Ivan 0888 123 456 John-=_555.123.4567	Stoian!@#$#@	Gosho )=_*	Steven #$(*&+1-(800)-555-2468
END
Output
(li items are separated on new lines for convenience)
<ol><li><b>Angel:</b> 029661234</li>
<li><b>Pesho:</b> +35929653241</li>
<li><b>Ivan:</b> 0888123456</li>
<li><b>John:</b> 5551234567</li>
<li><b>Steven:</b> +18005552468</li></ol>
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main(string[] args)
    {
        // declarations
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        bool IsMatch = false;

        // read input
        StringBuilder text = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            text.Append(input);
        }

        // check for matches
        IsMatch = NamePhoneCheck(text, phonebook, IsMatch);

        // print result
        if (IsMatch == false)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            PrintOrderedList(phonebook);
        }
    }

    private static void PrintOrderedList(Dictionary<string, string> phonebook)
    {
        Console.Write("<ol>");
        foreach (var pair in phonebook)
        {
            Console.Write("<li><b>{0}:</b> {1}</li>", pair.Key.Trim(), pair.Value.Trim());
        }
        Console.Write("</ol>");
    }

    private static bool NamePhoneCheck(StringBuilder text, Dictionary<string, string> phonebook, bool IsMatch)
    {
        string pattern = @"([A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\- \.\/\)\(]*[0-9]+)";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text.ToString());
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                string name = match.Groups[1].Value;
                string phone = match.Groups[2].Value;
                string[] temp = phone.Split(new char[] { '(', ')', '/', '.', '-', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                phone = string.Join("", temp);
                phonebook.Add(name, phone);
            }
            IsMatch = true;
        }
        return IsMatch;
    }
}

