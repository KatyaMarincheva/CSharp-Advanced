/* Problem 17.	 * Office Stuff
This problem is from the Java Basics Exam (21 Sept 2014 Evening). You can test your solution here.
You are given a sequence of n companies in format |<company> - <amount> - <product>|. Example:
•	|SoftUni - 600 - paper|
•	|Vivacom - 600 - pen|
•	|XS - 20 - chair|
•	|Vivacom - 200 - chair|
•	|SoftUni - 40 - chair|
•	|XS - 40 - chair|
•	|SoftUni - 1 - printer|
Write a program that prints all companies in alphabetical order. For each company print the product type and their aggregated ordered amounts. Order the products by order of appearance. Print the result in the following format: <company>: <product>-<amount>, <product>-<amount>,… For the orders above the output should be:
•	SoftUni: paper-600, chair-40, printer-1
•	Vivacom: pen-600, chair-200
•	XS: chair-60
Input
The input comes from the console. At the first line the number n stays alone. At the next n lines, we have n orders in format |<company> - <amount> - <product>|.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print one line for each company. Company lines should be ordered in alphabetical order. 
 * For each company print the products ordered by this company in order of appearance, 
 * along with the total amount for the given product. Each line should be in format <company>: <product>-<amount>, <product>-<amount>, … <product>-<amount>
Constraints
•	The count of the lines n will be in the range [1 … 100].
•	The <company> and <product> will consist of only of Latin characters, with length of [1 … 20].
•	The <amount> will be an integer number in the range [1 … 1000].
•	Time limit: 0.1 sec. Memory limit: 16 MB.
Examples
Input			
7
|SoftUni - 600 - paper|
|Vivacom - 600 - pen|
|XS - 20 - chair|
|Vivacom - 200 - chair|
|SoftUni - 40 - chair|
|XS - 40 - chair|
|SoftUni - 1 - printer|	
 * 
 Output
 SoftUni: paper-600, chair-40, printer-1
Vivacom: pen-600, chair-200
XS: chair-60		
 */

using System;
using System.Collections.Generic;
using System.Linq;

class OfficeStuff
{
    static void Main()
    {
        // storage
        SortedDictionary<string, Dictionary<string, int>> companyOrders = new SortedDictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            // order input
            string[] order = Console.ReadLine().Split(new char[] {'|', '-', ' '}, StringSplitOptions.RemoveEmptyEntries);

            FillDictionary(order, companyOrders);
        }

        // print
        Print(companyOrders);
    }

    private static void Print(SortedDictionary<string, Dictionary<string, int>> companyOrders)
    {
// this list prepares the results for final formating
        List<string> result = new List<string>();

        foreach (var pair1 in companyOrders)
        {
            Console.Write("{0}: ", pair1.Key);

            result.AddRange(pair1.Value.Select(pair2 => String.Format("{0}-{1}", pair2.Key, pair2.Value)));
            Console.WriteLine(string.Join(", ", result));
            result.Clear();
        }
    }

    private static void FillDictionary(string[] order, SortedDictionary<string, Dictionary<string, int>> companyOrders)
    {
        string company = order[0];
        string product = order[2];
        int amount = int.Parse(order[1]);

        // storing the order details into the dictionary 
        if (!companyOrders.ContainsKey(company))
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add(product, 0);

            companyOrders.Add(company, products);
        }
        else if (!companyOrders[company].ContainsKey(product))
        {
            companyOrders[company].Add(product, 0);
        }
        companyOrders[company][product] += amount;
    }
}

