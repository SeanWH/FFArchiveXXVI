using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.History
{
    public static class HistoryDisplay
    {

        public static void Update(HistoryByDateCollection _history, ref TreeView _tv)
        {
            HistoryCollection hc;
            int i;
            int j;
            int k;

            foreach (string date in _history.Keys)
            {
                hc = (HistoryCollection)_history[date];
                i = FindDate(date, ref _tv);
                if (i == -1)
                {
                    i = AddNewDate(date, ref _tv);
                    foreach (HistoryEntry he in hc)
                    {
                        j = FindSite(i, he.Site, ref _tv);
                        if (j == -1)
                        {
                            j = AddNewSite(i, he.Site, ref _tv);
                        }
                        else
                        {
                            k = FindCategory(i, j, he.EntryType, ref _tv);
                            if (k == -1)
                            {
                                k = AddNewCategory(i, j, he.EntryType, ref _tv);
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                            else
                            {
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                        }
                    }
                    
                }
                else
                {
                    foreach (HistoryEntry he in hc)
                    {
                        j = FindSite(i, he.Site, ref _tv);
                        if (j == -1)
                        {
                            j = AddNewSite(i, he.Site, ref _tv);
                            k = FindCategory(i, j, he.EntryType, ref _tv);
                            if (k == -1)
                            {
                                k = AddNewCategory(i, j, he.EntryType, ref _tv);
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                            else
                            {
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                        }
                        else
                        {
                            k = FindCategory(i, j, he.EntryType, ref _tv);
                            if (k == -1)
                            {
                                k = AddNewCategory(i, j, he.EntryType, ref _tv);
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                            else
                            {
                                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                            }
                        }
                    }
                }
            }
        }

        public static void AddNewHistoryEntry(HistoryEntry he, ref TreeView _tv)
        {
            int i;
            int j;
            int k;

            string date = he.Date.ToShortDateString();
            i = FindDate(date, ref _tv);
            if (i == -1)
            {
                i = AddNewDate(date, ref _tv);
                j = AddNewSite(i, he.Site, ref _tv);
                k = AddNewCategory(i, j, he.EntryType, ref _tv);
                _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
            }
            else
            {
                j = FindSite(i, he.Site, ref _tv);
                if (j == -1)
                {
                    j = AddNewSite(i, he.Site, ref _tv);
                    k = AddNewCategory(i, j, he.EntryType, ref _tv);
                    _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                }
                else
                {
                    k = FindCategory(i, j, he.EntryType, ref _tv);
                    if (k == -1)
                    {
                        k = AddNewCategory(i, j, he.EntryType, ref _tv);
                        _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                    }
                    else
                    {
                        _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(he);
                    }
                }
            }

        }

        private static int FindDate(string date, ref TreeView _tv)
        {
            for (int i = 0; i < _tv.Nodes.Count; i++)
            {
                if (_tv.Nodes[i].Text.Equals(date, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        private static int AddNewDate(string date, ref TreeView _tv)
        {
            return _tv.Nodes.Add(new TreeNode(date));
        }

        private static int FindSite(int root, string site, ref TreeView _tv)
        {
            for (int i = 0; i < _tv.Nodes[root].Nodes.Count; i++)
            {
                if (_tv.Nodes[root].Nodes[i].Text.Equals(site, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        private static int AddNewSite(int root, string site, ref TreeView _tv)
        {
            return _tv.Nodes[root].Nodes.Add(new TreeNode(site));
        }

        private static int FindCategory(int root, int site, eEntryType type, ref TreeView _tv)
        {
            for (int i = 0; i < _tv.Nodes[root].Nodes[site].Nodes.Count; i++)
            {
                switch (type)
                {
                    case eEntryType.Author:
                        if (_tv.Nodes[root].Nodes[site].Nodes[i].Text.Equals("Authors"))
                        {
                            return i;
                        }
                        break;
                    case eEntryType.C2:
                        if (_tv.Nodes[root].Nodes[site].Nodes[i].Text.Equals("C2 Groups"))
                        {
                            return i;
                        }
                        break;
                    case eEntryType.Story:
                        if (_tv.Nodes[root].Nodes[site].Nodes[i].Text.Equals("Stories"))
                        {
                            return i;
                        }
                        break;
                }
            }
            return -1;
        }

        private static int AddNewCategory(int root, int site, eEntryType type, ref TreeView _tv)
        {
            int k = 0;
            switch (type)
            {
                case eEntryType.Author:
                    k = _tv.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("Authors"));
                    break;
                case eEntryType.C2:
                    k = _tv.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("C2 Groups"));
                    break;
                case eEntryType.Story:
                    k = _tv.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("Stories"));
                    break;
            }

            return k;
        }

    }
}
