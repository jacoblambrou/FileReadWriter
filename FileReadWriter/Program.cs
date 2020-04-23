using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FileReadWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string readDirectory = @"C:\Users\Jacob Lambrou\Downloads\nmapResults";
            string[] filePathsToRead = Directory.GetFiles($"{readDirectory}");

            string filePathToWrite = $@"{readDirectory}\output.txt";

            for (var i = 0; i < filePathsToRead.Length; i++)
            {
                string filePath = filePathsToRead[i];
                string fileName = Path.GetFileName(filePathsToRead[i]);
                List<string> file = FileReader.ReadFileLineByLine(filePath);

                for (var line = 0; line < file.Count; line++)
                {
                    if (file[line].Length > 33 && !file[line].StartsWith("#") && file[line].Contains('/'))
                    {
                        var text = StringExtensions.ReplaceWithSemiColon(file[line], "Ports");
                        text = StringExtensions.RemoveAlphaCharacters(text);

                        File.AppendAllText(filePathToWrite, $"{fileName};{text}\r\n");
                    }
                }
            }
        }
    }
}