/* Problem 7 – Vladko's Notebook
Vladko Karamfilov (a.k.a. SUPER VLADO or St.Karamfilov) is a very famous table tennis player. He is also very organized. 
 * In order to become the best tennis player there is, he writes down everything about his opponents in a pretty notebook, 
 * covered in pink flowers. He is winning all his games, so he has a lot of hostile opponents. One night, one of them crawled 
 * into Vladko's room and tore his notebook apart into separate sheets of paper. Vladko needs your help to gather his information from all the sheets. 
 * Fortunately, Vladko writes everything about a single opponent on a sheet with a certain color (for example all information on red sheets is about opponent X, 
 * all information on blue sheets is about opponent Y etc.). You are given a list of colored sheets given as a text table with the following columns: 
	Option 01 – [color of the sheet]|[win/loss]|[opponent name]
	Option 02 – [color of the sheet]|[name]|[player name] 
	Option 03 – [color of the sheet]|[age]|[player age]
The different columns will always be separated only by 'I' (there won't be any whitespaces). 
 * The rank of each player is calculated by the formula rank = (wins+1) / (losses+1). 
 * If a certain color sheet has no information about the name or the age of the player, you should not print it in the output. 
 * If there is no information about the opponents, you must print "(empty)" where the opponents list should be. 
 * There might be many opponents with the same name. If there was no information recovered 
 * (no colors containing name and age), print only "No data recovered." Write a program to aggregate the results and print them as shown in the example below.
Input
The input comes from the console on a variable number of lines and ends when the keyword "END" is received. 
 * The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print at the console the information for each player (sorted by color name) that holds the age, the name, 
 * a list with the opponents (in alphabetical order) and rank of the player. Please follow exactly the format from the example below. 
 * The rank of the players should be rounded to 2 digits after the decimal point:
	1.5 -> 1.50; 1 -> 1.00; 1.3214123 -> 1.32
Constraints
•	The numbers of input lines is between 1 and 150.
•	The names of colors and players consist of Latin letters and spaces. Their length is between 1 and 50 characters.
•	The value of age will be an integer in the range [0 … 99].
•	Allowed working time: 0.3 seconds. Allowed memory: 32 MB.
Hints
•	The sorting of the opponents array should be done using the StringComparer.Ordinal option.
Examples
Input	
purple|age|99
red|age|44
blue|win|pesho
blue|win|mariya
purple|loss|Kiko
purple|loss|Kiko
purple|loss|Kiko
purple|loss|Yana
purple|loss|Yana
purple|loss|Manov
purple|loss|Manov
red|name|gosho
blue|win|Vladko
purple|loss|Yana
purple|name|VladoKaramfilov
blue|age|21
blue|loss|Pesho
END	
 * 
 Output
 Color: purple
-age: 99
-name: VladoKaramfilov
-opponents: Kiko, Kiko, Kiko, Manov, Manov, Yana, Yana, Yana
-rank: 0.11
Color: red
-age: 44
-name: gosho
-opponents: (empty)
-rank: 1.00
 */

using System;
using System.Collections.Generic;
using System.Linq;

class VladkosNotebook
{
    struct Player
    {
        public string Age;
        public string Name;
        public List<string> Wins;
        public List<string> Losses;
    }

    static void Main()
    {
        SortedDictionary<string, Player> notebook = new SortedDictionary<string, Player>();

        // read and parse input
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            string[] line = input.Split('|');

            string color = line[0];

            if (!notebook.ContainsKey(color))
            {
                AddNewPlayer(line, notebook, color);
            }
            else
            {
                UpdatePlayerInfo(notebook, color, line);
            }
        }

        bool dataRecovered = false;
        // if any data is recovered - print it
        dataRecovered = PrintDataRecovered(notebook, dataRecovered);

        if (dataRecovered == false)
        {
            Console.WriteLine("No data recovered.");
        }
    }

    private static bool PrintDataRecovered(SortedDictionary<string, Player> notebook, bool dataRecovered)
    {
        foreach (var pair in notebook)
        {
            List<string> lostAgaints = pair.Value.Losses;
            List<string> wonAgainst = pair.Value.Wins;
            if (pair.Value.Name != null && pair.Value.Age != null)
            {
                Console.WriteLine("Color: {0}\n-age: {1}\n-name: {2}",
                    pair.Key, pair.Value.Age, pair.Value.Name);
                dataRecovered = true;

                if (lostAgaints == null && wonAgainst == null)
                {
                    Console.WriteLine("-opponents: (empty)\n-rank: 1.00");
                }
                else if (lostAgaints != null && wonAgainst != null)
                {
                    double rank = (wonAgainst.Count + 1d) / (lostAgaints.Count + 1d);
                    string[] oponents = pair.Value.Wins.Concat(pair.Value.Losses).ToArray();
                    Print(oponents, rank);
                }
                else if (lostAgaints != null)
                {
                    double rank = 1d / (lostAgaints.Count + 1d);
                    string[] oponents = pair.Value.Losses.ToArray();
                    Print(oponents, rank);
                }
                else if (wonAgainst != null)
                {
                    double rank = (wonAgainst.Count + 1d);
                    string[] oponents = pair.Value.Wins.ToArray();
                    Print(oponents, rank);
                }
            }
        }
        return dataRecovered;
    }

    private static void UpdatePlayerInfo(SortedDictionary<string, Player> notebook, string color, string[] line)
    {
        Player currentPlayer = notebook[color];
        switch (line[1])
        {
            case "age":
                currentPlayer.Age = line[2];
                notebook[color] = currentPlayer;
                break;
            case "name":
                currentPlayer.Name = line[2];
                notebook[color] = currentPlayer;
                break;
            case "win":
                List<string> wins;
                if (currentPlayer.Wins == null)
                {
                    wins = new List<string>();
                }
                else
                {
                    wins = currentPlayer.Wins;
                }
                wins.Add(line[2]);
                currentPlayer.Wins = wins;
                notebook[color] = currentPlayer;
                break;
            case "loss":
                List<string> losses;
                if (currentPlayer.Losses == null)
                {
                    losses = new List<string>();
                }
                else
                {
                    losses = currentPlayer.Losses;
                }
                losses.Add(line[2]);
                currentPlayer.Losses = losses;
                notebook[color] = currentPlayer;
                break;
        }
    }

    private static void AddNewPlayer(string[] line, SortedDictionary<string, Player> notebook, string color)
    {
        Player currentPlayer = new Player();
        switch (line[1])
        {
            case "age":
                currentPlayer.Age = line[2];
                break;
            case "name":
                currentPlayer.Name = line[2];
                break;
            case "win":
                List<string> wins = new List<string>();
                wins.Add(line[2]);
                currentPlayer.Wins = wins;
                break;
            case "loss":
                List<string> losses = new List<string>();
                losses.Add(line[2]);
                currentPlayer.Losses = losses;
                break;
        }
        notebook.Add(color, currentPlayer);
    }

    private static void Print(string[] oponents, double rank)
    {
        Array.Sort(oponents, StringComparer.Ordinal);
        Console.WriteLine("-opponents: {0}\n-rank: {1:F2}", string.Join(", ", oponents), rank);
    }
}


