/* Problem 13.	 * Activity Tracker
This problem is from the Java Basics Exam (3 September 2014). You may check your solution here.
You are part of the server side application team of brand new and promising activity tracking company. 
 * Their product "The Spy" is constantly sending data to the server. The data represents the distance walked in meters for every user in format:
•	24/07/2014 Angel 4600
•	24/07/2014 Pesho 3200
•	25/07/2014 Angel 6500
•	01/08/2014 Pesho 5600
•	03/08/2014 Ivan 11400
Write a program to aggregate the data and print the activity of each user per month. 
 * The months should be represented in ascending order. The users should be ordered alphabetically and the data should be represented 
 * in the following way: <month>: <user>(<distance>), <user>(<distance>),… For the data above the output should be:
•	7: Angel(11100), Pesho(3200)
•	8: Ivan(11400), Pesho(5600)
Input
The input comes from the console. At the first line a number n stays which says how many data lines will follow. 
 * Each of the next n lines holds a data in format <date> <user> <distance>. The input data will always be valid and in the format described. 
 * There is no need to check it explicitly.
Output
Print one line for each month (months are in ascending order). For each month print the users and the sum of distances for each one of them, 
 * in descending order in format <month>: <user>(<distance>), <user>(<distance>),…
Constraints
•	The count of the data lines n is in the range [1…1000].
•	The <date> is a standard date in format dd/mm/yyyy where dd is the day of the month, 
 * mm is the numeric representation of the month and yyyy is the full numeric represenation of the year.
•	The <user> consists of only of Latin characters, with length of [1…20].
•	The <distance> is floating point number in the range [1…1000].
•	Time limit: 0.3 sec. Memory limit: 16 MB.
Example
Input		
5
24/07/2014 Angel 4600
24/07/2014 Pesho 3200
25/07/2014 Angel 6500
01/08/2014 Pesho 5600
03/08/2014 Ivan 11400	
 * 
Output
7: Angel(11100), Pesho(3200)
8: Ivan(11400), Pesho(5600)	
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

class ActivityTracker
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        // database
        SortedDictionary<int, SortedDictionary<string, List<double>>> walkingData = new SortedDictionary<int, SortedDictionary<string, List<double>>>();
        SortedDictionary<int, SortedSet<string>> finals = new SortedDictionary<int, SortedSet<string>>();


        // input
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            // read input
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int month = DateTime.Parse(input[0]).Month;
            string user = input[1];
            double distance = double.Parse(input[2]);

            // in case of new month
            if (!walkingData.ContainsKey(month))
            {
                SortedDictionary<string, List<double>> users = new SortedDictionary<string, List<double>>();
                List<double> distances = new List<double>();

                distances.Add(distance);
                users.Add(user, distances);
                walkingData.Add(month, users);
            }

            else if (walkingData.ContainsKey(month))
            {
                // in case of new user for existing month
                if (!walkingData[month].ContainsKey(user))
                {
                    List<double> distances = new List<double>();
                    distances.Add(distance);

                    walkingData[month].Add(user, distances);
                }
                // in case of new distance for existing user
                else if (walkingData[month].ContainsKey(user))
                {
                    walkingData[month][user].Add(distance);
                }
            }
        }

        foreach (var pair1 in walkingData)
        {
            SortedSet<string> usersInfo = new SortedSet<string>();
            foreach (var pair2 in pair1.Value)
            {
                // preparing user info for printing
                string userInfo = pair2.Key + "(" + pair2.Value.Aggregate((a, b) => b + a) + ")";
                usersInfo.Add(userInfo);
            }
            finals.Add(pair1.Key, usersInfo);
        }

        // printing
        foreach (var pair in finals)
        {
            Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
        }
    }
}