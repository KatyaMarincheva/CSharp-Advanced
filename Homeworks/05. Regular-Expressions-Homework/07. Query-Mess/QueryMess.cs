/* Problem 7.	* Query Mess
This problem is originally from the JavaScript Basics Exam (22 November 2014). You may check your solution here.
Ivancho participates in a team project with colleagues at SoftUni.  They have to develop an application, 
 * but something mysterious happened – at the last moment all team members… disappeared!  
 * And guess what? He is left alone to finish the project.  All that is left to do is to parse the input data and store it in a special way, 
 * but Ivancho has no idea how to do that! Can you help him?
Input
The input comes from the console on a variable number of lines and ends when the keyword "END" is received.  
For each row of the input, the query string contains pairs field=value. Within each pair, the field name and value are separated by an equals sign, '='. 
 * The series of pairs are separated by an ampersand, '&'. The question mark is used as a separator and is not part of the query string. 
 * A URL query string may contain another URL as value. The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
For each input line, print on the console a line containing the processed string as follows:  key=[value]nextkey=[another  value] … etc. 
Multiple whitespace characters should be reduced to one inside value/key names, but there shouldn’t be any whitespaces before/after extracted keys and values. 
 * If a key already exists, the value is added with comma and space after other values of the existing key in the current string.  See the examples below.  
Constraints
•	SPACE is encoded as '+' or "%20". Letters (A-Z and a-z), numbers (0-9), the characters '*', '-', '.', '_' and other non-special symbols are left as-is.
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	Output
login=student&password=student
END	login=[student]password=[student]
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main()
    {
        // regex patterns
        string pattern = @"([^&=?\s]*)(?=\=)=(?<=\=)([^&=\s]*)";
        string regex = @"((%20|\+)+)";

        // input and matching
        string inputLine;

        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            Regex pairs = new Regex(pattern);
            MatchCollection matches = pairs.Matches(inputLine);

            // storing matching fields and values into a dictionary, per line of input
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            for (int i = 0; i < matches.Count; i++)
            {
                string field = matches[i].Groups[1].Value;
                field = Regex.Replace(field, regex, word => " ").Trim();

                string value = matches[i].Groups[2].Value;
                value = Regex.Replace(value, regex, word => " ").Trim();

                if (!results.ContainsKey(field))
                {
                    List<string> values = new List<string>();
                    values.Add(value);
                    results.Add(field, values);
                }
                else if (results.ContainsKey(field))
                {
                    results[field].Add(value);
                }
            }

            // printing
            foreach (var pair in results)
            {
                Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
            }
            Console.WriteLine();
        }   
    }
}

