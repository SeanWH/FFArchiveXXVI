using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFArchive.LocalFiles.Collections
{
    public class AuthorCollection : DictionaryBase
    {
        public TitleCollection this[string key]
        {
            get { return (TitleCollection)Dictionary[key]; }
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
        
        public void Add(string key, TitleCollection hc)
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
