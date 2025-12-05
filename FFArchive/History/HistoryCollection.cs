using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFArchive.History
{
    public class HistoryCollection : CollectionBase
    {
        public int Add(HistoryEntry item)
        {
            return List.Add(item);
        }

        public void Insert(int index, HistoryEntry item)
        {
            List.Insert(index, item);
        }

        public void Remove(HistoryEntry item)
        {
            List.Remove(item);
        }

        public bool Contains(HistoryEntry item)
        {
            return List.Contains(item);
        }

        public int IndexOf(HistoryEntry item)
        {
            return List.IndexOf(item);
        }

        public void CopyTo(HistoryEntry[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public HistoryEntry this[int index]
        {
            get { return (HistoryEntry)List[index]; }
            set { List[index] = value; }
        }
    }
}
