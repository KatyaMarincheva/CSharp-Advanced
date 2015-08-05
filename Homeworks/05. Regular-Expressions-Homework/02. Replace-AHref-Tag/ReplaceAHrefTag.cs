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
using System.Text.RegularExpressions;

class ReplaceAHrefTag
{
    static void Main()
    {
        string html = @"<ul>
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul>";
        string pattern = "<a(\\shref=.+)>(.+)<\\/a>";

        Console.WriteLine(Regex.Replace(html, pattern, @"[URL href=$1]$2[/URL]"));
    }
}

