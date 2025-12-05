using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    public enum LinkTarget { Story, Author, C2Group }

    public class Bookmark : TreeNode, IComparable
    {
        
        
        private string m_sTitle;
        private string m_sAddress;
        private string m_sSite;
        private LinkTarget _target;

        public Bookmark() { }

        public Bookmark(string t, string a, string s)
        {
            m_sTitle = t;
            m_sAddress = a;
            m_sSite = s;
            _target = getTarget(a);
            this.Text = m_sTitle;
            this.ToolTipText = m_sAddress;
        }

       

        public string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; }
        }

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Site
        {
            get { return m_sSite; }
            set { m_sSite = value; }
        }

        public LinkTarget LinkType
        {
            get { return _target; }
        }

        private LinkTarget getTarget(string address)
        {
            LinkTarget rtn = LinkTarget.Story;

            if (address.Contains("/u/")) rtn =  LinkTarget.Author;
            if (address.Contains("/profile.php?")) rtn = LinkTarget.Author;
            if (address.Contains("/c2/")) rtn = LinkTarget.C2Group;
            if (address.Contains("/c2l/")) rtn = LinkTarget.C2Group;

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
                else if(address.EndsWith(".net/index.php", StringComparison.OrdinalIgnoreCase)) 
                {
                    rtn = LinkTarget.Author;
                }
            }

            if (address.Contains("portkey.org"))
            {
                if (address.Contains("profile"))
                {
                    rtn = LinkTarget.Author;
                }
            }

            return rtn;
        }
        
        #region IComparable Members

        public int CompareTo(object bookmark)
        {
            int val;

            Bookmark b = (Bookmark)bookmark;

            if (this.Site.CompareTo(b.Site) == 0)
            {
                if (this.Title.CompareTo(b.Title) == 0)
                {
                    if (this.Address.CompareTo(b.Address) == 0)
                    {
                        val = 0;
                    }
                    else
                    {
                        if (this.Site.Equals("fanfiction.net"))
                        {
                            int pos = this.Address.LastIndexOf("/");
                            string a = this.Address.Substring(0, pos);
                            pos = a.LastIndexOf("/");
                            string t = a.Substring(0, pos);
                            pos = b.Address.LastIndexOf("/");
                            string ba = b.Address.Substring(0, pos);
                            pos = ba.LastIndexOf("/");
                            string t1 = ba.Substring(0, pos);

                            if (t.Equals(t1, StringComparison.OrdinalIgnoreCase))
                            {
                                val = 0;
                            }
                            else
                            {
                                val = t.CompareTo(t1);
                            }
                        }
                        else
                        {
                            val = this.Address.CompareTo(b.Address);
                        }
                    }
                }
                else
                {
                    if (this.Title.Equals(b.Title, StringComparison.OrdinalIgnoreCase))
                    {
                        val = 0;
                    }
                    else
                    {
                        val = this.Title.CompareTo(b.Title);
                    }
                }
            }
            else
            {
                if (this.Site.Equals(b.Site, StringComparison.OrdinalIgnoreCase))
                {
                    val = 0;
                }
                else
                {
                    val = this.Site.CompareTo(b.Site);
                }
            }

            return val;
        }

        #endregion
    }
}
