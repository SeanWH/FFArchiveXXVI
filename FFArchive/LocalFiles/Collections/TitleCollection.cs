using System.Collections;

namespace FFArchive.LocalFiles.Collections
{
    public class TitleCollection : DictionaryBase
    {
        public FileCollection this[string key]
        {
            get => (FileCollection)Dictionary[key];
            set => Dictionary[key] = value;
        }

        public ICollection Keys => Dictionary.Keys;

        public ICollection Values => Dictionary.Values;

        public void Add(string key, FileCollection hc)
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