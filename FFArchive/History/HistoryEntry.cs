using System;
using System.Windows.Forms;

namespace FFArchive.History
{
    public enum HistoryEntryCategory { Story, Author, C2 }

    public class HistoryEntry : TreeNode
    {
        public HistoryEntry(DateTime date, string site, string address, string title)
        {
            Date = date;
            Site = site;
            Address = address;
            Title = title;
            EntryCategory = GetCategory(address);
            Text = Title;
            Tag = address;
            ToolTipText = address;
        }

        public HistoryEntryCategory EntryCategory { get; }

        public int Hits { get; set; }

        public DateTime Date { get; }

        public string Site { get; }

        public string Address { get; }

        public string Title { get; }

        private HistoryEntryCategory GetCategory(string address)
        {
            HistoryEntryCategory et = HistoryEntryCategory.Story;

            if (Site.Equals("fanfiction.net", StringComparison.OrdinalIgnoreCase))
            {
                if (address.Contains("/s/")) et = HistoryEntryCategory.Story;
                if (address.Contains("/u/")) et = HistoryEntryCategory.Author;
                if (address.Contains("/c2/") || address.Contains("/c2l/") || address.Contains("/c2d/"))
                {
                    if (address.Contains("/c2d/")) Text = "C2 Directory";
                    et = HistoryEntryCategory.C2;
                }
            }

            return et;
        }
    }
}