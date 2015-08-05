/* Problem 1.	Odd Lines
Write a program that reads a text file and prints on the console its odd lines. Line numbers starts from 0. Use StreamReader.
 */

using System;
using System.IO;
using System.Text;

class OddLines
{
    static void Main(string[] args)
    {
        try
        {
            // input
            StreamReader reader = new StreamReader(@"..\..\OddLines.cs", Encoding.GetEncoding("windows-1251"));

            string s;
            int lineNumber = 0;

            // algorithm: line number increases twice, the reader reads twice, console prints once
            using (reader)
            {
                do
                {
                    s = reader.ReadLine();
                    lineNumber++;
                    s = reader.ReadLine();
                    Console.WriteLine("Line {0, 2}: {1}", lineNumber, s);
                    lineNumber++;
                } while (s != null);
            }
        }

            // in case no file is found
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }
}


