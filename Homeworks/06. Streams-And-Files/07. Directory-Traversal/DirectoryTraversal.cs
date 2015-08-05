/* Problem 7.	Directory Traversal
Traverse a given directory for all files with the given extension. Search through the first level of the directory only and write 
 * information about each found file in report.txt.
The files should be grouped by their extension. Extensions should be ordered by the count of their files (from most to least). 
 * If two extensions have equal number of files, order them by name.
Files under an extension should be ordered by their size.
report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class DirectoryTraversal
{
    private static void Main()
    {
        // get and store file info about all files in the current directory
        string[] filePaths = Directory.GetFiles(@"../../");

        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

        // sort file info
        var sorted =
            files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

        // locate desktop
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // create report file
        StreamWriter writer = new StreamWriter(desktop + "/report.txt");
        foreach (var group in sorted)
        {
            writer.WriteLine(group.Key);

            foreach (var y in group)
            {
                writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
            }
        }
        writer.Close();

        // open report file
        System.Diagnostics.Process.Start(desktop + "/report.txt");
    }
}
