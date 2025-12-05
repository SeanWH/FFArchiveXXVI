using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

using FFArchive.Bookmarks;
using FFArchive.LocalFiles;
using FFArchive.LocalFiles.Collections;
using FFArchive.LocalFiles.Objects;
using FFArchive.LocalFiles.SiteProcessing;
using FFArchive.History;
using FFArchive.Settings;

namespace FFArchive.GUI
{
    public partial class Form1 : Form
    {
        private enum DocType { HTML, TEXT, RTF, UNKNOWN }

        private BookmarkManager _bm;
        private LocalFileManager _lfm;
        private HistoryManager _hm;

        private AppSettings _settings = new AppSettings();

        private WebBrowser _wb = new WebBrowser();
        private RichTextBox _rtb = new RichTextBox();

        private TreeNodeMouseClickEventArgs _tnmcea;
        private StringCollection _filters = new StringCollection();

        private ToolStripStatusLabel tsl;
        private ToolStripStatusLabel _size;

        private bool _localfile = false;




        #region Form Specific Code

        public Form1()
        {
            InitializeComponent();
            InitializeSettings();
            InitializeBookmarks();
            InitializeLocalFiles();
            InitializeHistory();
            _localfile = true;
            DisplayDocument(Application.StartupPath + Path.DirectorySeparatorChar + "StartHtml.htm");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hm.Status == HistoryManagerStatus.Dirty)
            {
                _hm.State = HistoryManagerState.Write;
            }

            if (_bm.Status == BookmarkManagerStatus.Dirty)
            {
                _bm.State = BookmarkManagerState.Save;
            }
        }

        #endregion

        #region Initialization Code

        private void InitializeSettings()
        {
            try
            {
                XMLConfig xc = new XMLConfig(XMLConfig.ioState.Read);
                _settings = xc.Settings;
                xc = null;
                _filters = _settings.Filters;
                tsbShowFfx.Checked = _settings.DisplayFfx;
                tsbShowHtml.Checked = _settings.DisplayHtml;
                tsbShowPdf.Checked = _settings.DisplayPdf;
                tsbShowRtf.Checked = _settings.DisplayRtf;
                tsbShowText.Checked = _settings.DisplayText;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (NullReferenceException)
            {
            }
        }

        private void InitializeBookmarks()
        {
            _bm = new BookmarkManager(_settings.Filters, ref this.tvBookmarks, ref this.statusStrip1, ref this.txtAddress);
            _bm.State = BookmarkManagerState.Load;
        }

        private void InitializeLocalFiles()
        {
            _lfm = new LocalFileManager(_settings.SavePath, ref this.tvLocal, _settings.Filters);
            _lfm.SaveAsHtml = _settings.SaveDocumentAsHtml;
            _lfm.SaveAsPdf = _settings.SaveDocumentAsPdf;
            _lfm.SaveAsRtf = _settings.SaveDocumentAsRtf;
            _lfm.SaveAsText = _settings.SaveDocumentAsText;

            fswLocalFiles.Path = _settings.SavePath;
        }

        private void InitializeHistory()
        {
            _hm = new HistoryManager(ref this.tvHistory, _settings.Filters);
            _hm.State = HistoryManagerState.Init;
        }

        #endregion

        #region Main Menu Code

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form opt = new Options();
            opt.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bm.State = BookmarkManagerState.Import;
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Fiction Types(*.txt;*.htm;*.html)|*.txt;*.htm;*.html|HTML Files(*.htm;*.html)|*.htm;*.html|Text Files(*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAddress.Text = ofd.FileName;
                DisplayDocument(ofd.FileName);
            }
        }

        #endregion

        #region Bookmark Handling Code

