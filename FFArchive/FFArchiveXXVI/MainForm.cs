namespace FFArchiveXXVI;

using FFArchiveXXVI.UI;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        this.IsMdiContainer = true;

        BookmarkNavPanel bookmarkNavPanel = new BookmarkNavPanel();
        HistoryNavPanel historyNavPanel = new HistoryNavPanel();
        LocalFileNavPanel localFileNavPanel = new LocalFileNavPanel();

        dockPanel1.SuspendLayout();

        bookmarkNavPanel.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
        historyNavPanel.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
        localFileNavPanel.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
        dockPanel1.ResumeLayout();
    }
}