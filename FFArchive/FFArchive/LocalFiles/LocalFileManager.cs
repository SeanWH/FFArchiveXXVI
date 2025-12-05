using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;

using FFArchive.LocalFiles.Collections;
using FFArchive.LocalFiles.Objects;
using FFArchive.LocalFiles.SiteProcessing;

namespace FFArchive.LocalFiles
{
    public enum LFMState { Ready, Saving }

    public class LocalFileManager
    {
        private string _savepath;
        private TreeView _tv;
        
        //save booleans
        private bool _saveAsHtml;
        private bool _saveAsText;
        private bool _saveAsRtf;
        private bool _saveAsPdf;
        
        //filter booleans
        private bool _showHtml = true;
        private bool _showText = true;
        private bool _showRtf = false;
        private bool _showFfx = false;
        private bool _showPdf = false;

        //collections
        SiteCollection _local = new SiteCollection();
        StringCollection _filters;

        //flags
        private LFMState _state = LFMState.Ready;

        //counter
        private int _count = 0;
        
        public LocalFileManager(string path, ref TreeView tv, StringCollection filters)
        {
            _savepath = path;
            _tv = tv;
            _filters = filters;
            getFileSystemInfo();
            LocalFileDisplay.InitTreeView(_local, ref _tv);
        }

#region Properties

        public LFMState State
        {
            get { return _state; }
            set { _state = value;
                  StateChanged();
                }
        }

        public bool ShowHtml
        {
            get { return _showHtml; }
            set { _showHtml = value; }
        }

        public bool ShowText
        {
            get { return _showText; }
            set { _showText = value; }
        }

        public bool ShowRtf
        {
            get { return _showRtf; }
            set { _showRtf = value; }
        }

        public bool ShowFfx
        {
            get { return _showFfx; }
            set { _showFfx = value; }
        }

        public bool ShowPdf
        {
            get { return _showPdf; }
            set { _showPdf = value; }
        }

        public bool SaveAsHtml
        {
            get { return _saveAsHtml; }
            set { _saveAsHtml = value; }
        }

        public bool SaveAsText
        {
            get { return _saveAsText; }
            set { _saveAsText = value; }
        }

        public bool SaveAsRtf
        {
            get { return _saveAsRtf; }
            set { _saveAsRtf = value; }
        }

        public bool SaveAsPdf
        {
            get { return _saveAsPdf; }
            set { _saveAsPdf = value; }
        }
#endregion

        private void StateChanged()
        {
            switch (_state)
            {
                case LFMState.Ready:
                    _count -= 2;
                    break;
                case LFMState.Saving:
                    break;
            }
        }

#region FileSystem Code

        private void getFileSystemInfo()
        {
            DirectoryInfo root = new DirectoryInfo(_savepath);
            
            if (!root.Exists)
            {
                Directory.CreateDirectory(_savepath);
            }
            else
            {
                DirectoryInfo[] sites = root.GetDirectories();
                foreach (DirectoryInfo site in sites)
                {
                    GenreCollection _genre = new GenreCollection();
                    DirectoryInfo[] genres = site.GetDirectories();
                    foreach (DirectoryInfo genre in genres)
                    {
                        AuthorCollection _authors = new AuthorCollection();
                        DirectoryInfo[] authors = genre.GetDirectories();
                        foreach (DirectoryInfo author in authors)
                        {
                            TitleCollection _titles = new TitleCollection();
                            DirectoryInfo[] titles = author.GetDirectories();
                            foreach (DirectoryInfo title in titles)
                            {
                                FileCollection _files = new FileCollection();
                                FileInfo[] files = title.GetFiles();
                                foreach (FileInfo file in files)
                                {
                                    LocalFile _file = new LocalFile(file.FullName);
                                    _files.Add(_file.Type, _file);
                                }
                                _titles.Add(title.Name, _files);
                            }
                            _authors.Add(author.Name, _titles);
                        }
                        _genre.Add(genre.Name, _authors);
                    }
                    _local.Add(site.Name, _genre);
                }
                
            }
        }

#endregion
        


#region Site Processing Code

        public void SaveDocument(ref WebBrowser wb, string address)
        {
            _state = LFMState.Saving;
            

            try
            {
                string site = getSite(address);
                ffDocument ffnDoc = new ffDocument(ref wb, address, _savepath, wb.DocumentText, site);
                if (ffnDoc.SaveMe)
                {
                    if (_saveAsHtml)
                    {
                        try
                        {
                            ffnDoc.writeHtml();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error Saving As Html");
                            _state = LFMState.Ready;
                        }
                    }

                    if (_saveAsText)
                    {
                        try
                        {
                            ffnDoc.writeText();
                        }
                        catch (Exception p)
                        {
                            MessageBox.Show(p.Message, "Error Saving As Text");
                            _state = LFMState.Ready;
                        }
                    }

                    _state = LFMState.Ready;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Creating ffnDoc");
                _state = LFMState.Ready;
            }
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

    }
}
