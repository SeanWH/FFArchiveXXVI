using System;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    public class Bookmark : TreeNode, IComparable
    {
        public Bookmark()
        {
        }

        public Bookmark(string title, string address, string site)
        {
            Title = title;
            Address = address;
            Site = site;
            LinkType = GetTarget(address);
            Text = Title;
            ToolTipText = Address;
        }

        public string Title { get; }

        public string Address { get; }

        public string Site { get; }

        public LinkTarget LinkType { get; }

        private LinkTarget GetTarget(string address)
        {
            LinkTarget rtn = LinkTarget.Story;

            if (address.Contains("/u/") || address.Contains("/profile.php"))
            {
                rtn = LinkTarget.Author;
            }

            if (address.Contains("/c2/") || address.Contains("/c2l/"))
            {
                rtn = LinkTarget.C2Group;
            }

            if (address.Contains("/authorLinks/"))
            {
                int cnt = 0;
                int pos = 0;
                while (pos < address.Length)
                {
                    if (address.Substring(pos, 1).Equals("/", StringComparison.OrdinalIgnoreCase))
                    {
                        cnt++;
                    }
                    pos++;
                }

                if (cnt == 5)
                {
                    rtn = LinkTarget.Author;
                }
            }

            if (address.Contains("fanficauthors.net"))
            {
                if (address.EndsWith(".net/", StringComparison.OrdinalIgnoreCase))
                {
                    rtn = LinkTarget.Author;
                }
                else if (address.EndsWith(".net/index.php", StringComparison.OrdinalIgnoreCase))
                {
                    rtn = LinkTarget.Author;
                }
            }

            return rtn;
        }

        public int CompareTo(object bookmark)
        {
            int val;

            Bookmark b = (Bookmark)bookmark;

            if (string.Compare(Site, b.Site, StringComparison.Ordinal) == 0)
            {
                if (string.Compare(Title, b.Title, StringComparison.Ordinal) == 0)
                {
                    if (string.Compare(Address, b.Address, StringComparison.Ordinal) == 0)
                    {
                        val = 0;
                    }
                    else
                    {
                        if (Site.Equals("fanfiction.net"))
                        {
                            int pos = Address.LastIndexOf("/", StringComparison.Ordinal);
                            string a = Address.Substring(0, pos);
                            pos = a.LastIndexOf("/", StringComparison.Ordinal);
                            string t = a.Substring(0, pos);
                            pos = b.Address.LastIndexOf("/", StringComparison.Ordinal);
                            string ba = b.Address.Substring(0, pos);
                            pos = ba.LastIndexOf("/", StringComparison.Ordinal);
                            string t1 = ba.Substring(0, pos);

                            val = t.Equals(t1, StringComparison.OrdinalIgnoreCase) ? 0 : string.Compare(t, t1, StringComparison.Ordinal);
                        }
                        else
                        {
                            val = string.Compare(Address, b.Address, StringComparison.Ordinal);
                        }
                    }
                }
                else
                {
                    val = Title.Equals(b.Title, StringComparison.OrdinalIgnoreCase) ? 0 : string.Compare(Title, b.Title, StringComparison.Ordinal);
                }
            }
            else
            {
                val = Site.Equals(b.Site, StringComparison.OrdinalIgnoreCase) ? 0 : string.Compare(Site, b.Site, StringComparison.Ordinal);
            }

            return val;
        }
    }
}