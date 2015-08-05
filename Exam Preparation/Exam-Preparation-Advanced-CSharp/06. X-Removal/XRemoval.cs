/* Problem 6 – X-Removal
You are given a sequence of text lines, holding only visible symbols, small and capital Latin letters. Your task is to remove all X shapes in the text. They may consist of small and capital letters at the same time, or any visible symbol. All of the X shapes below are valid:
a a
 a
a a		etc.
An X Shape is 3 by 3 symbols crossing each other on 3 lines. A single X shape can be part of multiple X shapes. 
 * If new X Shapes are formed after the first removal you don't have to remove them.
Input
The input data comes as comes from the console on a variable number of lines, ending with the keyword "END".
Output
Print at the console the input data after removing all X shapes.
Constraints
•	Each input line will hold between 1 and 100 Latin letters.
•	The number of input lines will be in the range [1 ... 100].
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input			
abnbjs
xoBab
Abmbh
aabab
ababvvvv
END	
 * 
Output
anjs
xoa
Amh
aaa
aavvvv		
 */

using System;
using System.Collections.Generic;

class XRemoval
{
    static void Main()
    {
        // databases
        List<string> lines = new List<string>();
        List<string> finals = new List<string>();

        // input
        while (true)
        {
            string input = Console.ReadLine();

            if (input != "END")
            {
                lines.Add(input);
                finals.Add(input);
            }
            else
            {
                break;
            }
        }

        // logic
        // loop over every triplet of lines
        for (int i = 0; i < lines.Count - 2; i++)
        {
            string first = lines[i];
            string second = lines[i + 1];
            string third = lines[i + 2];
            int length1 = first.Length;
            int length2 = second.Length;
            int length3 = third.Length;

            // check for X
            for (int j = 0; j < length1 - 2 && j < length3 - 2 && j < length2 - 1; j++)
            {
                var plus = CheckForX(j, first, second, third);

                if (plus)
                {
                    UpdateFinals(finals, i, j);
                }
            }
        }

        // print
        PrintFinals(finals);
    }

    private static void PrintFinals(List<string> finals)
    {
        for (int i = 0; i < finals.Count; i++)
        {
            finals[i] = finals[i].Replace("К", "");
            Console.WriteLine(finals[i]);
        }
    }

    private static void UpdateFinals(List<string> finals, int i, int j)
    {
        finals[i] = finals[i].Remove(j, 1).Insert(j, "К");
        finals[i] = finals[i].Remove(j + 2, 1).Insert(j + 2, "К");
        finals[i + 1] = finals[i + 1].Remove(j + 1, 1).Insert(j + 1, "К");
        finals[i + 2] = finals[i + 2].Remove(j, 1).Insert(j, "К");
        finals[i + 2] = finals[i + 2].Remove(j + 2, 1).Insert(j + 2, "К");
    }

    private static bool CheckForX(int j, string first, string second, string third)
    {
        string up1 = first.Substring(j, 1).ToLower();
        string up2 = first.Substring(j + 2, 1).ToLower();
        string middle = second.Substring(j + 1, 1).ToLower();
        string down1 = third.Substring(j, 1).ToLower();
        string down2 = third.Substring(j + 2, 1).ToLower();
        bool X = up1 == up2 && up1 == middle && up1 == down1 && up1 == down2;
        return X;
    }
}


