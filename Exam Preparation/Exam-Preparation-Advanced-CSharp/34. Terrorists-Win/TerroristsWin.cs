/* Problem 9.	* Terrorists Win!
This problem is from the Java Basics Exam (7 January 2015). You may check your solution here.
On de_dust2 terrorists have planted a bomb (or possibly several of them)! Write a program that sets those bombs off!
A bomb is a string in the format |...|. When set off, the bomb destroys all characters inside. 
 * The bomb should also destroy n characters to the left and right of the bomb. n is determined by the bomb power 
 * (the last digit of the ASCII sum of the characters inside the bomb). Destroyed characters should be replaced by '.' (dot). For example, we are given the following text:
 prepare|yo|dong
The bomb is |yo|. We get the bomb power by calculating the last digit of the sum: y (121) + o (111) = 232. 
 * The bomb explodes and destroys itself and 2 characters to the left and 2 characters to the right. The result is:
 prepa........ng
Input
The input data should be read from the console. On the first and only input line you will receive the text. 
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The destroyed text should be printed on the console.
Constraints
•	The length of the text will be in the range [1...1000].
•	The bombs will hold a number of characters in the range [0…100].
•	Bombs will not be nested (i.e. bomb inside another bomb).
•	Bomb explosions will never overlap with other bombs.
•	Time limit: 0.3 sec. Memory limit: 16 MB. 
Examples
Input	Output
prepare|yo|dong	prepa........ng
 */

using System;
using System.Linq;

class TerroristsWin
{
    static void Main()
    {
        // input
        string text = Console.ReadLine();

        // logic
        // get first index
        int firstIndex = text.IndexOf('|');
        int secondIndex = 0;
        int ASCIISum = 0;
        int spreadArea = 0;

        while (firstIndex != -1)
        {
            // get second index
            secondIndex = text.IndexOf('|', firstIndex + 1);

            // calculate bomb power
            int bombLength = secondIndex - (firstIndex + 1);
            string bomb = text.Substring(firstIndex + 1, bombLength);
            ASCIISum = bomb.ToCharArray().Select(c => (int)c).Sum();
            spreadArea = ASCIISum % 10;

            // adjust start and end indexes to text length
            int startIndex = firstIndex - spreadArea;
            int endIndex = secondIndex + spreadArea;
            startIndex = startIndex > 0 ? startIndex : 0;
            endIndex = endIndex < text.Length ? endIndex : text.Length - 1;

            // total destryed area
            int destroyedArea = endIndex - startIndex + 1;

            // replace destroyed area with dots
            text = text.Remove(startIndex, destroyedArea).Insert(startIndex, new string('.', destroyedArea));

            // check if next first index exists
            firstIndex = text.IndexOf('|', secondIndex + 1);
        }

        Console.WriteLine(text);
    }
}


