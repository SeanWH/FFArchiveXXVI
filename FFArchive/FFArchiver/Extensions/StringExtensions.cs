#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: StringExtensions.cs

#endregion File Info

namespace FFArchiver.Extensions
{
    using System.IO;

    public static class StringExtensions
    {
        /// <summary>
        ///     Returns true if the file supplied in path exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsLocalPath(this string path) => File.Exists(path);
    }
}