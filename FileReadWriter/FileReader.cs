using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReadWriter
{
    public class FileReader
    {
        /// <summary>
        /// Reads a file and outputs the entire contents as one string
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFileAsOneString(string filePath)
        {
            byte[] bytes;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                bytes = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(bytes, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }

            string text = Encoding.ASCII.GetString(bytes);
            return text;
        }

        /// <summary>
        /// Reads a file and outputs the file line by line as a list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ReadFileLineByLine(string filePath)
        {
            string line;
            List<string> lines = new List<string>();

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines;
        }
    }
}