using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileReadWriter
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all alpha characters from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAlphaCharacters(string input)
        {
            return Regex.Replace(input, "[^0-9,.;]", "");
        }

        /// <summary>
        /// Replace specified text in a string with a ;
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string ReplaceWithSemiColon(string input, string replace)
        {
            return Regex.Replace(input, replace, ";");
        }

        /// <summary>
        /// Get the nummer of lines in the string.
        /// </summary>
        /// <returns>Nummer of lines</returns>
        public static int LineCount(this string str)
        {
            return Regex.Matches(str, System.Environment.NewLine).Count;
        }
    }
}
