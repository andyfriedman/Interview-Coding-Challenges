using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlgorithmAnalysis
{
    class Algorithms4
    {
        // Save all file lines that start with A to a new file
        // Must be able to handle very large files.
        public void SaveLines(string inputFilePath, string outputFilePath)
        {
            using (var inputStream = new FileStream(inputFilePath, FileMode.Open))
            using (var reader = new StreamReader(inputStream))
            using (var writer = new StreamWriter(outputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine() ?? string.Empty;
                    if (line.StartsWith("A")) // assuming only looking for uppercase A based on "requirements"
                    {
                        writer.Write(line);
                    }
                }
            }
        }
    }
}
