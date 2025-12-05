using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFArchive.LocalFiles.Collections
{
    public class SiteCollection : DictionaryBase
    {
        public GenreCollection this[string key]
        {
            get { return (GenreCollection)Dictionary[key]; }
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
