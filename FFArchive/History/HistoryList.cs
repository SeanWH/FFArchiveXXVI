using System.Collections;
using System.Collections.Generic;

namespace FFArchive.History
{
    public class HistoryList : IList<HistoryEntry>
    {
        private readonly List<HistoryEntry> _entries = new List<HistoryEntry>();

        public IEnumerator<HistoryEntry> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_entries).GetEnumerator();
        }

        public void Add(HistoryEntry item)
        {
            _entries.Add(item);
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public bool Contains(HistoryEntry item)
        {
            return _entries.Contains(item);
        }

        public void CopyTo(HistoryEntry[] array, int arrayIndex)
        {
            _entries.CopyTo(array, arrayIndex);
        }

        public bool Remove(HistoryEntry item)
        {
            return _entries.Remove(item);
        }

        public int Count => _entries.Count;

        public bool IsReadOnly => ((ICollection<HistoryEntry>)_entries).IsReadOnly;

        public int IndexOf(HistoryEntry item)
        {
            return _entries.IndexOf(item);
        }

        public void Insert(int index, HistoryEntry item)
        {
            _entries.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _entries.RemoveAt(index);
        }

        public HistoryEntry this[int index]
        {
            get => _entries[index];
            set => _entries[index] = value;
        }
    }
}