/* Problem 9.	 ** Semantic HTML
This problem is originally from the PHP Basics Exam (31 August 2014). You may check your solution here.
You are given an HTML code, written in the old non-semantic style using tags like <div id="header">, <div class="section">, etc. 
 * Your task is to write a program that converts this HTML to semantic HTML by changing tags like <div id="header"> to their semantic equivalent like <header>.
The non-semantic tags that should be converted are always <div>s and have either id or class with one of the following values: 
 * "main", "header", "nav", "article", "section", "aside" or "footer". Their corresponding closing tags are always 
 * followed by a comment like <!-- header -->, <!-- nav -->, etc. staying at the same line, after the tag.
Input
The input will be read from the console. It will contain a variable number of lines and will end with the keyword "END".
Output
The output is the semantic version of the input HTML. In all converted tags you should replace multiple spaces 
 * (like <header      style="color:red">) with a single space and remove excessive spaces at the end (like <footer      >). See the examples.
Constraints
•	Each line from the input holds either an HTML opening tag or an HTML closing tag or HTML text content.
•	There will be no tags that span several lines and no lines that hold multiple tags.
•	Attributes values will always be enclosed in double quotes ".
•	Tags will never have id and class at the same time.
•	The HTML will be valid. Opening and closing tags will match correctly.
•	Whitespace may occur between attribute names, values and around comments (see the examples).
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	
<div id="header">
</div> <!-- header -->
END	
 * 
Output
<header>
</header>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        // input
        List<string> results = new List<string>();
        string inputLine;
        string[] semanticTags = { "main", "header", "nav", "article", "section", "aside", "footer" };

        string openingTags = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";
        Regex users = new Regex(openingTags);
        string closeTagsPattern = @"<\/div>\s.*?(\w+)\s*-->";
        Regex closers = new Regex(closeTagsPattern);

        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            // opening tags
            MatchCollection matchesOp = users.Matches(inputLine);
            foreach (Match match in matchesOp)
            {
                string attrName = match.Groups[1].Value;
                string attrValue = match.Groups[3].Value;

                if (semanticTags.Contains(attrValue))
                {
                    string replaceTag = Regex.Replace(match.ToString(), "div", word => attrValue);
                    replaceTag = Regex.Replace(replaceTag, attrName, "");
                    replaceTag = Regex.Replace(replaceTag, "\\s*>", ">");
                    replaceTag = Regex.Replace(replaceTag, "\\s{2,}", " ");
                    inputLine = Regex.Replace(inputLine, match.ToString(), replaceTag);
                }
            }

            // closing tags
            MatchCollection matchesCl = closers.Matches(inputLine);
            foreach (Match match in matchesCl)
            {
                string commentValue = match.Groups[1].Value;
                if (semanticTags.Contains(commentValue))
                {
                    inputLine = Regex.Replace(inputLine, match.ToString(), String.Format("</" + commentValue + ">"));
                }
            }

            // storing result lines
            results.Add(inputLine);
        }

        // printing
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine(results[i]);
        }
    }
}

