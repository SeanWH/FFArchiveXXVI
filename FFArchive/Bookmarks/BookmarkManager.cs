using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    internal class BookmarkManager
    {
        private BookmarkManagerState _currentState;
        private readonly List<string> _filters;
        private readonly TreeView _treeViewBookmarks;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _toolStripStatusLabelProcessName = new ToolStripStatusLabel();
        private OrderedDictionary _siteCounts = new OrderedDictionary();
        private OrderedDictionary _sites = new OrderedDictionary();
        private readonly ToolStripComboBox _addressComboBox;
        private ToolStripStatusLabel _toolStripStatusLabelProcessStepName;
        private ToolStripProgressBar _toolStripProgressBar;
        private ToolStripProgressBar _toolStripStepProgress;

        public BookmarkManager(List<string> filters, ref TreeView tv, ref StatusStrip s, ref ToolStripComboBox addressComboBox)
        {
            _filters = filters;
            _treeViewBookmarks = tv;
            _statusStrip = s;
            _addressComboBox = addressComboBox;
        }

        public string PageTitle { private get; set; }

        public Bookmark BookmarkToDelete { private get; set; }

        public BookmarkManagerStatus Status { get; private set; }

        public BookmarkManagerState CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                StateChanged();
            }
        }

        public OrderedDictionary Bookmarks => _sites;

        private void StateChanged()
        {
            switch (_currentState)
            {
                case BookmarkManagerState.Save:
                    BookmarkWriter bookmarkWriter = new BookmarkWriter(_sites, _filters, ref _statusStrip);
                    bookmarkWriter.WriteBookmarks();
                    Status = BookmarkManagerStatus.Clean;
                    break;

                case BookmarkManagerState.Load:
                    BookmarkReader bookmarkReader = new BookmarkReader();
                    _sites = bookmarkReader.ReadBookmarkFile();
                    _siteCounts = bookmarkReader.SiteCounts;
                    CurrentState = _sites.Count > 0 ? BookmarkManagerState.Update : BookmarkManagerState.None;
                    Status = BookmarkManagerStatus.Clean;
                    break;

                case BookmarkManagerState.Import:
                    BookmarkImporter bookmarkImporter;
                    bookmarkImporter = _sites.Count > 0 ? new BookmarkImporter(_filters, _sites, ref _statusStrip) : new BookmarkImporter(_filters, null, ref _statusStrip);
                    _sites = bookmarkImporter.Sites;
                    _siteCounts = bookmarkImporter.SiteCounts;
                    CurrentState = BookmarkManagerState.Update;
                    Status = BookmarkManagerStatus.Dirty;
                    break;

                case BookmarkManagerState.Update:
                    UpdateBookmarks();
                    break;

                case BookmarkManagerState.Add:
                    AddBookmark();
                    CurrentState = BookmarkManagerState.Update;
                    Status = BookmarkManagerStatus.Dirty;
                    break;

                case BookmarkManagerState.Delete:
                    DeleteBookmark();
                    CurrentState = BookmarkManagerState.Update;
                    Status = BookmarkManagerStatus.Dirty;
                    break;

                case BookmarkManagerState.None:
                    break;
            }
        }

        private void DeleteBookmark()
        {
            string site = BookmarkToDelete.Site;
            OrderedDictionary currentSite = (OrderedDictionary)_sites[site];
            SiteInfo siteInfo = (SiteInfo)_siteCounts[site];
            BookmarkList bookmarkList;
            switch (BookmarkToDelete.LinkType)
            {
                case LinkTarget.Story:
                    bookmarkList = (BookmarkList)currentSite["stories"];
                    siteInfo.StoryCount--;
                    bookmarkList.Remove(BookmarkToDelete);
                    currentSite.Remove("stories");
                    currentSite.Add("stories", bookmarkList);
                    break;

                case LinkTarget.C2Group:
                    bookmarkList = (BookmarkList)currentSite["c2groups"];
                    siteInfo.C2Count--;
                    bookmarkList.Remove(BookmarkToDelete);
                    currentSite.Remove("c2groups");
                    currentSite.Add("c2groups", bookmarkList);
                    break;

                case LinkTarget.Author:
                    bookmarkList = (BookmarkList)currentSite["authors"];
                    siteInfo.AuthorCount--;
                    bookmarkList.Remove(BookmarkToDelete);
                    currentSite.Remove("authors");
                    currentSite.Add("authors", bookmarkList);
                    break;
            }
            _sites.Remove(site);
            _sites.Add(site, currentSite);
            _siteCounts.Remove(site);
            _siteCounts.Add(site, siteInfo);
        }

        private void AddBookmark()
        {
            string title = FilterTitle(PageTitle);
            string address = _addressComboBox.Text;
            string site = GetSite(address);

            if (String.IsNullOrEmpty(site))
            {
                MessageBox.Show("Cannot determine URL of Bookmark.  Cannot Add Bookmark.", "Error Adding Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bookmark bookmark = new Bookmark(title, address, site);

            OrderedDictionary currentSite = (OrderedDictionary)_sites[site];
            SiteInfo currentCounts = (SiteInfo)_siteCounts[site];
            BookmarkList bookmarkList;

            switch (bookmark.LinkType)
            {
                case LinkTarget.Author:
                    currentCounts.AuthorCount++;
                    bookmarkList = (BookmarkList)currentSite["authors"];
                    bookmarkList.Add(bookmark);
                    currentSite.Remove("authors");
                    currentSite.Add("authors", bookmarkList);
                    _siteCounts.Remove(site);
                    _siteCounts.Add(site, currentCounts);
                    break;

                case LinkTarget.C2Group:
                    currentCounts.C2Count++;
                    bookmarkList = (BookmarkList)currentSite["c2groups"];
                    bookmarkList.Add(bookmark);
                    currentSite.Remove("c2groups");
                    currentSite.Add("c2groups", bookmarkList);
                    _siteCounts.Remove(site);
                    _siteCounts.Add(site, currentCounts);
                    break;

                case LinkTarget.Story:
                    currentCounts.StoryCount++;
                    bookmarkList = (BookmarkList)currentSite["stories"];
                    bookmarkList.Add(bookmark);
                    currentSite.Remove("stories");
                    currentSite.Add("stories", bookmarkList);
                    _siteCounts.Remove(site);
                    _siteCounts.Add(site, currentCounts);
                    break;
            }

            _sites.Remove(site);
            _sites.Add(site, currentSite);
        }

        private string GetSite(string address)
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
            return pos != -1 ? _filters[pos] : null;
        }

        private void InitUpdateProgress()
        {
            _statusStrip.Items.Clear();
            _toolStripStatusLabelProcessName = new ToolStripStatusLabel("Updating Bookmarks:");
            _toolStripProgressBar = new ToolStripProgressBar();
            _toolStripStatusLabelProcessStepName = new ToolStripStatusLabel();
            _toolStripStepProgress = new ToolStripProgressBar();
            _toolStripProgressBar.Maximum = 1;
            _toolStripProgressBar.Value = 0;
            _toolStripStatusLabelProcessStepName.AutoSize = true;
            _statusStrip.Items.Add(_toolStripStatusLabelProcessName);
            _statusStrip.Items.Add(_toolStripProgressBar);
            _statusStrip.Items.Add(_toolStripStatusLabelProcessStepName);
            _statusStrip.Items.Add(_toolStripStepProgress);
        }

        private void UpdateStoryBookmarks(int nodeIndex, BookmarkList storyBookmarks)
        {
            _toolStripStatusLabelProcessStepName.Text = "Processing Stories:";
            _toolStripStepProgress.Maximum = 1;
            _toolStripStepProgress.Value = 0;
            TreeNode treeNode = new TreeNode
            {
                Text = $"Stories ({storyBookmarks.Count})",
                ImageIndex = 1
            };
            _treeViewBookmarks.Nodes[nodeIndex].Nodes.Add(treeNode);
            foreach (Bookmark bookmark in storyBookmarks)
            {
                bookmark.ImageIndex = 4;
                _treeViewBookmarks.Nodes[nodeIndex].Nodes[0].Nodes.Add(bookmark);
                _toolStripStepProgress.Maximum++;
                _toolStripStepProgress.Value++;
            }
        }

        private void UpdateAuthorBookmarks(int nodeIndex, BookmarkList authorBookmarks)
        {
            _toolStripStatusLabelProcessStepName.Text = "Processing Authors:";
            _toolStripStepProgress.Maximum = 1;
            _toolStripStepProgress.Value = 0;
            TreeNode treeNode = new TreeNode
            {
                Text = $"Authors ({authorBookmarks.Count})",
                ImageIndex = 2
            };
            _treeViewBookmarks.Nodes[nodeIndex].Nodes.Add(treeNode);
            foreach (Bookmark b in authorBookmarks)
            {
                b.ImageIndex = 5;
                _treeViewBookmarks.Nodes[nodeIndex].Nodes[1].Nodes.Add(b);
                _toolStripStepProgress.Maximum++;
                _toolStripStepProgress.Value++;
            }
        }

        private void UpdateC2GroupBookmarks(int nodeIndex, BookmarkList c2Bookmarks)
        {
            _toolStripStatusLabelProcessStepName.Text = "Processing C2 Groups:";
            _toolStripStepProgress.Maximum = 1;
            _toolStripStepProgress.Value = 0;
            TreeNode treeNode = new TreeNode
            {
                Text = $"C2 Groups ({c2Bookmarks.Count})",
                ImageIndex = 3
            };
            _treeViewBookmarks.Nodes[nodeIndex].Nodes.Add(treeNode);
            foreach (Bookmark b in c2Bookmarks)
            {
                b.ImageIndex = 4;
                _treeViewBookmarks.Nodes[nodeIndex].Nodes[2].Nodes.Add(b);
                _toolStripStepProgress.Maximum++;
                _toolStripStepProgress.Value++;
            }
        }

        private void UpdateBookmarks()
        {
            InitUpdateProgress();
            _treeViewBookmarks.Nodes.Clear();

            for (int i = 0; i < _filters.Count; i++)
            {
                OrderedDictionary site = (OrderedDictionary)_sites[_filters[i]];
                BookmarkList authorBookmarks = (BookmarkList)site["authors"];
                BookmarkList storyBookmarks = (BookmarkList)site["stories"];
                BookmarkList c2Bookmarks = (BookmarkList)site["c2groups"];
                if (_treeViewBookmarks.Nodes.Count < _filters.Count)
                {
                    _treeViewBookmarks.Nodes.Add(new TreeNode(_filters[i], 0, 0));

                    if (storyBookmarks.Count > 0)
                    {
                        UpdateStoryBookmarks(i, storyBookmarks);
                    }

                    if (authorBookmarks.Count > 0)
                    {
                        UpdateAuthorBookmarks(i, authorBookmarks);
                    }

                    if (c2Bookmarks.Count > 0)
                    {
                        UpdateC2GroupBookmarks(i, c2Bookmarks);
                    }
                }
                _toolStripProgressBar.Maximum++;
                _toolStripProgressBar.Value++;
            }
            _statusStrip.Items.Clear();
        }

        private static string FilterTitle(string title)
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