        private void tvBookmarks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level > 1)
                {
                    _localfile = false;
                    Bookmark b = new Bookmark();
                    b = (Bookmark)e.Node;
                    txtAddress.Text = b.Address;
                    string a = checkAddress(b.Address);
                    DisplayDocument(a);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _tnmcea = e;
            }


        }

        private void AddBookmark_Click(object sender, EventArgs e)
        {
            _bm.PageTitle = this.Text;
            _bm.State = BookmarkManagerState.Add;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tnmcea.Node.Level > 1)
            {
                Bookmark b = new Bookmark();
                b = (Bookmark)_tnmcea.Node;
                txtAddress.Text = b.Address;
                string a = checkAddress(b.Address);
                DisplayDocument(a);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tnmcea.Node.Level > 1)
            {
                _bm.BookmarkToDelete = (Bookmark)_tnmcea.Node;
                _bm.State = BookmarkManagerState.Delete;
            }
        }

        #endregion

        #region Main Toolbar Code

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string address = checkAddress(txtAddress.Text);
                DisplayDocument(address);
            }
        }

        private void toolStrip2_Resize(object sender, EventArgs e)
        {
            txtAddress.Width = toolStrip2.Width - 100;
        }

        private void tsbNavBack_Click(object sender, EventArgs e)
        {
            if (_wb != null) _wb.GoBack();
        }

        private void tsbNavForward_Click(object sender, EventArgs e)
        {
            if (_wb != null) _wb.GoForward();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (_wb != null) _wb.Refresh();
        }

        #endregion

        #region Document Display

        private void DisplayDocument(string address)
        {
            Object o;

            if (splitContainer1.Panel2.Controls.Count == 0)
            {
                o = null;
            }
            else
            {
                o = splitContainer1.Panel2.Controls[0];
            }
            DocType dt = getDocType(address);
            switch (dt)
            {
                case DocType.HTML:
                    if ((o == null) || (!(o.GetType() == typeof(WebBrowser))))
                    {
                        _wb = new WebBrowser();
                        _wb.Dock = DockStyle.Fill;
                        _wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
                        _wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
                        _wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(_wb_DocumentCompleted);
                        _wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
                        _wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
                        _wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
                        _wb.StatusTextChanged += new EventHandler(wb_StatusTextChanged);
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(_wb);
                        try
                        {
                            _wb.Navigate(address);
                        }
                        catch (UriFormatException)
                        {
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            _wb = (WebBrowser)o;
                            _wb.Navigate(address);
                        }
                        catch (UriFormatException)
                        {
                            return;
                        }
                    }
                    break;
                case DocType.TEXT:
                case DocType.RTF:
                    if ((o == null) || (!(o.GetType() == typeof(RichTextBox))))
                    {
                        _rtb = new RichTextBox();
                        _rtb.ContextMenuStrip = rtfContextMenu;
                        _rtb.Dock = DockStyle.Fill;
                        txtAddress.Text = address;

                        if (dt == DocType.TEXT)
                        {
                            _rtb.LoadFile(address, RichTextBoxStreamType.UnicodePlainText);
                        }
                        else
                        {
                            _rtb.LoadFile(address, RichTextBoxStreamType.RichText);
                        }
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(_rtb);

                    }
                    else
                    {
                        _rtb = (RichTextBox)o;
                        txtAddress.Text = address;
                        if (dt == DocType.TEXT)
                        {
                            _rtb.LoadFile(address, RichTextBoxStreamType.UnicodePlainText);
                        }
                        else
                        {
                            _rtb.LoadFile(address, RichTextBoxStreamType.RichText);
                        }
                    }
                    break;
            }
        }

        private void increaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (statusStrip1.Items.Count == 0)
            {
                tsl = new ToolStripStatusLabel("Point Size:");
                _size = new ToolStripStatusLabel(Convert.ToString(_rtb.Font.Size));
                statusStrip1.Items.Add(tsl);
                statusStrip1.Items.Add(_size);
            }

            FontFamily ff = new FontFamily("Microsoft Sans Serif");
            float size = _rtb.Font.Size;
            size++;
            if (size > 72) size = 72;
            _size.Text = Convert.ToString(size);
            Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
            _rtb.Font = font;


        }

        private void decreaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Items.Count == 0)
            {
                tsl = new ToolStripStatusLabel("Point Size:");
                _size = new ToolStripStatusLabel(Convert.ToString(_rtb.Font.Size));
                statusStrip1.Items.Add(tsl);
                statusStrip1.Items.Add(_size);
            }

            FontFamily ff = new FontFamily("Microsoft Sans Serif");
            float size = _rtb.Font.Size;
            size--;
            if (size < 8.25) size = 8.25F;
            _size.Text = Convert.ToString(size);
            Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
            _rtb.Font = font;

        }

        #endregion

        #region Web Browser Code

        void _wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            while (!(_wb.ReadyState == WebBrowserReadyState.Interactive))
            {
                Application.DoEvents();
                if (_wb.ReadyState == WebBrowserReadyState.Complete) break;
            }

            string site = getSite(txtAddress.Text);

            if ((_localfile == false))
            {
                try
                {
                    _lfm.SaveDocument(ref _wb, txtAddress.Text);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error Saving File");
                }
            }
        }

        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtAddress.Text = _wb.Url.ToString();
            if (_localfile == false)
            {
                _hm.AddHistoryEntry(DateTime.Now, getSite(txtAddress.Text), txtAddress.Text, _wb.DocumentTitle);
            }
            else
            {
                _localfile = false;
            }
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void wb_CanGoBackChanged(object sender, EventArgs e)
        {
            tsbNavBack.Enabled = _wb.CanGoBack;
        }

        private void wb_CanGoForwardChanged(object sender, EventArgs e)
        {
            tsbNavForward.Enabled = _wb.CanGoForward;
        }

        private void wb_StatusTextChanged(object sender, EventArgs e)
        {
            if (statusStrip1.Items.Count == 0)
            {
                ToolStripStatusLabel tsl = new ToolStripStatusLabel(_wb.StatusText);
                statusStrip1.Items.Add(tsl);
            }
            else
            {
                bool f = false;
                for (int i = 0; i < statusStrip1.Items.Count; i++)
                {
                    if (statusStrip1.Items[i].GetType() == typeof(ToolStripStatusLabel))
                    {
                        f = true;
                        ToolStripStatusLabel tsl = (ToolStripStatusLabel)statusStrip1.Items[i];
                        tsl.Text = _wb.StatusText;
                        break;
                    }
                }
                if (!f)
                {
                    ToolStripStatusLabel tsl = new ToolStripStatusLabel(_wb.StatusText);
                    statusStrip1.Items.Add(tsl);
                }
            }
        }

        private void wb_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = _wb.DocumentTitle;
        }

        #endregion

        #region Utility Code

        private string checkAddress(string address)
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

        private string getExtension(string address)
        {
            int pos = address.LastIndexOf(".");
            return address.Substring(pos + 1);
        }

        private DocType getDocType(string address)
        {
            DocType rtn = DocType.UNKNOWN;

            if (address.StartsWith("http://"))
            {
                rtn = DocType.HTML;
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
                            rtn = DocType.HTML;
                            break;
                        case "txt":
                            rtn = DocType.TEXT;
                            break;
                        case "rtf":
                            rtn = DocType.RTF;
                            break;
                    }
                }
            }
            return rtn;
        }

        private string getSite(string address)
        {
            string rtn = "";

            for (int i = 0; i < _filters.Count; i++)
            {
                if (address.Contains(_filters[i]))
                {
                    rtn = _filters[i];
                    break;
                }
            }
            return rtn;
        }

        #endregion

        #region Local File Handling Code

        private void tvLocal_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.GetType() == typeof(LocalFile))
                {
                    _localfile = true;
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
                    _lfm.ShowHtml = tsb.Checked;
                    break;
                case "TXT":
                    _lfm.ShowText = tsb.Checked;
                    break;
                case "RTF":
                    _lfm.ShowRtf = tsb.Checked;
                    break;
                case "PDF":
                    _lfm.ShowPdf = tsb.Checked;
                    break;
                case "FFX":
                    _lfm.ShowFfx = tsb.Checked;
                    break;
            }

        }

        private void fswLocalFiles_Created(object sender, FileSystemEventArgs e)
        {
            string t = Path.GetFileName(e.Name);
            if (!String.IsNullOrEmpty(t))
            {
                LocalFile file = new LocalFile(e.FullPath);
                LocalFileDisplay.AddFile(file, ref this.tvLocal);
            }

        }

        private void fswLocalFiles_Deleted(object sender, FileSystemEventArgs e)
        {
            LocalFile file = new LocalFile(e.FullPath);
            LocalFileDisplay.RemoveFile(file, ref this.tvLocal);
        }

        #endregion

        #region History Handling Code

        private void tvHistory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level > 2)
                {
                    _localfile = false;
                    DisplayDocument((string)e.Node.Tag);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _tnmcea = e;
            }
        }

        private void HistoryMenuOpen_Click(object sender, EventArgs e)
        {
            if (_tnmcea.Node.Level > 2)
            {
                _localfile = false;
                DisplayDocument((string)_tnmcea.Node.Tag);
            }
        }

        private void HistoryMenuAdd_Click(object sender, EventArgs e)
        {
            _bm.PageTitle = this.Text;
            _bm.State = BookmarkManagerState.Add;
        }

        private void HistoryMenuDelete_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}