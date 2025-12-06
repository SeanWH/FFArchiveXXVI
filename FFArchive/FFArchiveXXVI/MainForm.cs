namespace FFArchiveXXVI;

using FFArchiveXXVI.Model;
using FFArchiveXXVI.UI;

using WeifenLuo.WinFormsUI.Docking;

public partial class MainForm : Form
{
    private BookmarkNavPanel _bookmarkNavPanel;
    private HistoryNavPanel _historyNavPanel;
    private LocalFileNavPanel _localFileNavPanel;

    private DeserializeDockContent _deserializeDockContent;
    private bool _shouldSaveLayout = true;
    private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();

    private AppSettings _appSettings;
    private string _layoutFile;

    public MainForm()
    {
        InitializeComponent();

        AutoScaleMode = AutoScaleMode.Dpi;
        IsMdiContainer = true;
        _appSettings = AppSettings.Current;
        _layoutFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

        InitUI();

        _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        visualStudioToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
    }

    public void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_shouldSaveLayout)
        {
            dockPanel1.SaveAsXml(_layoutFile);
        }
    }

    private IDockContent GetContentFromPersistString(string persistString)
    {
        if (persistString == typeof(BookmarkNavPanel).ToString())
        {
            return _bookmarkNavPanel;
        }
        else if (persistString == typeof(HistoryNavPanel).ToString())
        {
            return _historyNavPanel;
        }
        else if (persistString == typeof(LocalFileNavPanel).ToString())
        {
            return _localFileNavPanel;
        }
        else
        {
            return new WebDocument();
        }
    }

    private void InitUI()
    {
        _localFileNavPanel = new LocalFileNavPanel();
        _bookmarkNavPanel = new BookmarkNavPanel();
        _historyNavPanel = new HistoryNavPanel();
    }

    private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
    {
        visualStudioToolStripExtender1.SetStyle(menuStrip1, version, theme);
        visualStudioToolStripExtender1.SetStyle(statusStrip1, version, theme);
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new Settings();
        var result = settingsForm.ShowDialog();
        if (result == DialogResult.OK)
        {
            _appSettings = AppSettings.Current;
            SetSchema();
        }
    }

    private void CloseAllContents()
    {
        _bookmarkNavPanel.DockPanel = null;
        _historyNavPanel.DockPanel = null;
        _localFileNavPanel.DockPanel = null;

        CloseAllDocuments();

        foreach (var window in dockPanel1.FloatWindows.ToList())
        {
            window.Dispose();
        }
    }

    private void CloseAllDocuments()
    {
        if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
        {
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }
        }
        else
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                // IMPORANT: dispose all panes.
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }
        }
    }

    private IDockContent? FindDocument(string text)
    {
        if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
        {
            foreach (Form form in MdiChildren)
            {
                if (form.Text == text)
                {
                    return form as IDockContent;
                }
            }
            return null;
        }
        else
        {
            foreach (IDockContent document in dockPanel1.Documents)
            {
                if (document.DockHandler.TabText == text)
                {
                    return document;
                }
            }
            return null;
        }
    }

    private void SetSchema()
    {
        string tempFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

        if (File.Exists(tempFile))
        {
            File.Delete(tempFile);
        }

        dockPanel1.SaveAsXml(tempFile);
        CloseAllContents();

        switch (AppSettings.Current.CurrentThemeName)
        {
            case "Visual Studio 2003":
                dockPanel1.Theme = vS2003Theme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2003, vS2003Theme1);
                break;

            case "Visual Studio 2005":
                dockPanel1.Theme = vS2005Theme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2005, vS2005Theme1);
                break;

            case "Visual Studio 2012 Light":
                dockPanel1.Theme = vS2012LightTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012LightTheme1);
                break;

            case "Visual Studio 2012 Blue":
                dockPanel1.Theme = vS2012BlueTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012BlueTheme1);
                break;

            case "Visual Studio 2012 Dark":
                dockPanel1.Theme = vS2012DarkTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012DarkTheme1);
                break;

            case "Visual Studio 2013 Light":
                dockPanel1.Theme = vS2013LightTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013LightTheme1);
                break;

            case "Visual Studio 2013 Blue":
                dockPanel1.Theme = vS2013BlueTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013BlueTheme1);
                break;

            case "Visual Studio 2013 Dark":
                dockPanel1.Theme = vS2013DarkTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013DarkTheme1);
                break;

            case "Visual Studio 2015 Light":
                dockPanel1.Theme = vS2015LightTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
                break;

            case "Visual Studio 2015 Blue":
                dockPanel1.Theme = vS2015BlueTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);
                break;

            case "Visual Studio 2015 Dark":
                dockPanel1.Theme = vS2015DarkTheme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme1);
                break;

            default:
                dockPanel1.Theme = vS2003Theme1;
                EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2003, vS2003Theme1);
                break;
        }

        if (dockPanel1.Theme.ColorPalette != null)
        {
            statusStrip1.BackColor = dockPanel1.Theme.ColorPalette.MainWindowActive.Background;
        }

        if (File.Exists(tempFile))
        {
            dockPanel1.LoadFromXml(tempFile, _deserializeDockContent);
            File.Delete(tempFile);
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        SetSchema();
        if (File.Exists(_layoutFile))
        {
            dockPanel1.LoadFromXml(_layoutFile, _deserializeDockContent);
        }
        else
        {
            _localFileNavPanel?.Show(dockPanel1, DockState.DockLeft);
            _bookmarkNavPanel?.Show(dockPanel1, DockState.DockLeft);
            _historyNavPanel?.Show(dockPanel1, DockState.DockLeft);
        }
    }
}