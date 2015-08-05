/* Problem 19 – Chat Logger
Write a program that receives several messages and the current date, sorts those messages by date and prints the time from the last message to the current date.

The messages will be in format [message] / [date], where date is in format dd-mm-YYYY hours:min:secs. 
 * The messages should be sorted by date and their text should be printed in <div></div> tags on a separate line. 
 * For example we are given the current date 12-08-2014 10:14:23 and the following messages:
Thanks :) / 11-08-2014 22:54:52
Hey John, happy birthday! / 10-08-2014 00:00:00
After sorting the messages by date in ascending order (from oldest to most recent), the result is:
<div>Hey John, happy birthday!</div>
<div>Thanks :)</div>
Finally, the time since the most recent message should be printed in the following way:
•	a few moments ago if it was less than 1 minute ago
•	[full minutes] minute(s) ago if it was less than 1 hour ago
•	[full hours] hour(s) ago if it was less than 24 hours ago on the same day
•	yesterday if it was the previous date, regardless of the time difference
•	[date] if it was earlier than yesterday, where date is in format dd-mm-YYYY
The resulting timestamp should be printed as follows:  <p>Last active: <time>[timestamp]</time></p>. 
 * In this case, the difference between the current date and the last message is 11 full hours, 
 * but since the message's day is 1 day before the current day, we print yesterday:
	<p>Last active: <time>yesterday</time></p>
Input
The input will be read from the console. The current time will be received on the first line. 
 * The messages come will be received on the next input lines, each message on a separate line. The input ends with the command "END".
Output 
Each message should be printed in its own <div></div> tags, on a separate line. On the final line, 
 * the difference between the current date and the last message date should be printed in the format described above. 
 * Ensure the HTML special characters are correctly encoded (use SecurityElement.Excape).
Constraints
•	All input dates will be in format dd-mm-YYYY hours:min:secs.
•	The received messages will always be in format [message] / [date] (with space around the delimiter '/').
•	There will be exactly one message on a single line.
•	There will be no messages with the same date.
•	The current date will always be after any message's date.
 
Examples
Input	
12-08-2014 10:14:23
Thanks :) / 11-08-2014 22:54:52
Hey John, happy birthday! / 10-08-2014 00:00:00
END	
 * 
Output
<div>Hey John, happy birthday!</div>
<div>Thanks :)</div>
<p>Last active: <time>yesterday</time></p>
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

class ChatLogger
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        var messages = new SortedDictionary<DateTime, string>();

        // input current time
        var currentTime = DateTime.Parse(Console.ReadLine());

        // input messages
        while (true)
        {
            string line = Console.ReadLine();

            if (line == "END")
            {
                break;
            }
            string pattern = @"(\s+\/+\s+)";
            var data = Regex.Split(line, pattern);

            messages.Add(DateTime.Parse(data[2]), data[0]);
        }

        DateTime mostRecentDate = messages.Last().Key;
        TimeSpan time = currentTime - mostRecentDate;

        // check for time span
        foreach (var pair in messages)
        {
            Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(pair.Value));
        }
        if (mostRecentDate.Day < currentTime.Day - 1)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", mostRecentDate.ToString("dd-MM-yyyy"));
        }

        else if (mostRecentDate.Day == currentTime.Day - 1)
        {
            Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
        }
        else if (mostRecentDate.Day == currentTime.Day && time.TotalHours >= 1)
        {
            Console.WriteLine("<p>Last active: <time>{0} hour(s) ago</time></p>", (int)time.TotalHours);
        }
        else if (time.TotalHours < 1 && time.TotalMinutes >= 1)
        {
            Console.WriteLine("<p>Last active: <time>{0} minute(s) ago</time></p>", (int)time.TotalMinutes);
        }
        else
        {
            Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
        }
    }
}

