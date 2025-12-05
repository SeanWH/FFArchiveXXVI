using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.History
{
    public enum eEntryType { Story, Author, C2 }

    public class HistoryEntry : TreeNode
    {
        private DateTime _date;
        private string _site;
        private string _address;
        private string _title;
        private int _hits;
        private eEntryType _entryType;

        public HistoryEntry(DateTime date, string site, string address, string title)
        {
            _date = date;
            _site = site;
            _address = address;
            _title = title;
            _entryType = getType(address);
            this.Text = _title;
            this.Tag = address;
            this.ToolTipText = address;
        }

        public eEntryType EntryType
        {
            get { return _entryType; }
        }

        public int Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private eEntryType getType(string address)
        {
            eEntryType et = eEntryType.Story;

            if (_site.Equals("fanfiction.net", StringComparison.OrdinalIgnoreCase))
            {
                if (address.Contains("/s/")) et = eEntryType.Story;
                if (address.Contains("/u/")) et = eEntryType.Author;
                if (((address.Contains("/c2/")) || (address.Contains("/c2l/")) || (address.Contains("/c2d/"))))
                {
                    if(address.Contains("/c2d/")) this.Text = "C2 Directory";
                    et = eEntryType.C2;
                }
            }

            return et;
        }
    }
}
