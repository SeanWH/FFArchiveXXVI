#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary
// FILE: StringExtensions.cs

#endregion File Info

namespace NaeshLibrary.Extensions
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringExtensions
    {
        /// <summary>Determines if the path contains invalid characters.</summary>
        /// <remarks>This method is intended to prevent ArgumentException's from being thrown when creating a new FileInfo on a file path with invalid characters.</remarks>
        /// <param name="filePath">File path.</param>
        /// <returns>True if file path contains invalid characters.</returns>
        private static bool ContainsInvalidPathCharacters(string filePath)
        {
            for (var i = 0; i < filePath.Length; i++)
            {
                int c = filePath[i];

                if (c == '\"' || c == '<' || c == '>' || c == '|' || c == '*' || c == '?' || c < 32)
                    return true;
            }

            return false;
        }

        public static string Affix(this string target, string affix)
        {
            return $"{target}{affix}";
        }

        /// <summary>
        /// Checks a string array to see if ANY of the members
        /// are null, empty, or whitespace.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static bool IsAnyNullOrWhitespace(this string[] strings)
        {
            bool check = false;

            foreach (string str in strings)
            {
                check |= string.IsNullOrWhiteSpace(str);
            }

            return check;
        }

        public static bool IsInvalidPath(this string path)
        {
            return ContainsInvalidPathCharacters(path);
        }

        public static string Prefix(this string target, string prefix)
        {
            return $"{prefix}{target}";
        }

        public static int StringHash256(this string val)
        {
            using (var algo = new SHA256Managed())
            {
                algo.ComputeHash(Encoding.UTF8.GetBytes(val));
                var result = algo.Hash;
                return BitConverter.ToInt32(result, 0);
            }
        }

        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}