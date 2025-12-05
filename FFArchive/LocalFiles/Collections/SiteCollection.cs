using System.Collections;

namespace FFArchive.LocalFiles.Collections
{
    public class SiteCollection : DictionaryBase
    {
        public GenreCollection this[string key]
        {
            get => (GenreCollection)Dictionary[key];
            set => Dictionary[key] = value;
        }

        public ICollection Keys => Dictionary.Keys;

        public ICollection Values => Dictionary.Values;

        public void Add(string key, GenreCollection hc)
        {
            if (Dictionary.Contains(key))
            {
                Dictionary.Remove(key);
                Dictionary.Add(key, hc);
            }
            else
            {
                Dictionary.Add(key, hc);
            }
        }

        public bool Contains(string key)
        {
            return Dictionary.Contains(key);
        }

        public void Remove(string key)
        {
            Dictionary.Remove(key);
        }
    }
}