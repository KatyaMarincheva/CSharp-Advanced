using System;
using System.IO;

class CopyBinaryFile
{
    const string NImagePath = "../../text.txt"; 
    const string DestinationPath = "../../result.txt";

    static void Main()
    {
        using (var source = new FileStream(NImagePath, FileMode.Open))
        {
            using (var destination = new FileStream(DestinationPath, FileMode.Create))
            {
                byte[] buffer = new byte[source.Length];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    destination.Write(buffer, 0, readBytes);
                }
            }
        }

        // open image file with results
        System.Diagnostics.Process.Start(@"..\..\result.jpg");
    }
}

