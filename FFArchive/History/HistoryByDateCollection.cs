using System;
using System.Collections;
using System.Globalization;

namespace FFArchive.History
{
    /// <summary>
    /// A dictionary collection in which the key is intended to be a date, and
    /// the value an instance of a HistoryCollection class.
    /// </summary>
    public class HistoryByDateCollection : DictionaryBase
    {
        public HistoryList this[string key]
        {
            get => (HistoryList)Dictionary[key];
            set => Dictionary[key] = value;
        }

        public ICollection Keys => Dictionary.Keys;

        public ICollection Values => Dictionary.Values;

        public void Add(string key, HistoryEntry historyEntry)
        {
            HistoryList historyCollection;

            if (Dictionary.Contains(key))
            {
                historyCollection = (HistoryList)Dictionary[key];
                historyCollection.Add(historyEntry);
                Dictionary.Remove(key);
            }
            else
            {
                historyCollection = new HistoryList { historyEntry };
            }

            Dictionary.Add(key, historyCollection);
        }

        private void Add(string key, HistoryList historyCollection)
        {
            if (Dictionary.Contains(key))
            {
                Dictionary.Remove(key);
                Dictionary.Add(key, historyCollection);
            }
            else
            {
                Dictionary.Add(key, historyCollection);
            }
        }

        public void Add(DateTime key, HistoryEntry historyEntry)
        {
            string k = key.ToString(CultureInfo.InvariantCulture);
            HistoryList historyCollection;
            if (Dictionary.Contains(k))
            {
                historyCollection = (HistoryList)Dictionary[k];
                historyCollection.Add(historyEntry);
            }
            else
            {
                historyCollection = new HistoryList { historyEntry };
            }

            Add(k, historyCollection);
        }

        public void Add(DateTime key, HistoryList historyCollection)
        {
            string k = key.ToString(CultureInfo.InvariantCulture);
            if (Dictionary.Contains(k))
            {
                Add(k, historyCollection);
            }
            else
            {
                Add(k, historyCollection);
            }
        }

        public bool Contains(string key)
        {
            return Dictionary.Contains(key);
        }

        public bool Contains(DateTime dt)
        {
            string key = dt.ToString(CultureInfo.InvariantCulture);
            return Dictionary.Contains(key);
        }

        public void Remove(string key)
        {
            Dictionary.Remove(key);
        }

        public void Remove(DateTime dt)
        {
            string key = dt.ToString(CultureInfo.InvariantCulture);
            Dictionary.Remove(key);
        }
    }
}