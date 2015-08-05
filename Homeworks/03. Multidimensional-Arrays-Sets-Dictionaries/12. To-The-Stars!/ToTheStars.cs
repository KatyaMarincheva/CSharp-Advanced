/* Problem 12.	 * To the Stars!
This problem is from the JavaScript Basics Exam (4 September 2014). You may check your solution here.
The year is 2185 and the SSR Normandy spaceship explores our galaxy. Unfortunately, the ship suffered severe damage in the last battle with Batarian pirates, 
 * and her navigation system is broken. Your task is to write a JavaScript program to help the Normandy safely navigate through the stars back home.

The navigation field is a 2D grid. You are given the names of 3 star systems, along with their coordinates(sx, sy) and the Normandy's initial coordinates(nx, ny). 
 * Assume that a star's coordinates are in the center of a 2x2 rectangle. The Normandy always moves in an upwards direction, 1 unit every turn. 
 * Your task is to inform the Normandy of its current location during its movement.

The Normandy can only be at one location at a time. The possible locations are "<star1 name>", "<star2 name>", "<star3 name>" and "space". In other words, 
 * if the Normandy is in the range of Alpha-Centauri, her location is "alpha-centauri". If she's not in the range of any star system, her location is just "space".
Star systems will NOT overlap.
Example: the Normandy's initial location is at (8, 1). There, she in outside of any star system, so she is in "space". 
 * She starts moving up and her next two locations at (8, 2) and (8, 3) are again in "space". After that, at (8, 4), (8, 5), (8, 6) 
 * she is in the range of Alpha-Centauri – therefore, she is in "alpha-centauri". Her final location (8, 7) is outside any star, and her location is "space".
Input
The input is passed to the first JavaScript function found in your code as array of several arguments:
•	The first arguments will contain each star system's name and coordinates in the format "<name> <x> <y>", separated by spaces. 
 * The name will be a single word, without spaces.
•	The fourth argument will contain the Normandy's initial coordinates in the format "<x> <y>", separated by spaces.
•	The fifth, last argument, will contain the number n – the number of turns the Normandy will be moving.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output consists of n + 1 lines – the Normandy's initial location, plus the locations she was in during her movement, each on a separate line. 
 * All locations must be printed lowercase.
Constraints
•	The grid dimensions will be no larger than 30x30.
•	All star systems will be squares with a fixed size: 2x2.
•	The turns will be no more than 20.
•	Time limit: 0.3 sec. Memory limit: 16 MB.
Examples
Input			Input	Output
Sirius 3 7
Alpha-Centauri 7 5
Gamma-Cygni 10 10
8 1
6	
 * 
Output
space 
space
space
alpha-centauri
alpha-centauri
alpha-centauri
space 		
 */

using System;
using System.Linq;

class ToTheStars
{
    static void Main()
    {
        // get stars info
        string[] star1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string name1 = star1[0].ToLower();
        double x1 = double.Parse(star1[1]);
        double y1 = double.Parse(star1[2]);

        string[] star2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string name2 = star2[0].ToLower();
        double x2 = double.Parse(star2[1]);
        double y2 = double.Parse(star2[2]);

        string[] star3 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string name3 = star3[0].ToLower();
        double x3 = double.Parse(star3[1]);
        double y3 = double.Parse(star3[2]);

        // get Normandy info
        double[] NCoordinates = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse).ToArray();
        double nX = NCoordinates[0];
        double nY = NCoordinates[1];

        // get moves info
        int turns = int.Parse(Console.ReadLine());

        // apply the moves
        for (double i = nY; i <= nY + turns; i++)
        {
            bool insideRectangle1 = (nX >= x1 - 1) && (nX <= x1 + 1) && (i >= y1 - 1) && (i <= y1 + 1);
            bool insideRectangle2 = (nX >= x2 - 1) && (nX <= x2 + 1) && (i >= y2 - 1) && (i <= y2 + 1);
            bool insideRectangle3 = (nX >= x3 - 1) && (nX <= x3 + 1) && (i >= y3 - 1) && (i <= y3 + 1);

            if (insideRectangle1)
            {
                Console.WriteLine(name1);
            }
            else if (insideRectangle2)
            {
                Console.WriteLine(name2);
            }
            else if (insideRectangle3)
            {
                Console.WriteLine(name3);
            }
            else
            {
                Console.WriteLine("space");
            }
        }
    }
}

