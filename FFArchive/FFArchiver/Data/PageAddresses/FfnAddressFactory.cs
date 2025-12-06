#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: FfnAddressFactory.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using System;
    using System.IO;

    public static class FfnAddressFactory
    {
        private const int AUTHOR_ID = 2;
        private const int AUTHOR_NAME = 3;
        private const int CHAPTER_IDX = 3;
        private const int GROUP_ID = 3;
        private const int GROUP_NAME = 2;
        private const int STORY_ID = 2;
        private const int STORY_NAME = 4;
        private const int TARGET_IDX = 1;

        private static string CleanTitle(string text)
        {
            char[] illegal = Path.GetInvalidFileNameChars();
            string temp = text;
            foreach (char c in illegal)
            {
                temp = temp.Replace(c, '-');
            }

            return temp;
        }

        private static string FormatTitle(string title)
        {
            int pos = title.IndexOf("Chapter", StringComparison.OrdinalIgnoreCase);
            if (pos <= 0)
            {
                return title;
            }

            string formattedTitle = title.Substring(0, pos).Trim();
            formattedTitle = CleanTitle(formattedTitle);
            return formattedTitle;
        }

        private static string RemoveProtocol(string address)
        {
            if (address.StartsWith("https://"))
            {
                //removes https://www.
                address = address.Substring(12);
            }

            if (address.StartsWith("http://"))
            {
                //removes http://www.
                address = address.Substring(11);
            }

            return address;
        }

        private static string[] SplitAddress(string address)
        {
            address = RemoveProtocol(address);

            return address.Split('/');
        }

        public static IFfnAddress GetAddress(string address)
        {
            string[] parts = SplitAddress(address);

            switch (parts[TARGET_IDX])
            {
                case "s":
                    return new StoryAddress(address, parts[STORY_ID], parts[STORY_NAME], "", parts[CHAPTER_IDX]);

                case "u":
                    return new AuthorAddress(address, parts[AUTHOR_NAME], parts[AUTHOR_ID]);

                case "community":
                    return new GroupAddress(address, parts[GROUP_ID], parts[GROUP_NAME]);

                default:
                    return new PageAddress(address);
            }
        }
    }
}