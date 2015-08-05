/* Problem 15 – The Numbers
"The numbers, Mason, what do they mean?"
We’ve just received a ton of unreadable signals from the International Space Station. We've lost all contact with the team up there, 
 * and all we got are these messages. Aliens? Might be. Can you please clear up the messages for us, so we can pass them to the decryption team?

Your job is to clear the text from any unnecessary symbols (only the numbers are needed) and convert the remaining number sequences to hex format. 
 * If a hex value has less than 4 characters, you need to add leading zeros. Finally, you need to place a "0x" prefix before each hex value and 
 * concatenate them all with dashes '-'. 

For example, we have the following message: "5tffwj(//*7837xzc2---34rlxXP%$". After trimming the unnecessary data (non-numeric characters), 
 * we've got the numbers 5, 7837, 2 and 34 left. We convert them to hex: 5, 1E9D, 2, 22; add leading zeros where needed: 0005, 1E9D, 0002, 0022, 
 * place 0x before each one and concatenate them with dashes: 0x0005-0x1E9D-0x0002-0x0022. 
(Note: hex values MUST be uppercase)
Input
The input data will be received from the console. It consists of a single line – the initial message you need to transform.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output consists of only one line – the transformed message. 
Constraints
•	The message will be no longer than 10000 characters.
•	The message will consist of ASCII characters only.
•	The numbers encoded in the message will be in the range [0 … 65 535].
•	Time limit: 0.1 sec. Memory limit: 16 MB.
Examples
Input	                            Output	  	                    Input	                                            Output	

	Input	Output
5tffwj(//*7837xzc2---34rlxXP%$”.	0x0005-0x1E9D-0x0002-0x0022		482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312	0x01E2-0x00D5-0xA17D-0xA568-0x0138
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main(string[] args)
    {
        // input
        string message = Console.ReadLine();

        // regex
        string numberPattern = @"([0-9]+)";
        Regex num = new Regex(numberPattern);
        MatchCollection matches = num.Matches(message);

        // string to numbers to hex
        List<string> hexNumbers = (from Match match in matches select String.Format("0x{0}", int.Parse(match.Groups[1].Value).ToString("X").PadLeft(4, '0'))).ToList();

        // printing
        Console.WriteLine(string.Join("-", hexNumbers));
    }
}

