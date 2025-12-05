using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.History
{
    /// <summary>
    /// A dictionary collection in which the key is intended to be a date, and
    /// the value an instance of a HistoryCollection class.
    /// </summary>
    public class HistoryByDateCollection : DictionaryBase
    {
        public HistoryCollection this[string key]
        {
            get { return (HistoryCollection)Dictionary[key]; }
            set { Dictionary[key] = value; }
        }

        public HistoryCollection this[DateTime key]
        {
            get
            {
                string k = key.ToShortDateString();
                return (HistoryCollection)Dictionary[key];
            }

            set
            {
                Dictionary[key.ToShortDateString()] = value; 
            }
        }

        public ICollection Keys
        {
            get { return Dictionary.Keys; }
        }

        public ICollection Values
        {
            get { return Dictionary.Values; }
        }

        public void Add(string key, HistoryEntry he)
        {
            HistoryCollection hc;

            if (Dictionary.Contains(key))
            {
                try
                {
                    hc = (HistoryCollection)Dictionary[key];
                    hc.Add(he);
                    Dictionary.Remove(key);
                    Dictionary.Add(key, hc);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "HBDC Add Error");
                }
            }
            else
            {
                try
                {
                    hc = new HistoryCollection();
                    hc.Add(he);
                    Dictionary.Add(key, hc);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "HBDC Add Error");
                }
            }
        }

        public void Add(string key, HistoryCollection hc)
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

        public void Add(DateTime key, HistoryEntry he)
        {
            HistoryCollection hc;
            string k = key.ToShortDateString();
            if (Dictionary.Contains(k))
            {
                hc = (HistoryCollection)Dictionary[k];
                hc.Add(he);
                Dictionary.Remove(k);
                Dictionary.Add(k, hc);
            }
            else
            {
                hc = new HistoryCollection();
                hc.Add(he);
                Dictionary.Add(k, hc);
            }
        }

        public void Add(DateTime key, HistoryCollection hc)
        {
            string k = key.ToShortDateString();
            if (Dictionary.Contains(k))
            {
                Dictionary.Remove(k);
                Dictionary.Add(k, hc);
            }
            else
            {
                Dictionary.Add(k, hc);
            }
        }

        public bool Contains(string key)
        {
            return Dictionary.Contains(key);
        }

        public bool Contains(DateTime dt)
        {
            string key = dt.ToShortDateString();
            return Dictionary.Contains(key);
        }

        public void Remove(string key)
        {
            Dictionary.Remove(key);
        }

        public void Remove(DateTime dt)
        {
            string key = dt.ToShortDateString();
            Dictionary.Remove(key);
        }

    }
}
