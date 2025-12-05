namespace FFArchiveXXVI.Model.Collections;

using FFArchiveXXVI.Model.History;

using System;
using System.Collections.Generic;

/// <summary>
/// A dictionary collection in which the key is intended to be a date, and
/// the value an instance of a List&lt;HistoryEntry&gt;().
/// </summary>
public class HistoryByDateCollection : Dictionary<DateTime, List<HistoryEntry>>
{
    private readonly Dictionary<string, List<HistoryEntry>> Dictionary = [];

    public List<HistoryEntry> this[string key]
    {
        get { return Dictionary[key]; }
        set { Dictionary[key] = value; }
    }

    public new List<HistoryEntry> this[DateTime key]
    {
        get
        {
            string k = key.ToShortDateString();
            return Dictionary[k];
        }

        set
        {
            Dictionary[key.ToShortDateString()] = value;
        }
    }

    public void Add(string key, HistoryEntry he)
    {
        if (Dictionary == null)
        {
            return;
        }

        if (Dictionary.TryGetValue(key, out List<HistoryEntry>? hc))
        {
            hc.Add(he);
            Dictionary.Remove(key);
            Dictionary.Add(key, hc);
        }
        else
        {
            Dictionary.Add(key, [he]);
        }
    }

    public void Add(string key, List<HistoryEntry> hc)
    {
        if (!Dictionary.TryAdd(key, hc))
        {
            Dictionary.Remove(key);
            Dictionary.Add(key, hc);
        }
    }

    public void Add(DateTime key, HistoryEntry he)
    {
        string k = key.ToShortDateString();
        Add(k, he);
    }

    public bool ContainsKey(string key)
    {
        return Dictionary.ContainsKey(key);
    }

    public bool Contains(DateTime dt)
    {
        string key = dt.ToShortDateString();
        return Dictionary.ContainsKey(key);
    }

    public void Remove(string key)
    {
        Dictionary.Remove(key);
    }
}