using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using FFArchive.LocalFiles.Objects;

namespace FFArchive.LocalFiles.Collections
{
    public class FileCollection : DictionaryBase
    {
        public ArrayList this[LocalFile.Filetype key]
        {
            get { return (ArrayList)Dictionary[key]; }
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

        public void Add(LocalFile.Filetype key, LocalFile file)
        {
            ArrayList files;

            if (Dictionary.Contains(key))
            {
                files = (ArrayList)Dictionary[key];
                files.Add(file);
                Dictionary.Remove(key);
                Dictionary.Add(key, files);
            }
            else
            {
                files = new ArrayList();
                files.Add(file);
                Dictionary.Add(key, files);
            }
        }
        
        public bool Contains(LocalFile.Filetype key)
        {
            return Dictionary.Contains(key);
        }
                
        public void Remove(LocalFile.Filetype key)
        {
            Dictionary.Remove(key);
        }
    }
}
