using System;
using System.Collections;
using System.Text;

using FFArchive.Bookmarks;

namespace FFArchive
{
    public class SiteCollection : DictionaryBase
    {
        public BookmarkCollection this[string key]
        {
            get { return (BookmarkCollection)Dictionary[key]; }
            set { Dictionary[key] = value; }
        }

        public ICollection Keys
        {
            get { return Dictionary.Keys; }
        }

        public ICollection Values
        {
            get { return Dictionary.Values; }
        }

        public void Add(String key, BookmarkCollection value)
        {
            try
            {
                Dictionary.Add(key, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Site Collection Add Error. Key: " + key + " Value: " + value);
            }
        }

        public bool Contains(String key)
        {
            return (Dictionary.Contains(key));
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }
    }
}
