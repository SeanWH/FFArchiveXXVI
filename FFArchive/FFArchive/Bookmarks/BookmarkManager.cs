using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    public enum BookmarkManagerState { Import, Save, Load, Update, Add, Delete };
    public enum BookmarkManagerStatus { Dirty, Clean };
    
    class BookmarkManager
    {
        private BookmarkManagerState _state;
        private BookmarkManagerStatus _status;
        private BookmarkManagerState _prevstate;
        private StringCollection _filters = new StringCollection();
        private TreeView tvBmk;
        private StatusStrip ss;
        private ToolStripStatusLabel tsl = new ToolStripStatusLabel();
        private OrderedDictionary _sitecounts = new OrderedDictionary();
        private OrderedDictionary _sites = new OrderedDictionary();
        private ToolStripComboBox _address = new ToolStripComboBox();

        private string _title;
        private Bookmark _toBeDeleted;
        
        public BookmarkManager(StringCollection filters, ref TreeView tv, ref StatusStrip s, ref ToolStripComboBox address)
        {
            _filters = filters;
            tvBmk = tv;
            ss = s;
            _address = address;
            
        }

        public string PageTitle
        {
            set { _title = value; }
        }

        public Bookmark BookmarkToDelete
        {
            set { _toBeDeleted = value; }
        }

        public BookmarkManagerStatus Status 
        {
            get { return _status; }
            set { _status = value; }
        }

        public BookmarkManagerState State
        {
            get { return _state; }
            set {
                    _prevstate = _state;
                    _state = value;
                    StateChanged();
                }
        }

        public OrderedDictionary Bookmarks
        {
            get { return _sites; }
        }

        private void StateChanged()
        {
            switch (_state)
            {
                case BookmarkManagerState.Save:
                    BookmarkWriter bw = new BookmarkWriter(_sites, _filters, ref ss);
                    bw.writeBookmarks();
                    this.Status = BookmarkManagerStatus.Clean;
                    break;
                case BookmarkManagerState.Load:
                    BookmarkReader br = new BookmarkReader();
                    _sites = br.readBookmarks(_filters);
                    _sitecounts = br.SiteCounts;
                    this.State = BookmarkManagerState.Update;
                    this.Status = BookmarkManagerStatus.Clean;
                    break;
                case BookmarkManagerState.Import:
                    BookmarkImporter bi;
                    if (_sites.Count > 0)
                    {
                        bi = new BookmarkImporter(_filters, _sites, ref ss);
                    }
                    else
                    {
                        bi = new BookmarkImporter(_filters, null, ref ss);
                    }
                    _sites = bi.Sites;
                    _sitecounts = bi.SiteCounts;
                    this.State = BookmarkManagerState.Update;
                    this.Status = BookmarkManagerStatus.Dirty;
                    break;
                case BookmarkManagerState.Update:
                    UpdateBookmarks();
                    break;
                case BookmarkManagerState.Add:
                    AddBookmark();
                    this.State = BookmarkManagerState.Update;
                    this.Status = BookmarkManagerStatus.Dirty;
                    break;
                case BookmarkManagerState.Delete:
                    DeleteBookmark();
                    this.State = BookmarkManagerState.Update;
                    this.Status = BookmarkManagerStatus.Dirty;
                    break;
            }
        }

        private void DeleteBookmark()
        {
            string s = _toBeDeleted.Site;
            OrderedDictionary _cursite = (OrderedDictionary)_sites[s];
            SiteInfo si = (SiteInfo)_sitecounts[s];
            BookmarkCollection bc;
            switch (_toBeDeleted.LinkType)
            {
                case LinkTarget.Story:
                    bc = (BookmarkCollection)_cursite["stories"];
                    si.StoryCount--;
                    bc.Remove(_toBeDeleted);
                    _cursite.Remove("stories");
                    _cursite.Add("stories", bc);
                    break;
                case LinkTarget.C2Group:
                    bc = (BookmarkCollection)_cursite["c2groups"];
                    si.C2Count--;
                    bc.Remove(_toBeDeleted);
                    _cursite.Remove("c2groups");
                    _cursite.Add("c2groups", bc);
                    break;
                case LinkTarget.Author:
                    bc = (BookmarkCollection)_cursite["authors"];
                    si.AuthorCount--;
                    bc.Remove(_toBeDeleted);
                    _cursite.Remove("authors");
                    _cursite.Add("authors", bc);
                    break;
            }
            _sites.Remove(s);
            _sites.Add(s, _cursite);
            _sitecounts.Remove(s);
            _sitecounts.Add(s, si);
        }

        private void AddBookmark()
        {
            string title = filterTitle(_title);
            string address = _address.Text;
            string site = getSite(address);

            if (String.IsNullOrEmpty(site))
            {
                MessageBox.Show("Unknown Web Site.  Cannot Add Bookmark.", "Error Adding Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bookmark b = new Bookmark(title, address, site);

            OrderedDictionary cur_site = (OrderedDictionary)_sites[site];
            SiteInfo cur_counts = (SiteInfo)_sitecounts[site];
            BookmarkCollection bc;

            switch (b.LinkType)
            {
                case LinkTarget.Author:
                    cur_counts.AuthorCount++;
                    bc = (BookmarkCollection)cur_site["authors"];
                    bc.Add(b);
                    cur_site.Remove("authors");
                    cur_site.Add("authors", bc);
                    _sitecounts.Remove(site);
                    _sitecounts.Add(site, cur_counts);
                    break;
                case LinkTarget.C2Group:
                    cur_counts.C2Count++;
                    bc = (BookmarkCollection)cur_site["c2groups"];
                    bc.Add(b);
                    cur_site.Remove("c2groups");
                    cur_site.Add("c2groups", bc);
                    _sitecounts.Remove(site);
                    _sitecounts.Add(site, cur_counts);
                    break;
                case LinkTarget.Story:
                    cur_counts.StoryCount++;
                    bc = (BookmarkCollection)cur_site["stories"];
                    bc.Add(b);
                    cur_site.Remove("stories");
                    cur_site.Add("stories", bc);
                    _sitecounts.Remove(site);
                    _sitecounts.Add(site, cur_counts);
                    break;
            }

            _sites.Remove(site);
            _sites.Add(site, cur_site);
        }

        private string getSite(string address)
        {
            int i = 0;
            int pos = -1;
            while (i < _filters.Count)
            {
                if (address.Contains(_filters[i]))
                {
                    pos = i;
                    break;
                }
                i++;
            }
            if (pos != -1)
            {
                return _filters[pos];
            }
            else
            {
                return null;
            }
        }
    

        private void UpdateBookmarks()
        {
            ss.Items.Clear();
            tsl = new ToolStripStatusLabel("Updating Bookmarks:");
            ToolStripProgressBar tspb = new ToolStripProgressBar();
            ToolStripStatusLabel tsl2 = new ToolStripStatusLabel();
            ToolStripProgressBar tspb2 = new ToolStripProgressBar();
            tspb.Maximum = 1;
            tspb.Value = 0;
            tsl2.AutoSize = true;
            ss.Items.Add(tsl);
            ss.Items.Add(tspb);
            ss.Items.Add(tsl2);
            ss.Items.Add(tspb);
            tvBmk.Nodes.Clear();

            for (int i = 0; i < _filters.Count; i++)
            {
                OrderedDictionary _site = (OrderedDictionary)_sites[_filters[i]];
                BookmarkCollection _authors = (BookmarkCollection)_site["authors"];
                BookmarkCollection _stories = (BookmarkCollection)_site["stories"];
                BookmarkCollection _c2groups = (BookmarkCollection)_site["c2groups"];
                if (tvBmk.Nodes.Count < _filters.Count)
                {
                    TreeNode tn = new TreeNode();
                    tn.ImageIndex = 0;
                    tn.Text = _filters[i];
                    tvBmk.Nodes.Add(tn);

                    if (_stories.Count > 0)
                    {
                        tsl2.Text = "Processing Stories:";
                        tspb2.Maximum = 1;
                        tspb2.Value = 0;
                        tn = new TreeNode();
                        tn.Text = "Stories" + " (" + _stories.Count + ")";
                        tn.ImageIndex = 1;
                        tvBmk.Nodes[i].Nodes.Add(tn);
                        foreach (Bookmark b in _stories)
                        {
                            b.ImageIndex = 4;
                            tvBmk.Nodes[i].Nodes[0].Nodes.Add(b);
                            tspb2.Maximum++;
                            tspb2.Value++;
                        }
                    }

                    if (_authors.Count > 0)
                    {
                        tsl2.Text = "Processing Authors:";
                        tspb2.Maximum = 1;
                        tspb2.Value = 0;
                        tn = new TreeNode();
                        tn.Text = "Authors" + " (" + _authors.Count + ")";
                        tn.ImageIndex = 2;
                        tvBmk.Nodes[i].Nodes.Add(tn);
                        foreach (Bookmark b in _authors)
                        {
                            b.ImageIndex = 5;
                            tvBmk.Nodes[i].Nodes[1].Nodes.Add(b);
                            tspb2.Maximum++;
                            tspb2.Value++;
                        }
                    }

                    if (_c2groups.Count > 0)
                    {
                        tsl2.Text = "Processing C2 Groups:";
                        tspb2.Maximum = 1;
                        tspb2.Value = 0;
                        tn = new TreeNode();
                        tn.Text = "C2 Groups" + " (" + _c2groups.Count + ")";
                        tn.ImageIndex = 3;
                        tvBmk.Nodes[i].Nodes.Add(tn);
                        foreach (Bookmark b in _c2groups)
                        {
                            b.ImageIndex = 4;
                            tvBmk.Nodes[i].Nodes[2].Nodes.Add(b);
                            tspb2.Maximum++;
                            tspb2.Value++;
                        }
                    }
                }
                tspb.Maximum++ ;
                tspb.Value++;
            }
            ss.Items.Clear();
        }

        private string filterTitle(string title)
        {
            if (title.StartsWith("fanfiction.net", StringComparison.OrdinalIgnoreCase))
            {
                int pos = title.IndexOf(":");
                if (pos != -1)
                {
                    title = title.Substring(pos + 1).Trim();
                }
                else
                {
                    pos = title.IndexOf("fanfiction.net", StringComparison.OrdinalIgnoreCase);
                    pos += 15;
                    title = title.Substring(pos).Trim();
                }
            }
            return title;
        }
    }
}
