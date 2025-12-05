using FFArchive.LocalFiles.Objects;

using System.Collections;

namespace FFArchive.LocalFiles.Collections
{
    public class FileCollection : DictionaryBase
    {
        public ArrayList this[FileType key]
        {
            get => (ArrayList)Dictionary[key];
            set => Dictionary[key] = value;
        }

        public ICollection Keys => Dictionary.Keys;

        public ICollection Values => Dictionary.Values;

        public void Add(FileType key, LocalFile file)
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
                files = new ArrayList { file };
                Dictionary.Add(key, files);
            }
        }

        public bool Contains(FileType key)
        {
            return Dictionary.Contains(key);
        }

        public void Remove(FileType key)
        {
            Dictionary.Remove(key);
        }
    }
}