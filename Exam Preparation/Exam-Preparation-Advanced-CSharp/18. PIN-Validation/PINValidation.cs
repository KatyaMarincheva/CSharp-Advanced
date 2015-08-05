/* Problem 18 – PIN Validation
You’re part of a very promising team of specialists, which is hired by the parliament to recreate the new electronic government in Bulgaria.
Your task is to write a program that reads data about the voters in an electronic poll: first and last name, gender and PIN (EGN in Bulgarian) 
 * and then verifies the PIN. The program should generate a JSON string for DB insert if the data is correct, or print "Incorrect data" in <h2></h2> heading tags.
The PIN is a 10-digit number, which consists of the following:
•	First 6 digits are the date of birth of the citizen in format yymmdd; if the person is born before 1900, the mm digits are +20. 
 * If the person is born after 2000, the mm digits are +40
•	Next 3 digits show the region, based on the regional city of birth;
•	The last of the above 3 digits shows the gender – even for male and odd for female;
•	One digit for checksum. In order to get the correct checksum you need to multiply each of the first 9 digits with [2,4,8,5,10,9,7,3,6] respectively, 
 * sum all and then divide by 11. The remainder is the checksum.
NOTE: if the remainder is 10, then the checksum is 0 (source: http://www.grao.bg/esgraon.html )
Example: 9912164756 as PIN we check the following:
•	991216 – translates to 16th December 1999 – correct date
o	995216 – translates to 16th December 2099
o	993216 – translates to 16th December 1899
•	475 – shows the regional city is Plovdiv
•	5 – shows the PIN is of a girl – correct gender
•	9*2 + 9*4 + 1*8 + 2*5 + 1*10 + 6*9 + 4*7 + 7*3 + 5*6 = 215. 215 / 11 = 19 (remainder 6) – correct checksum
Input
The input will be read from the console. The first and last name will be received on the first line. The gender will be received on the second line. 
 * The PIN will be received on the third line.
Output
If the PIN is not correct or the data is not in the format described, "Incorrect data" should be printed. Otherwise, 
 * print a JSON string with all the data (follow the format provided below).
Constraints
•	The name string will contain names. You should check if there are 2 words, each starting with an uppercase letter.
•	Gender will always be ‘male’ or ‘female’.
•	PIN will be a number. You should check if it is a 10-digit number.  
Examples
Input	
Ana Ivanova
female
9912164756	
 * 
Output
{"name":"Ana Ivanova","gender":"female","pin":"9912164756"}
 * 
Input	
Ivan Petrov
male
1234567890	
 * 
Output
<h2>Incorrect data</h2>
 */

using System;
using System.Linq;

class PINValidation
{
    static void Main()
    {
        // input names
        string[] names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        // validate names
        if (ValidateNames(names)) return;

        // input gender
        string gender = Console.ReadLine();

        // input PIN
        string PIN = Console.ReadLine();

        // read month
        int month = int.Parse(PIN.Substring(2, 2));

        // read year last digits
        int year = int.Parse(PIN.Substring(0, 2));

        if (ValidateMonthAndYear(ref month, ref year)) return;

        // read and validate day
        int day = int.Parse(PIN.Substring(4, 2));

        if (ValidateDays(day, year, month)) return;

        // validate gender digit
        if (ValidateGenderDigit(gender, PIN)) return;

        if (ChecksumValidation(PIN)) return;

        // print result
        Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", string.Join(" ", names), gender, PIN);
    }

    private static bool ChecksumValidation(string PIN)
    {
        int sum = 0;
        int[] digits = PIN.ToCharArray().Select(x => x - '0').ToArray();

        int[] factors = {2, 4, 8, 5, 10, 9, 7, 3, 6};
        for (int i = 0; i < factors.Length; i++)
        {
            sum += digits[i]*factors[i];
        }

        int checksum = sum%11;
        checksum = checksum < 10 ? checksum : 0;
        if (checksum != digits[9])

        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }
        return false;
    }

    private static bool ValidateGenderDigit(string gender, string PIN)
    {
        if ((gender == "female" && (PIN[8] - '0')%2 == 0) || (gender == "male" && (PIN[8] - '0')%2 != 0))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }
        return false;
    }

    private static bool ValidateDays(int day, int year, int month)
    {
        if (day < 1 || day > DateTime.DaysInMonth(year, month))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }
        return false;
    }

    private static bool ValidateNames(string[] names)
    {
        if (names.Length != 2)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }

        if (names.Any(t => !char.IsUpper(t.First())))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }
        return false;
    }

    private static bool ValidateMonthAndYear(ref int month, ref int year)
    {
// validate month and calculate year first digits
        if (month >= 20 && month <= 32)
        {
            year += 1800;
            month -= 20;
        }
        else if (month >= 1 && month <= 12)
        {
            year += 1900;
        }
        else if (month >= 40 && month <= 52)
        {
            year += 2000;
            month -= 40;
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return true;
        }
        return false;
    }
}

