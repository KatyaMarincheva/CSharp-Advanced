/* Problem 16 – Parachute
You find yourself in training for becoming the best parachute jumper in the world. 
 * At the beginning of the training you need to understand how gravity and wind work. 
 * You are given all the data from previous jumps of your colleagues. Your task is to determine 
 * how the jumper will finish his jump and where he will land exactly, based on the gravity and wind parameters.
You are given a layout, consisting of several input strings, representing a matrix. 
 * The jumper can be anywhere in the matrix and is denoted by the "o" symbol. 
 * You need to determine the movement of the jumper in iterations. 
 * On each iteration, the jumper first moves one line down, pulled by gravity. Additionally, the jumper moves sideways by the wind on the current line.
•	The ">" symbol means the wind is moving the jumper one position to the right. 
•	The "<" symbol means the wind is moving the jumper one position to the left.
The total direction of the wind on a single line may stack (e.g. ">>>" moves the jumper 3 positions to the right; "><<" moves the jumper 1 position to the left).
See the examples to better understand the motion of the jumper. 
The jumper can move only through air (the "-", ">" and "<" symbols). 
 * When the jumper hits the ground, water or a cliff, the jump is finished and you need to print the outcome of the jump.
When checking for a collision, you need to take into account only the destination cell in the matrix (do not check the path the jumper took to get there).
Input
•	The input will be read from the console.
•	It consists of strings, representing the rows of the matrix. The symbols are not separated by anything. 
•	The input ends with the keyword "END". 
•	The input data will always be valid and in the format described. 
Output
The output consists of two lines. The first line holds a string. There are 3 possible outcome messages:
•	If you have landed on the ground ("_" symbol), you are well and alive: "Landed on the ground like a boss!"
•	If you have landed in the water ("~" symbol), you have drowned: "Drowned in the water like a cat!"
•	If you have landed on a cliff ("/", "\" or "|" symbol), you have died: "Got smacked on the rock like a dog!
The second line holds the position (the row and col) of your landing.
Constraints
•	The row and col of the matrix will be in the range [0 … 20].
•	The jumper will never fly off the map.
•	Time limit: 0.1 sec. Memory limit: 16 MB.

Examples
Input			
--o----------------------
>------------------------
>------------------------
>-----------------/\-----
-----------------/--\----
>---------/\----/----\---
---------/--\--/------\--
<-------/----\/--------\-
\------/----------------\
-\____/------------------	
 * 
Output
Landed on the ground like a boss!
9 5		
 * 
 * 
 Input	
-------------o-<<--------
-------->>>>>------------
---------------->-<---<--
------<<<<<-------/\--<--
--------------<--/-<\----
>>--------/\----/<-<-\---
---------/<-\--/------\--
<-------/----\/--------\-
\------/--------------<-\
-\___~/------<-----------	
 * 
Output
Drowned in the water like a cat!
9 5
 */

using System;
using System.Collections.Generic;
using System.Linq;

class Parachute
{
    static void Main()
    {
        List<string> lines = new List<string>();

        // input
        int counter = 0;
        int playerRow = 0;
        int playerCol = 0;
        int totalCol = 0;

        string line = Console.ReadLine(); // reading first line separately as it doesn't affect the wind direction
        lines.Add(line);

        while (true)
        {
            // checking for start row/col
            playerCol = CheckForStartPoint(line, playerCol, counter, ref playerRow);

            // reading next line
            line = Console.ReadLine();

            if (line == "END")
            {
                break;
            }

            lines.Add(line);
            counter++;
        }

        while (true) 
        {
            // falling down until an obstacle is reached
            playerRow++;
            // calculating the total direction of the wind 
            playerCol = CalculateAndApplyWindDirection(lines, playerRow, playerCol);

            // switching obstacles (if reached)
            if (CheckForObstacles(lines, playerRow, playerCol)) return;
        }
    }

    private static bool CheckForObstacles(List<string> lines, int playerRow, int playerCol)
    {
        switch (lines[playerRow][playerCol])
        {
            case '_':
                Console.WriteLine("Landed on the ground like a boss!");
                Console.WriteLine("{0} {1}", playerRow, playerCol);
                return true;
            case '~':
                Console.WriteLine("Drowned in the water like a cat!");
                Console.WriteLine("{0} {1}", playerRow, playerCol);
                return true;
            case '\\':
            case '/':

            case '|':
                Console.WriteLine("Got smacked on the rock like a dog!");
                Console.WriteLine("{0} {1}", playerRow, playerCol);
                return true;
        }
        return false;
    }

    private static int CalculateAndApplyWindDirection(List<string> lines, int playerRow, int playerCol)
    {
        int left = lines[playerRow].Count(f => f == '<');
        int right = lines[playerRow].Count(f => f == '>');
        playerCol += right - left;
        return playerCol;
    }

    private static int CheckForStartPoint(string line, int playerCol, int counter, ref int playerRow)
    {
        int index = line.IndexOf("o");
        if (index > playerCol)
        {
            playerCol = index;
            playerRow = counter;
        }
        return playerCol;
    }
}

