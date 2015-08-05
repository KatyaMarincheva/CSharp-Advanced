/* Problem 10.	* Pythagorean Numbers
This problem is from the Java Basics Exam (26 May 2014). You may check your solution here.
George likes math. Recently he discovered an interesting property of the Pythagorean Theorem: 
 * there are infinite number of triplets of integers a, b and c (a ≤ b), such that a2 + b2 = c2. 
 * Write a program to help George find all such triplets (called Pythagorean numbers) among a set of integer numbers.
Input
The input data should be read from the console. At the first line, we have a number n – the count of the input numbers. 
 * At the next n lines we have n different integers.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print at the console all Pythagorean equations a2 + b2 = c2 (a ≤ b), which can be formed by the input numbers. 
 * Each equation should be printed in the following format: "a*a + b*b = c*c". The order of the equations is not important. 
 * Beware of spaces: put spaces around the "+" and "=". In case of no Pythagorean numbers found, print "No".
Constraints
•	All input numbers will be unique integers in the range [0 … 999].
•	The count of the input numbers will be in the range [1 ... 100].
•	Time limit: 0.3 sec. Memory limit: 16 MB.
Examples
Input	Output		
8       5*5 + 12*12 = 13*13
41      9*9 + 40*40 = 41*41
5       3*3 + 4*4 = 5*5
9
12
4
13
40
3			
 */

using System;
using System.Linq;

class PythagoreanNumbers
{
    static void Main()
    {
        // input
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // logic
        bool PythagoreanNums = false;
        for (int n1 = 0; n1 < n; n1++)
        {
            for (int n2 = 0; n2 < n; n2++)
            {
                for (int n3 = 0; n3 < n; n3++)
                {
                    int a = numbers[n1];
                    int b = numbers[n2];
                    int c = numbers[n3];
                    if (a <= b && (a * a + b * b == c * c))
                    {
                        // output option 1
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
                        PythagoreanNums = true;
                    }
                }
            }
        }

        // output option 2
        if (!PythagoreanNums)
        {
            Console.WriteLine("No");
        }
    }
}

