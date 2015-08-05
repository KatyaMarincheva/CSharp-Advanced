/* Problem 17 – Biggest Table Row
You are given an HTML table with 4 columns: Town, Store1, Store2 and Store3. It consists of sequence of text lines: the "<table>" tag, 
 * the header row, several data rows, and "</table>" tag (see the examples below). The Store1, Store2, 
 * and Store3 columns hold either numbers or "-" (which means "no data"). Your task is to write a program which 
 * parses the table data rows and finds the row with a maximal sum of its values.
Input
The input is read from the console on several lines, each holding the table rows. The last row will always hold the string "</table>". 
 * The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print at the console a single line, holding the data row values with maximal sum in format: "sum = value1 + value2 + …". 
 * Print the values exactly as they were found in the input (no rounding, no reformatting). If all rows contain no data, print "no data". 
 * If two rows have the same maximal sum, print the first of them.
Constraints
•	The count of input rows is in the range [0 … 1 000].
•	The columns Store1, Store2 and Store3 hold numbers in the range [-100 0000 … 100 000].
•	There is no whitespace anywhere in the data rows.
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	                                                                    Output
<table>
<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>
<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>
<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>
<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>
<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>
</table>	                                                                65.3 = 11.2 + 18.00 + 36.10
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    static void Main()
    {
        // max sum storage and regex
        double maxSum = double.MinValue;
        List<string> storeValues = new List<string>();
        string pattern = @"<td>([0-9\.-]+)<\/td>";
        Regex num = new Regex(pattern);

        // input
        string line = Console.ReadLine();
        line = Console.ReadLine();

        while (true)
        {
            if (line == "</table>")
            {
                break;
            }
            line = Console.ReadLine();

            // check for max sum
            maxSum = CheckFor(num, line, maxSum, ref storeValues);
        }

        // print result
        if (storeValues.Count == 0)
        {
            Console.WriteLine("no data");
        }
        else
        {
            Console.WriteLine("{0} = {1}", maxSum, string.Join(" + ", storeValues));
        }
    }

    private static double CheckFor(Regex num, string line, double maxSum, ref List<string> storeValues)
    {
        double sum = 0;
        MatchCollection matches = num.Matches(line);
        List<string> storeValuesTemp = new List<string>();

        foreach (Match match in matches)
        {
            // calculate sum
            double number;
            string value = match.Groups[1].Value;
            bool isNumber = double.TryParse(value, out number);
            if (isNumber)
            {
                sum += number;
                storeValuesTemp.Add(value);
            }
        }

        // update max sum
        if (sum > maxSum && storeValuesTemp.Count > 0)
        {
            maxSum = sum;
            storeValues = storeValuesTemp;
        }
        return maxSum;
    }
}

