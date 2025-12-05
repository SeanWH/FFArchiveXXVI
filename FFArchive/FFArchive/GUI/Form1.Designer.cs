namespace FFArchive.GUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvLocal = new System.Windows.Forms.TreeView();
            this.ilLocalFiles = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbShowHtml = new System.Windows.Forms.ToolStripButton();
            this.tsbShowText = new System.Windows.Forms.ToolStripButton();
            this.tsbShowRtf = new System.Windows.Forms.ToolStripButton();
            this.tsbShowFfx = new System.Windows.Forms.ToolStripButton();
            this.tsbShowPdf = new System.Windows.Forms.ToolStripButton();
            this.tabBookmarks = new System.Windows.Forms.TabPage();
            this.tvBookmarks = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilBookmarks = new System.Windows.Forms.ImageList(this.components);
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.tvHistory = new System.Windows.Forms.TreeView();
            this.historyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HistoryMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ilMenu = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNavBack = new System.Windows.Forms.ToolStripButton();
            this.tsbNavForward = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtAddress = new System.Windows.Forms.ToolStripComboBox();
            this.rtfContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.increaseTextSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseTextSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fswLocalFiles = new System.IO.FileSystemWatcher();
            this.menuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLocal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabBookmarks.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.historyContextMenu.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.rtfContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswLocalFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(792, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(111, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(111, 22);
            this.mnuFileExit.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookmarksToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBookmark,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.bookmarksToolStripMenuItem.Text = "Bookmarks";
            // 
            // AddBookmark
            // 
            this.AddBookmark.Name = "AddBookmark";
            this.AddBookmark.Size = new System.Drawing.Size(117, 22);
            this.AddBookmark.Text = "Add";
            this.AddBookmark.Click += new System.EventHandler(this.AddBookmark_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel1.Text = "Point Size:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel2.Text = "8.25";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 495);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLocal);
            this.tabControl1.Controls.Add(this.tabBookmarks);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 491);
            this.tabControl1.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.tableLayoutPanel1);
            this.tabLocal.Location = new System.Drawing.Point(4, 22);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(252, 465);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local Files";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tvLocal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.831533F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.16846F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 459);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tvLocal
            // 
            this.tvLocal.BackColor = System.Drawing.Color.Silver;
            this.tvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLocal.HotTracking = true;
            this.tvLocal.ImageIndex = 0;
            this.tvLocal.ImageList = this.ilLocalFiles;
            this.tvLocal.LineColor = System.Drawing.Color.Blue;
            this.tvLocal.Location = new System.Drawing.Point(3, 29);
            this.tvLocal.Name = "tvLocal";
            this.tvLocal.SelectedImageIndex = 1;
            this.tvLocal.Size = new System.Drawing.Size(240, 427);
            this.tvLocal.TabIndex = 1;
            this.tvLocal.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLocal_NodeMouseClick);
            // 
            // ilLocalFiles
            // 
            this.ilLocalFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLocalFiles.ImageStream")));
            this.ilLocalFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLocalFiles.Images.SetKeyName(0, "closed_folder");
            this.ilLocalFiles.Images.SetKeyName(1, "open_folder");
            this.ilLocalFiles.Images.SetKeyName(2, "closed_story");
            this.ilLocalFiles.Images.SetKeyName(3, "open_story");
            this.ilLocalFiles.Images.SetKeyName(4, "text_file");
            this.ilLocalFiles.Images.SetKeyName(5, "html_file");
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowHtml,
            this.tsbShowText,
            this.tsbShowRtf,
            this.tsbShowFfx,
            this.tsbShowPdf});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(246, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbShowHtml
            // 
            this.tsbShowHtml.Checked = true;
            this.tsbShowHtml.CheckOnClick = true;
            this.tsbShowHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShowHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowHtml.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowHtml.Image")));
            this.tsbShowHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowHtml.Name = "tsbShowHtml";
            this.tsbShowHtml.Size = new System.Drawing.Size(32, 22);
            this.tsbShowHtml.Text = "HTM";
            this.tsbShowHtml.ToolTipText = "Show HTM Files";
            this.tsbShowHtml.CheckedChanged += new System.EventHandler(this.tsbShow_CheckedChanged);
            // 
            // tsbShowText
            // 
            this.tsbShowText.CheckOnClick = true;
            this.tsbShowText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowText.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowText.Image")));
            this.tsbShowText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowText.Name = "tsbShowText";
            this.tsbShowText.Size = new System.Drawing.Size(29, 22);
            this.tsbShowText.Text = "TXT";
            this.tsbShowText.ToolTipText = "Show Text Files";
            this.tsbShowText.CheckedChanged += new System.EventHandler(this.tsbShow_CheckedChanged);
            // 
            // tsbShowRtf
            // 
            this.tsbShowRtf.CheckOnClick = true;
            this.tsbShowRtf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowRtf.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowRtf.Image")));
            this.tsbShowRtf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowRtf.Name = "tsbShowRtf";
            this.tsbShowRtf.Size = new System.Drawing.Size(30, 22);
            this.tsbShowRtf.Text = "RTF";
            this.tsbShowRtf.ToolTipText = "Show RTF Files";
            this.tsbShowRtf.CheckedChanged += new System.EventHandler(this.tsbShow_CheckedChanged);
            // 
            // tsbShowFfx
            // 
            this.tsbShowFfx.CheckOnClick = true;
            this.tsbShowFfx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowFfx.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowFfx.Image")));
            this.tsbShowFfx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowFfx.Name = "tsbShowFfx";
            this.tsbShowFfx.Size = new System.Drawing.Size(29, 22);
            this.tsbShowFfx.Text = "FFX";
            this.tsbShowFfx.ToolTipText = "Show FFX Files";
            this.tsbShowFfx.CheckedChanged += new System.EventHandler(this.tsbShow_CheckedChanged);
            // 
            // tsbShowPdf
            // 
            this.tsbShowPdf.CheckOnClick = true;
            this.tsbShowPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowPdf.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowPdf.Image")));
            this.tsbShowPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowPdf.Name = "tsbShowPdf";
            this.tsbShowPdf.Size = new System.Drawing.Size(30, 22);
            this.tsbShowPdf.Text = "PDF";
            this.tsbShowPdf.ToolTipText = "Show PDF Files";
            this.tsbShowPdf.CheckedChanged += new System.EventHandler(this.tsbShow_CheckedChanged);
            // 
            // tabBookmarks
            // 
            this.tabBookmarks.Controls.Add(this.tvBookmarks);
            this.tabBookmarks.Location = new System.Drawing.Point(4, 22);
            this.tabBookmarks.Name = "tabBookmarks";
            this.tabBookmarks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBookmarks.Size = new System.Drawing.Size(252, 465);
            this.tabBookmarks.TabIndex = 1;
            this.tabBookmarks.Text = "Bookmarks";
            this.tabBookmarks.UseVisualStyleBackColor = true;
            // 
            // tvBookmarks
            // 
            this.tvBookmarks.ContextMenuStrip = this.contextMenuStrip1;
            this.tvBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvBookmarks.HotTracking = true;
            this.tvBookmarks.ImageIndex = 0;
            this.tvBookmarks.ImageList = this.ilBookmarks;
            this.tvBookmarks.Location = new System.Drawing.Point(3, 3);
            this.tvBookmarks.Name = "tvBookmarks";
            this.tvBookmarks.SelectedImageIndex = 0;
            this.tvBookmarks.ShowNodeToolTips = true;
            this.tvBookmarks.Size = new System.Drawing.Size(246, 459);
            this.tvBookmarks.TabIndex = 0;
            this.tvBookmarks.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvBookmarks_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ilBookmarks
            // 
            this.ilBookmarks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBookmarks.ImageStream")));
            this.ilBookmarks.TransparentColor = System.Drawing.Color.Transparent;
            this.ilBookmarks.Images.SetKeyName(0, "4.ico");
            this.ilBookmarks.Images.SetKeyName(1, "NOTE05.ICO");
            this.ilBookmarks.Images.SetKeyName(2, "269.ico");
            this.ilBookmarks.Images.SetKeyName(3, "full folder.ico");
            this.ilBookmarks.Images.SetKeyName(4, "html doc.ico");
            this.ilBookmarks.Images.SetKeyName(5, "Windows User Account from Address Book.ico");
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.tvHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(252, 465);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // tvHistory
            // 
            this.tvHistory.ContextMenuStrip = this.historyContextMenu;
            this.tvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHistory.Location = new System.Drawing.Point(3, 3);
            this.tvHistory.Name = "tvHistory";
            this.tvHistory.ShowNodeToolTips = true;
            this.tvHistory.Size = new System.Drawing.Size(246, 459);
            this.tvHistory.TabIndex = 0;
            this.tvHistory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvHistory_NodeMouseClick);
            // 
            // historyContextMenu
            // 
            this.historyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HistoryMenuOpen,
            this.HistoryMenuAdd,
            this.HistoryMenuDelete});
            this.historyContextMenu.Name = "historyContextMenu";
            this.historyContextMenu.ShowImageMargin = false;
            this.historyContextMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // HistoryMenuOpen
            // 
            this.HistoryMenuOpen.Name = "HistoryMenuOpen";
            this.HistoryMenuOpen.Size = new System.Drawing.Size(148, 22);
            this.HistoryMenuOpen.Text = "Open";
            this.HistoryMenuOpen.Click += new System.EventHandler(this.HistoryMenuOpen_Click);
            // 
            // HistoryMenuAdd
            // 
            this.HistoryMenuAdd.Name = "HistoryMenuAdd";
            this.HistoryMenuAdd.Size = new System.Drawing.Size(148, 22);
            this.HistoryMenuAdd.Text = "Add To Bookmarks";
            this.HistoryMenuAdd.Click += new System.EventHandler(this.HistoryMenuAdd_Click);
            // 
            // HistoryMenuDelete
            // 
            this.HistoryMenuDelete.Name = "HistoryMenuDelete";
            this.HistoryMenuDelete.Size = new System.Drawing.Size(148, 22);
            this.HistoryMenuDelete.Text = "Delete";
            this.HistoryMenuDelete.Click += new System.EventHandler(this.HistoryMenuDelete_Click);
            // 
            // ilMenu
            // 
            this.ilMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMenu.ImageStream")));
            this.ilMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMenu.Images.SetKeyName(0, "Back.ico");
            this.ilMenu.Images.SetKeyName(1, "Forward.ico");
            this.ilMenu.Images.SetKeyName(2, "Refresh Current Page.ico");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNavBack,
            this.tsbNavForward,
            this.tsbRefresh,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtAddress});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(792, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Resize += new System.EventHandler(this.toolStrip2_Resize);
            // 
            // tsbNavBack
            // 
            this.tsbNavBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNavBack.Image = global::FFArchive.Properties.Resources.arrow_back_16;
            this.tsbNavBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNavBack.Name = "tsbNavBack";
            this.tsbNavBack.Size = new System.Drawing.Size(23, 22);
            this.tsbNavBack.Text = "toolStripButton1";
            this.tsbNavBack.Click += new System.EventHandler(this.tsbNavBack_Click);
            // 
            // tsbNavForward
            // 
            this.tsbNavForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNavForward.Image = global::FFArchive.Properties.Resources.arrow_forward_16;
            this.tsbNavForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNavForward.Name = "tsbNavForward";
            this.tsbNavForward.Size = new System.Drawing.Size(23, 22);
            this.tsbNavForward.Text = "toolStripButton2";
            this.tsbNavForward.Click += new System.EventHandler(this.tsbNavForward_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::FFArchive.Properties.Resources.redo_16;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "toolStripButton3";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(625, 25);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // rtfContextMenu
            // 
            this.rtfContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseTextSizeToolStripMenuItem,
            this.decreaseTextSizeToolStripMenuItem});
            this.rtfContextMenu.Name = "rtfContextMenu";
            this.rtfContextMenu.Size = new System.Drawing.Size(178, 48);
            // 
            // increaseTextSizeToolStripMenuItem
            // 
            this.increaseTextSizeToolStripMenuItem.Name = "increaseTextSizeToolStripMenuItem";
            this.increaseTextSizeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.increaseTextSizeToolStripMenuItem.Text = "Increase Text Size";
            this.increaseTextSizeToolStripMenuItem.Click += new System.EventHandler(this.increaseTextSizeToolStripMenuItem_Click);
            // 
            // decreaseTextSizeToolStripMenuItem
            // 
            this.decreaseTextSizeToolStripMenuItem.Name = "decreaseTextSizeToolStripMenuItem";
            this.decreaseTextSizeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.decreaseTextSizeToolStripMenuItem.Text = "Decrease Text Size";
            this.decreaseTextSizeToolStripMenuItem.Click += new System.EventHandler(this.decreaseTextSizeToolStripMenuItem_Click);
            // 
            // fswLocalFiles
            // 
            this.fswLocalFiles.EnableRaisingEvents = true;
            this.fswLocalFiles.IncludeSubdirectories = true;
            this.fswLocalFiles.SynchronizingObject = this;
            this.fswLocalFiles.Created += new System.IO.FileSystemEventHandler(this.fswLocalFiles_Created);
            this.fswLocalFiles.Deleted += new System.IO.FileSystemEventHandler(this.fswLocalFiles_Deleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "FF Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabBookmarks.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.historyContextMenu.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.rtfContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fswLocalFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabBookmarks;
        private System.Windows.Forms.TreeView tvBookmarks;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.TreeView tvHistory;
        private System.Windows.Forms.ToolStripMenuItem bookmarksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ImageList ilBookmarks;
        private System.Windows.Forms.ToolStripMenuItem AddBookmark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList ilLocalFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tvLocal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbShowHtml;
        private System.Windows.Forms.ToolStripButton tsbShowText;
        private System.Windows.Forms.ToolStripButton tsbShowRtf;
        private System.Windows.Forms.ToolStripButton tsbShowFfx;
        private System.Windows.Forms.ToolStripButton tsbShowPdf;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNavBack;
        private System.Windows.Forms.ToolStripButton tsbNavForward;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox txtAddress;
        private System.Windows.Forms.ImageList ilMenu;
        private System.Windows.Forms.ContextMenuStrip rtfContextMenu;
        private System.Windows.Forms.ToolStripMenuItem increaseTextSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseTextSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ContextMenuStrip historyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenuDelete;
        private System.IO.FileSystemWatcher fswLocalFiles;
    }
}

