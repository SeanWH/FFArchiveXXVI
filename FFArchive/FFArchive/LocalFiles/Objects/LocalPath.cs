using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FFArchive.LocalFiles.Objects
{
    public static class LocalPath
    {
        public static string GetSite(string path)
        {
            int cnt = 0;
            while (cnt < 4)
            {
                int pos = path.LastIndexOf(Path.DirectorySeparatorChar);
                path = path.Substring(0, pos);
                cnt++;
            }

            int p = path.LastIndexOf(Path.DirectorySeparatorChar);
            return path.Substring(p+1);
        }

        public static string GetUniverse(string path)
        {
            int cnt = 0;
            while (cnt < 3)
            {
                int pos = path.LastIndexOf(Path.DirectorySeparatorChar);
                path = path.Substring(0, pos);
                cnt++;
            }

            int p = path.LastIndexOf(Path.DirectorySeparatorChar);
            return path.Substring(p+1);
        }

        public static string GetAuthor(string path)
        {
            int cnt = 0;
            while (cnt < 2)
            {
                int pos = path.LastIndexOf(Path.DirectorySeparatorChar);
                path = path.Substring(0, pos);
                cnt++;
            }

            int p = path.LastIndexOf(Path.DirectorySeparatorChar);
            path = path.Substring(p+1);
            return path;
        }

        public static string GetTitle(string path)
        {
            int pos = path.LastIndexOf(Path.DirectorySeparatorChar);
            path = path.Substring(0, pos);
            pos = path.LastIndexOf(Path.DirectorySeparatorChar);
            path = path.Substring(pos + 1);
            return path;
        }

        
    }
}
