/* Problem 9.	* Disk
In geometry, a disk is the region in a plane bounded by a circle (it also includes the circle itself). 
 * Your task is to print a disk on the console by given radius R in a square field of size N x N (see the examples below).
Input
The input data should be read from the console.
•	On the first line of the input you will be given the size of the field N. On the second line of the input you will be given the radius of the disk R.
•	The disk’s center is the center point of the field (it will always exist, because N is odd).
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output should be printed on the console. You should print the disk on the console following the examples below.
•	Your output must consist of N rows, each containing N characters. Each character represents a point in the field. 
 * For every point you must output one of two possible states – dot ‘.’ if the point lies outside of the disk and asterisk ‘*’ if the point lies within the disk.
Hint: In order to check whether a point is inside or outside of a circle, 
 * you may calculate the distance from the point to the center of the field by the Pythagorean’s theorem (see http://goo.gl/HwqOuU).
Constraints
•	The number N is a positive odd integer in the range [3…39], inclusive.
•	The number R is a positive integer between 1 and   (floor (N/2)), inclusive. This means that the disk will always fit in the field, without crossing its sides.
 */

using System;

class Disk
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int R = int.Parse(Console.ReadLine());

        int center_x = N / 2;
        int center_y = N / 2;

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                bool insideCircle = Math.Pow((col - center_x), 2) + Math.Pow((row - center_y), 2) <= Math.Pow(R, 2);

                if (insideCircle)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}
