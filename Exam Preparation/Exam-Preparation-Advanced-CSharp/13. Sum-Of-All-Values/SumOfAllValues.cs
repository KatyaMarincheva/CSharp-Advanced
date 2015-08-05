/* Problem 13 – Sum of All Values
You are given a keys string and a text string. Write a program that finds the start key and the end key from the keys string and then applies them to the text string.
The start key will always stay at the beginning of the keys string. It can contain only letters and underscore and ends just before the first found digit.
The end key will always stay at the end of the keys string. It can contain only letters and underscore and starts just after the last found digit.
Print at the console the sum of all values (only floating-point numbers with dot as a separator are considered valid) in the text string, 
 * between a start key and an end key. If the value is 0 then print “The total value is: nothing”. If no start key or no end key is found then print “A key is missing”.
Input
The input will be read from the console. The first line will hold the keys string and the second line will hold the text to search.
Output
The output should hold the result text, printed in an HTML paragraph. The actual value of the sum should be italic.
Constraints
•	The keys string and text string will hold only ASCII characters (no Unicode).
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input
keysString	startKEY12adghfgh243212gadghfgs43endKEY
textString	asdjykulgfjddfsffdstartKEY12endKEYqwfrhtyu67543rewghy3tefdgd
startKEY123.45endKEYwret34yrestartKEY2.6endKEY213434ytuhrgerweasfd
startKEYendKEYstartKEYasfdgeendKEY
Output
<p>The total value is: <em>138.05</em></p>
 */

using System;
using System.Linq;
using System.Text.RegularExpressions;

class SumOfAllValues
{
    static void Main(string[] args)
    {
        // input
        var keys = Console.ReadLine();
        string text = Console.ReadLine();

        // extracting start and end keys from the keys string
        string endKey;
        var startKey = ExtractKeys(keys, out endKey);

        // if one or more keys are missing
        if (startKey == String.Empty || endKey == String.Empty)
        {
            Console.WriteLine("<p>A key is missing</p>");
        }
        else
        {
            // extracting numbers
            string numbersPattern = String.Format("{0}(.*?){1}", startKey, endKey);
            MatchCollection matches = Regex.Matches(text, numbersPattern);

            // calculating sum
            double sum = 0;
            double number;
            bool numeric = false;
            foreach (Match match in matches)
            {
                numeric = double.TryParse(match.Groups[1].Value, out number);
                if (numeric)
                {
                    sum += number;
                }
            }

            // printing
            if (sum == 0)
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
            else
            {
                
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
            }
        }
    }

    private static string ExtractKeys(string keys, out string endKey)
    {
        string startKeyPattern = @"^([a-zA-Z_]+)\d+";
        string endKeyPattern = @"\d+([a-zA-Z_]+)$";
        Regex start = new Regex(startKeyPattern);
        Regex end = new Regex(endKeyPattern);
        string startKey = Regex.Match(keys, startKeyPattern, RegexOptions.None).Groups[1].Value;
        endKey = Regex.Match(keys, endKeyPattern, RegexOptions.None).Groups[1].Value;
        return startKey;
    }
}

