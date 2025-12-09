namespace FFArchiveXXVI.Model.LocalFiles;

public class LocalFileNode : TreeNode
{
    private IEnumerable<string> _children;

    public LocalFileNode(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        LocalFileObject lfo = new LocalFileObject(path);
        Text = lfo.FileName;
        Tag = lfo;

        if (lfo.IsFolder && Directory.EnumerateFileSystemEntries(path).Any())
        {
            Nodes.Add(new TreeNode());
        }
    }

    public void SetIcon(LocalFileObject lfo)
    {
        ImageIndex = !lfo.IsFolder ? 1 : IsExpanded ? 2 : 0;
        SelectedImageIndex = !lfo.IsFolder ? 1 : IsExpanded ? 2 : 0;
    }

    public void LoadNodes(LocalFileObject lfo)
    {
        if (!lfo.IsFolder && _children == null)
        {
            _children = Directory.EnumerateFileSystemEntries(lfo.PathToFileObject).ToList();
            ((List<string>)_children).AddRange(Directory.EnumerateFileSystemEntries(lfo.PathToFileObject));
            Nodes.Clear();
            Nodes.AddRange(_children.Select(child => new LocalFileNode(child)).ToArray());
        }
    }
}