/* Problem 5.	Collect the Coins
Working with multidimensional arrays can be (and should be) fun. Let's make a game out of it.
You receive the layout of a board from the console. Assume it will always have 4 rows which you'll get as strings, each on a separate line. 
 * Each character in the strings will represent a cell on the board. Note that the strings may be of different length.
You are the player and start at the top-left corner (that would be position [0, 0] on the board). 
 * On the fifth line of input you'll receive a string with movement commands which tell you where to go next, 
 * it will contain only these four characters – '>' (move right), '<' (move left), '^' (move up) and 'v' (move down).  
 * You need to keep track of two types of events – collecting coins (represented by the symbol '$' of course) 
 * and hitting the walls of the board (when the player tries to move off the board to invalid coordinates). 
 * When all moves are over, print the amount of money collected and the number of walls hit. Example:
Input	Output	Comments
Sj0u$hbc
$87yihc87
Ewg3444
$4$$
V>>^^>>>VVV<<	Coins collected: 2
Walls hit: 2	Starting from (0, 0), move down (coin), twice right, up, up again (wall), 
 * three times right (coin on second move), twice down, down again (wall), twice to the left – game over (no more moves). 
 * Total of two coins collected and two walls hit in the process.
 */

using System;

class CollectTheCoins
{
    private static void Main()
    {
        // input
        string[] board = new string[4];
        for (int i = 0; i < 4; i++)
        {
            board[i] = Console.ReadLine();
        }
        char[] commands = Console.ReadLine().ToCharArray();

        // logic
        int x = 0;
        int y = 0;
        int coins = 0;
        int hits = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            switch (commands[i])
            {
                case '>':
                    int temp = y + 1;
                    if (temp < board[x].Length)
                    {
                        y = temp; // apply new position if valid
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case '<':
                    temp = y - 1;
                    if (temp >= 0)
                    {
                        y = temp; // apply new position if valid
                        if (board[x][y] == '$')
                        {
                            y = temp;
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case '^':
                    temp = x - 1;
                    if (temp >= 0)
                    {
                        x = temp; // apply new position if valid
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case 'v':
                    temp = x + 1;
                    if (temp < 4)
                    {
                        x = temp; // apply new position if valid
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
            }
        }

        // output
        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine("Walls hit: {0}", hits);
    }
}

