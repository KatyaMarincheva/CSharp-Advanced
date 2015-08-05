/* Problem 21 – IT Village
Every Friday night a group of super cool programmers get together and play their favorite board game – "IT Village". But they are so tired of coding through the week they forget the rules of the game all the time. Also, they find it very difficult to work with paper and roll the dice so they made a very important decision – their game needed to evolve from a board game into a computer game. It is a well-known fact that programmers are lazy. They started programming the game, but they stopped. Your task is to finish the game for them.
You are given a game board which is 4 fields high and 4 fields wide. You can play only on the game fields (the first and the last row, as well as the first and the last column). All other fields are always empty and you cannot play on them. You start the game on an entering position (on one of the game fields) and you roll the dice. You move on the game fields clockwise. You have the following types of fields:
Field Name	Letter in the Input	Description	Money Gain(+) / Loose(-)	Occurrences in the Game
Wi-Fi pub	P	You have to buy one Cloud Cocktail	-5 coins	Many 
Wi-Fi Inn
	I	1)	If you have enough money you have to buy the Inn
2)	If you don't – you pay for your stay
3)	Assume you won’t land on an inn you already own	1)	-100 coins
2)	-10 coins	Many
Freelance Project	F	You get paid	20 coins	Many
Storm	S	The Wi-Fi in the village dies and you get so depressed that you miss 2 moves	-	Many
Super Vlado	V	Your coins are multiplied by 10	*10	Only 1 field
Nakov	N	When you step on this field you immediately win the game	-	1 or no such field
Empty Field	0	Empty field	-	Always 4
You start the game with 50 coins. For every inn you own, you gain 20 coins per inn per move. 
 * When you skip moves because of a storm you do not get paid for inns. The coins for inns are added to your money in the 
 * beginning of every move (from the next one you bought the inn).
The game ends in the following cases:
Game End Case	Output
If you run out of money (< 0 coins)	<p>You lost! You ran out of money!<p>
If you buy all the inns	<p>You won! You own the village now! You have {0} coins!<p>
If you run out of moves	<p>You lost! No more moves! You have {0} coins!<p>
If you step on the "Nakov" field	<p>You won! Nakov's force was with you!<p>
Note: {0} is how much coins you have when the game ends.
Input
The input will be read from the console. The game board will be received as a string on the first line. 
 * The entering position will be received on the second line. The numbers on the dice for each move will be received on the third line.
Output
The output consists of a paragraph, containing one of the messages in the 'Output' column in the table above.
Constraints
•	The game board will always be 4 fields wide and 4 fields high. The string for the game board contains the letter combinations: 
 * P, I, F, S, V, N, or 0. The letter N is optional. All the other letters will always be on the game board. The letter combinations are separated by a space. 
 * The rows are separated by a ' | '.
•	The entering position will consist of two numbers, separated by a space. The first number is the row number, 
 * the second – the column number. For example '3 4' means that the entering position is row 3, column 4 (indexing starts from 1).
•	The dice numbers are received as a string of numbers from 2 to 12, separated by a space.
Examples
Input	Output
P I F S | P 0 0 F | N 0 0 V | I F F I
2 1
5 11 9 8 6 8 4	<p>You lost! No more moves! You have 500 coins!<p>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ITVIllage
{
    static void Main()
    {
        // input
        var gameBoardInput = (Console.ReadLine().Split(new[] {' ', '|', '0'}, StringSplitOptions.RemoveEmptyEntries)).ToList();

        // convert gameboard input into a "circular" string around the playfield
        var gameBoard = CreateGameBoardString(gameBoardInput);
        //Console.WriteLine(gameBoard);
        // count inns
        var innsCount = InnsCount(gameBoard);
        // PIFSFVIFFINP

        // calculate entering position
        var startIndex = StartIndex();

        // go round the gameboard as per dice numbers
        int coins = 50;
        int inns = 0;
        // input dice rolls
        int[] diceNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < diceNumbers.Length; i++)
        {
            coins += 20 * inns;

            startIndex = (startIndex + diceNumbers[i]) % 12;

            char currentLocation = gameBoard[startIndex];

            switch (currentLocation)
            {
                case 'P':
                    coins -= 5;
 
                    break;
                case 'I':

                    if (coins >= 100)
                    {
                        coins -= 100;
                        inns++;
                    }
                    else
                    {
                        coins -= 10;
                    }
                    break;
                case 'F':
                    coins += 20;
                    break;
                case 'S':
                    i += 2;
                    break;
                case 'V':
                    coins *= 10;
                    break;
                case 'N':
                    Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                    return;
            }

            // end game scenarios
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return;
            }
            if (inns == innsCount)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
                return;
            }
        }

        Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
    }

    private static int StartIndex()
    {
        int startIndex = 0;
        int[] enteringPosition = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int row = enteringPosition[0];
        int col = enteringPosition[1];
        if (row == 1)
        {
            startIndex = col - 1;
        }
        else if (row == 2)
        {
            switch (col)
            {
                case 1:
                    startIndex = 11;
                    break;
                case 4:
                    startIndex = 4;
                    break;
            }
        }
        else if (row == 3)
        {
            switch (col)
            {
                case 1:
                    startIndex = 10;
                    break;
                case 4:
                    startIndex = 5;
                    break;
            }
        }
        else if (row == 4)
        {
            switch (col)
            {
                case 1:
                    startIndex = 9;
                    break;
                case 2:
                    startIndex = 8;
                    break;
                case 3:
                    startIndex = 7;
                    break;
                case 4:
                    startIndex = 6;
                    break;
            }
        }
        return startIndex;
    }

    private static int InnsCount(string gameBoard)
    {
        string pattern = @"(I)";
        Regex inn = new Regex(pattern);
        MatchCollection matches = inn.Matches(gameBoard);
        int innsCount = matches.Count;
        return innsCount;
    }

    private static string CreateGameBoardString(List<string> gameBoardInput)
    {
        string six = gameBoardInput[6];
        gameBoardInput.RemoveAt(6);
        string four = gameBoardInput[4];
        gameBoardInput.RemoveAt(4);
        var temp = gameBoardInput.Skip(6).Take(4);
        temp = temp.Reverse().ToList();
        gameBoardInput.RemoveRange(6, 4);
        gameBoardInput = gameBoardInput.Concat(temp).ToList();
        gameBoardInput.Add(six);
        gameBoardInput.Add(four);
        string gameBoard = string.Join("", gameBoardInput);
        return gameBoard;
    }
}

