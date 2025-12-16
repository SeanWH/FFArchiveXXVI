namespace FFArchiveXXVI.UI;

partial class BookmarkNavPanel
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarkNavPanel));
        BookmarkTreeView = new TreeView();
        imageListBookmarks = new ImageList(components);
        contextMenuStrip1 = new ContextMenuStrip(components);
        renameToolStripMenuItem = new ToolStripMenuItem();
        deleteToolStripMenuItem = new ToolStripMenuItem();
        contextMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // BookmarkTreeView
        // 
        BookmarkTreeView.ContextMenuStrip = contextMenuStrip1;
        BookmarkTreeView.Dock = DockStyle.Fill;
        BookmarkTreeView.ImageIndex = 0;
        BookmarkTreeView.ImageList = imageListBookmarks;
        BookmarkTreeView.Location = new Point(0, 0);
        BookmarkTreeView.Name = "BookmarkTreeView";
        BookmarkTreeView.SelectedImageIndex = 0;
        BookmarkTreeView.ShowNodeToolTips = true;
        BookmarkTreeView.Size = new Size(240, 450);
        BookmarkTreeView.TabIndex = 0;
        BookmarkTreeView.NodeMouseClick += BookmarkTreeView_NodeMouseClick;
        // 
        // imageListBookmarks
        // 
        imageListBookmarks.ColorDepth = ColorDepth.Depth32Bit;
        imageListBookmarks.ImageStream = (ImageListStreamer)resources.GetObject("imageListBookmarks.ImageStream");
        imageListBookmarks.TransparentColor = Color.Transparent;
        imageListBookmarks.Images.SetKeyName(0, "books.png");
        imageListBookmarks.Images.SetKeyName(1, "kuser-3.png");
        imageListBookmarks.Images.SetKeyName(2, "folder-page.png");
        imageListBookmarks.Images.SetKeyName(3, "kuser-4.png");
        imageListBookmarks.Images.SetKeyName(4, "text-x-generic-template.png");
        imageListBookmarks.Images.SetKeyName(5, "document-open-7.png");
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { renameToolStripMenuItem, deleteToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(181, 70);
        // 
        // renameToolStripMenuItem
        // 
        renameToolStripMenuItem.Name = "renameToolStripMenuItem";
        renameToolStripMenuItem.Size = new Size(180, 22);
        renameToolStripMenuItem.Text = "Rename";
        renameToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
        // 
        // deleteToolStripMenuItem
        // 
        deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        deleteToolStripMenuItem.Size = new Size(180, 22);
        deleteToolStripMenuItem.Text = "Delete";
        deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
        // 
        // BookmarkNavPanel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(240, 450);
        Controls.Add(BookmarkTreeView);
        DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
        HideOnClose = true;
        Name = "BookmarkNavPanel";
        ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
        Text = "Bookmarks";
        contextMenuStrip1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TreeView BookmarkTreeView;
    private ImageList imageListBookmarks;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem renameToolStripMenuItem;
    private ToolStripMenuItem deleteToolStripMenuItem;
}