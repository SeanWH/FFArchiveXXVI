namespace FFArchiveXXVI.UI;

using FFArchiveXXVI.Model.Bookmarks;
using FFArchiveXXVI.Model.Collections;

using WeifenLuo.WinFormsUI.Docking;

public partial class BookmarkNavPanel : DockContent
{
    private BookmarkCollection? _bookmarks = null;

    public void AddBookmarks(List<Bookmark>? bookmarks)
    {
        if (bookmarks == null) { return; }

        if (_bookmarks != null)
        {
            foreach (Bookmark bookmark in bookmarks)
            {
                _bookmarks.Add(bookmark);
            }
        }
        else
        {
            _bookmarks = new BookmarkCollection(bookmarks);
        }

        BookmarksUpdated();
    }

    public BookmarkNavPanel()
    {
        InitializeComponent();
        AutoScaleMode = AutoScaleMode.Dpi;
    }

    private void BookmarksUpdated()
    {
        if (_bookmarks == null)
        {
            return;
        }

        if (_bookmarks.Count > 0)
        {
            List<Bookmark> authors = [];
            List<Bookmark> stories = [];
            List<Bookmark> groups = [];

            foreach (Bookmark bookmark in _bookmarks)
            {
                bookmark.Text = bookmark.Title;
                bookmark.Tag = bookmark;
                if (bookmark.Address != null)
                {
                    bookmark.ToolTipText = bookmark.Address.Address;
                }

                if (bookmark.Target == Model.FfnUrlType.Story)
                {
                    bookmark.ImageIndex = 4;
                    bookmark.SelectedImageIndex = 4;
                    stories.Add(bookmark);
                }
                else if (bookmark.Target == Model.FfnUrlType.Author)
                {
                    bookmark.ImageIndex = 3;
                    bookmark.SelectedImageIndex = 3;
                    authors.Add(bookmark);
                }
                else if (bookmark.Target == Model.FfnUrlType.C2Group)
                {
                    bookmark.ImageIndex = 5;
                    bookmark.SelectedImageIndex = 5;
                    groups.Add(bookmark);
                }
            }

            authors.Sort();
            stories.Sort();
            groups.Sort();

            var storyNode = new TreeNode()
            {
                Text = "Stories",
                ImageIndex = 0,
                Name = "storyNode"
            };
            storyNode.Nodes.AddRange([.. stories]);
            var authorNode = new TreeNode()
            {
                Text = "Authors",
                ImageIndex = 1,
                Name = "authorNode"
            };
            authorNode.Nodes.AddRange([.. authors]);
            var groupNode = new TreeNode()
            {
                Text = "Groups",
                ImageIndex = 2,
                Name = "groupNode"
            };
            groupNode.Nodes.AddRange([.. groups]);

            BookmarkTreeView.BeginUpdate();

            storyNode.Text = $"Stories [{storyNode.Nodes.Count}]";
            authorNode.Text = $"Authors [{authorNode.Nodes.Count}]";
            groupNode.Text = $"Groups [{groupNode.Nodes.Count}]";

            _ = BookmarkTreeView.Nodes.Add(storyNode);
            _ = BookmarkTreeView.Nodes.Add(authorNode);
            _ = BookmarkTreeView.Nodes.Add(groupNode);

            BookmarkTreeView.EndUpdate();
        }
    }

    private void BookmarkTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
    }

    private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var node = BookmarkTreeView.SelectedNode;
        if (node is Bookmark bookmarkToDelete)
        {
            BookmarkTreeView.Nodes.Remove(bookmarkToDelete);
        }
    }
}