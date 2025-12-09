namespace FFArchiveXXVI.UI;

using FFArchiveXXVI.Model;
using FFArchiveXXVI.Model.LocalFiles;

using WeifenLuo.WinFormsUI.Docking;

public partial class LocalFileNavPanel : DockContent
{
    private string _savePath;

    public LocalFileNavPanel()
    {
        InitializeComponent();

        _savePath = AppSettings.Current.SavePath;
        LocalFileNode rootNode = new LocalFileNode(_savePath);
        LocalFileTreeView.Nodes.Add(rootNode);

        if (rootNode.Tag is null)
        {
            return;
        }

        rootNode.LoadNodes((LocalFileObject)rootNode.Tag);
    }

    private void LocalFileTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        if (e.Node is null)
        {
            return;
        }

        var lfo = e.Node.Tag as LocalFileObject;

        if (lfo is null)
        {
            return;
        }
        (e.Node as LocalFileNode)?.LoadNodes(lfo);
    }

    private void LocalFileTreeView_AfterExpand(object sender, TreeViewEventArgs e)
    {
        if (e.Node is null)
        {
            return;
        }

        var lfo = e.Node.Tag as LocalFileObject;

        if (lfo is null)
        {
            return;
        }
        (e.Node as LocalFileNode)?.SetIcon(lfo);
    }

    private void LocalFileTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
    {
        if (e.Node is null)
        {
            return;
        }

        var lfo = e.Node.Tag as LocalFileObject;

        if (lfo is null)
        {
            return;
        }
        (e.Node as LocalFileNode)?.SetIcon(lfo);
    }
}