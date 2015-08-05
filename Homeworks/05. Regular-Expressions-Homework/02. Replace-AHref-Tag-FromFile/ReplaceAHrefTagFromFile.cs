/* Problem 2.	Replace <a> tag
Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> 
 * with corresponding tags [URL href=…]…[/URL]. Print the result on the console. Examples:
Input	
"<ul>
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul>"	
 * 
 Output
 <ul>
 <li>
  [URL href=http://softuni.bg]SoftUni[/URL]
 </li>
</ul>
 */

using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceAHrefTagFromFile
{
    static void Main()
    {
        // read file HTML-AHref.txt saved in same folder as the project .cs file
        string html = File.ReadAllText(@"..\..\HTML-AHref.txt");

        string pattern = @"<a(.*href=(.|\n)*?(?=>))>((.|\n)*?(?=<))<\/a>";

        // create new file
        using (StreamWriter URL = new StreamWriter(@"..\..\HTML-URL.txt"))
        {
            // write on the new file, the URL-replaced string
            URL.WriteLine(Regex.Replace(html, pattern, @"[URL$1]$3[/URL]"));
        }

        // print output file to the console
        string fileContents = File.ReadAllText(@"..\..\HTML-URL.txt");
        Console.WriteLine(fileContents);
    }
}

