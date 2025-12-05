namespace FFArchiveXXVI.Model.History
{
    using System;

    public class HistoryEntry : TreeNode
    {
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public FfnUrlType EntryType { get; set; }

        public HistoryEntry(DateTime date, string address, string title)
        {
            Date = date;
            Address = address;
            Title = title;
            EntryType = FfnUrlUtilities.GetFfnUrlTypeFromUrl(address);
            Hits = 0;
            Tag = address;
            Text = Title;
            ToolTipText = address;
        }
    }
}