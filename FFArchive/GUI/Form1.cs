using FFArchive.Bookmarks;
using FFArchive.History;
using FFArchive.LocalFiles;
using FFArchive.LocalFiles.Objects;
using FFArchive.Settings;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FFArchive.GUI
{
    public partial class Form1 : Form
    {
        private enum DocType { Html, Text, Rtf, Unknown }

        private BookmarkManager _bookmarkManager;
        private LocalFileManager _localFileManager;
        private HistoryManager _historyManager;

        private AppSettings _settings = new AppSettings();

        private WebBrowser _webBrowser = new WebBrowser();
        private readonly RichTextBox _richTextBox = new RichTextBox();

        private TreeNodeMouseClickEventArgs _treeNodeMouseClickEventArgs;
        private List<string> _filters = new List<string>();

        private bool _isLocalFile;

        public Form1()
        {
            InitializeComponent();
            InitializeSettings();
            InitializeBookmarks();
            InitializeLocalFiles();
            InitializeHistory();
            _isLocalFile = true;
            DisplayDocument(Application.StartupPath + Path.DirectorySeparatorChar + "StartHtml.htm");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_historyManager.Status == HistoryManagerStatus.Dirty)
            {
                _historyManager.State = HistoryManagerState.Write;
            }

            if (_bookmarkManager.Status == BookmarkManagerStatus.Dirty)
            {
                _bookmarkManager.CurrentState = BookmarkManagerState.Save;
            }
        }

        private void InitializeSettings()
        {
            XmlConfig xmlConfig = new XmlConfig(XmlConfig.IoState.Read);
            _settings = xmlConfig.Settings;
            _filters = _settings.Filters;

            while (string.IsNullOrWhiteSpace(_settings.SavePath))
            {
                using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    folderBrowser.Description = "Select root folder that stories will be saved to.";
                    folderBrowser.ShowNewFolderButton = true;

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        _settings.SavePath = folderBrowser.SelectedPath;
                    }
                }
            }
        }

        private void InitializeBookmarks()
        {
            _bookmarkManager = new BookmarkManager(_settings.Filters, ref tvBookmarks, ref ssMain, ref txtAddress)
            {
                CurrentState = BookmarkManagerState.Load
            };
        }

        private void InitializeLocalFiles()
        {
            _localFileManager = new LocalFileManager(_settings.SavePath, ref tvLocal, _settings.Filters)
            {
                SaveAsHtml = _settings.SaveDocumentAsHtml,
                SaveAsRtf = _settings.SaveDocumentAsRtf,
                SaveAsText = _settings.SaveDocumentAsText
            };

            fswLocalFiles.Path = _settings.SavePath;
            tsbShowHtml.Checked = _settings.DisplayHtml;
            tsbShowRtf.Checked = _settings.DisplayRtf;
            tsbShowText.Checked = _settings.DisplayText;
        }

        private void InitializeHistory()
        {
            _historyManager = new HistoryManager(ref tvHistory, _settings.Filters) { State = HistoryManagerState.Init };
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form options = new Options();
            options.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bookmarkManager.CurrentState = BookmarkManagerState.Import;
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter =
                    "All Fiction Types(*.txt;*.htm;*.html)|*.txt;*.htm;*.html|HTML Files(*.htm;*.html)|*.htm;*.html|Text Files(*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAddress.Text = openFileDialog.FileName;
                DisplayDocument(openFileDialog.FileName);
            }
        }

        private void tvBookmarks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level > 1)
                {
                    _isLocalFile = false;
                    Bookmark selected = (Bookmark)e.Node;
                    txtAddress.Text = selected.Address;
                    string a = CheckAddress(selected.Address);
                    DisplayDocument(a);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _treeNodeMouseClickEventArgs = e;
            }
        }

        private void AddBookmark_Click(object sender, EventArgs e)
        {
            _bookmarkManager.PageTitle = Text;
            _bookmarkManager.CurrentState = BookmarkManagerState.Add;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeNodeMouseClickEventArgs.Node.Level > 1)
            {
                Bookmark bookmark = (Bookmark)_treeNodeMouseClickEventArgs.Node;
                txtAddress.Text = bookmark.Address;
                DisplayDocument(CheckAddress(bookmark.Address));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeNodeMouseClickEventArgs.Node.Level > 1)
            {
                _bookmarkManager.BookmarkToDelete = (Bookmark)_treeNodeMouseClickEventArgs.Node;
                _bookmarkManager.CurrentState = BookmarkManagerState.Delete;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string address = CheckAddress(txtAddress.Text);
                DisplayDocument(address);
            }
        }

        private void toolStrip2_Resize(object sender, EventArgs e)
        {
            txtAddress.Width = tsNav.Width - 100;
        }

        private void tsbNavBack_Click(object sender, EventArgs e)
        {
            _webBrowser?.GoBack();
        }

        private void tsbNavForward_Click(object sender, EventArgs e)
        {
            _webBrowser?.GoForward();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            _webBrowser?.Refresh();
        }

        private void DisplayDocument(string address)
        {
            object o = splitContainer1.Panel2.Controls.Count == 0 ? null : splitContainer1.Panel2.Controls[0];
            DocType docType = GetDocType(address);
            switch (docType)
            {
                case DocType.Html:
                    if (o == null || !(o.GetType() == typeof(WebBrowser)))
                    {
                        _webBrowser = new WebBrowser { Dock = DockStyle.Fill };
                        _webBrowser.Navigating += WebBrowserNavigating;
                        _webBrowser.Navigated += WebBrowserNavigated;
                        _webBrowser.DocumentCompleted += WebBrowserDocumentCompleted;
                        _webBrowser.CanGoBackChanged += WebBrowserCanGoBackChanged;
                        _webBrowser.CanGoForwardChanged += WebBrowserCanGoForwardChanged;
                        _webBrowser.DocumentTitleChanged += WebBrowserDocumentTitleChanged;
                        _webBrowser.StatusTextChanged += WebBrowserStatusTextChanged;
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(_webBrowser);
                        try
                        {
                            _webBrowser.Navigate(address);
                        }
                        catch (UriFormatException)
                        { }
                    }
                    else
                    {
                        try
                        {
                            _webBrowser = (WebBrowser)o;
                            _webBrowser.Navigate(address);
                        }
                        catch (UriFormatException)
                        { }
                    }
                    break;

                case DocType.Text:
                case DocType.Rtf:
                    if (!(o is RtfDisplayPanel))
                    {
                        RtfDisplayPanel rtfDisplayPanel = new RtfDisplayPanel { Dock = DockStyle.Fill };
                        txtAddress.Text = address;
                        if (docType == DocType.Text)
                        {
                            rtfDisplayPanel.SetPlainText(LoadTextFile(address));
                        }
                        else
                        {
                            rtfDisplayPanel.SetRichText(LoadTextFile(address));
                        }
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(rtfDisplayPanel);
                    }
                    else
                    {
                        RtfDisplayPanel rdp = (RtfDisplayPanel)o;
                        txtAddress.Text = address;
                        if (docType == DocType.Text)
                        {
                            rdp.SetPlainText(LoadTextFile(address));
                        }
                        else
                        {
                            rdp.SetRichText(LoadTextFile(address));
                        }
                    }
                    break;
            }
        }

        private void increaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontFamily ff = new FontFamily("Microsoft Sans Serif");
            float size = _richTextBox.Font.Size;
            size++;
            if (size > 72) size = 72;
            Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
            _richTextBox.Font = font;
        }

        private void decreaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontFamily ff = new FontFamily("Microsoft Sans Serif");
            float size = _richTextBox.Font.Size;
            size--;
            if (size < 8.25) size = 8.25F;
            Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
            _richTextBox.Font = font;
        }

        private static string LoadTextFile(string address)
        {
            try
            {
                using (StreamReader sr = new StreamReader(address))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n\n" + e.StackTrace, "Error Loading Text File");
                return "";
            }
        }

        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            while (_webBrowser.ReadyState != WebBrowserReadyState.Interactive)
            {
                Application.DoEvents();
                if (_webBrowser.ReadyState == WebBrowserReadyState.Complete) break;
            }

            if (_isLocalFile == false)
            {
                try
                {
                    _localFileManager.SaveDocument(ref _webBrowser, txtAddress.Text);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error Saving File");
                }
            }
        }

        private void WebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtAddress.Text = _webBrowser.Url.ToString();
            if (_isLocalFile == false)
            {
                _historyManager.AddHistoryEntry(DateTime.Now, GetSite(txtAddress.Text), txtAddress.Text, _webBrowser.DocumentTitle);
            }
            else
            {
                _isLocalFile = false;
            }
        }

        private void WebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
        }

        private void WebBrowserCanGoBackChanged(object sender, EventArgs e)
        {
            tsbNavBack.Enabled = _webBrowser.CanGoBack;
        }

        private void WebBrowserCanGoForwardChanged(object sender, EventArgs e)
        {
            tsbNavForward.Enabled = _webBrowser.CanGoForward;
        }

        private void WebBrowserStatusTextChanged(object sender, EventArgs e)
        {
            if (ssMain.Items.Count == 0)
            {
                ToolStripStatusLabel tsl = new ToolStripStatusLabel(_webBrowser.StatusText);
                ssMain.Items.Add(tsl);
            }
            else
            {
                bool f = false;
                for (int i = 0; i < ssMain.Items.Count; i++)
                {
                    if (ssMain.Items[i].GetType() == typeof(ToolStripStatusLabel))
                    {
                        f = true;
                        ToolStripStatusLabel tsl = (ToolStripStatusLabel)ssMain.Items[i];
                        tsl.Text = _webBrowser.StatusText;
                        break;
                    }
                }
                if (!f)
                {
                    ToolStripStatusLabel tsl = new ToolStripStatusLabel(_webBrowser.StatusText);
                    ssMain.Items.Add(tsl);
                }
            }
        }

        private void WebBrowserDocumentTitleChanged(object sender, EventArgs e)
        {
            Text = _webBrowser.DocumentTitle;
        }

        private static string CheckAddress(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                address = "http://www.fanfiction.net";
            }
            if (!address.StartsWith("http://"))
            {
                if (!address.Contains(Convert.ToString(Path.DirectorySeparatorChar)))
                {
                    address = "http://" + address;
                }
            }
            return address;
        }

        private string GetExtension(string address)
        {
            int pos = address.LastIndexOf(".");
            return address.Substring(pos + 1);
        }

        private static DocType GetDocType(string address)
        {
            DocType rtn = DocType.Unknown;

            if (address.StartsWith("http://"))
            {
                rtn = DocType.Html;
            }
            else if (address.Contains(Convert.ToString(Path.DirectorySeparatorChar)))
            {
                int pos = address.LastIndexOf(".");
                if (pos != -1)
                {
                    address = address.Substring(pos + 1);
                    switch (address)
                    {
                        case "htm":
                        case "html":
                            rtn = DocType.Html;
                            break;

                        case "txt":
                            rtn = DocType.Text;
                            break;

                        case "rtf":
                            rtn = DocType.Rtf;
                            break;
                    }
                }
            }
            return rtn;
        }

        private string GetSite(string address)
        {
            string rtn = "";

            foreach (string filter in _filters)
            {
                if (address.Contains(filter))
                {
                    rtn = filter;
                    break;
                }
            }
            return rtn;
        }

        private void tvLocal_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.GetType() == typeof(LocalFile))
                {
                    _isLocalFile = true;
                    LocalFile lf = (LocalFile)e.Node;
                    DisplayDocument(lf.Filepath);
                }
            }
        }

        private void tsbShow_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            switch (tsb.Text)
            {
                case "HTM":
                    _localFileManager.ShowHtml = tsb.Checked;
                    break;

                case "TXT":
                    _localFileManager.ShowText = tsb.Checked;
                    break;

                case "RTF":
                    _localFileManager.ShowRtf = tsb.Checked;
                    break;

                case "PDF":
                    _localFileManager.ShowPdf = tsb.Checked;
                    break;

                case "FFX":
                    _localFileManager.ShowFfx = tsb.Checked;
                    break;
            }
        }

        private void fswLocalFiles_Created(object sender, FileSystemEventArgs e)
        {
            string t = Path.GetFileName(e.Name);
            if (!String.IsNullOrEmpty(t))
            {
                LocalFile file = new LocalFile(e.FullPath);
                LocalFileDisplay.AddFile(file, ref tvLocal);
            }
        }

        private void fswLocalFiles_Deleted(object sender, FileSystemEventArgs e)
        {
            LocalFile file = new LocalFile(e.FullPath);
            LocalFileDisplay.RemoveFile(file, ref tvLocal);
        }

        private void tvHistory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level > 2)
                {
                    _isLocalFile = false;
                    DisplayDocument((string)e.Node.Tag);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _treeNodeMouseClickEventArgs = e;
            }
        }

        private void HistoryMenuOpen_Click(object sender, EventArgs e)
        {
            if (_treeNodeMouseClickEventArgs.Node.Level > 2)
            {
                _isLocalFile = false;
                DisplayDocument((string)_treeNodeMouseClickEventArgs.Node.Tag);
            }
        }

        private void HistoryMenuAdd_Click(object sender, EventArgs e)
        {
            _bookmarkManager.PageTitle = Text;
            _bookmarkManager.CurrentState = BookmarkManagerState.Add;
        }

        private void HistoryMenuDelete_Click(object sender, EventArgs e)
        {
        }
    }
}