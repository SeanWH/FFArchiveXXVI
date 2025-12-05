using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.LocalFiles.Objects
{
    public class LocalFile : TreeNode
    {
        public enum Filetype { Text, Html, Rtf, Pdf, FFX };

        private string _filename;
        private string _filepath;
        private string _universe;
        private string _author;
        private string _title;
        private string _site;
        private Filetype _filetype;

        public LocalFile(string fullpath)
        {
            _filepath = fullpath;
            _filetype = getFileType();
            parsePath();
        }

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public string Filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public string Universe
        {
            get { return _universe; }
            set { _universe = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string WebSite
        {
            get { return _site; }
            set { _site = value; }
        }

        public Filetype Type
        {
            get { return _filetype; }
            set { _filetype = value; }
        }

        private void parsePath()
        {
            _filename = Path.GetFileNameWithoutExtension(_filepath);

            string path = Path.GetFullPath(_filepath);

            this.Text = Path.GetFileName(path);

            this._author = LocalPath.GetAuthor(path);
            this._site = LocalPath.GetSite(path);
            this._title = LocalPath.GetTitle(path);
            this._universe = LocalPath.GetUniverse(path);

        }

        private Filetype getFileType()
        {
            Filetype ft = Filetype.FFX;

            string ext = Path.GetExtension(_filepath);

            if (ext.Contains("htm"))
            {
                ft = Filetype.Html;
                this.ImageIndex = 5;
            }
            else if (ext.Contains("txt"))
            {
                ft = Filetype.Text;
                this.ImageIndex = 4;
            }
            else if (ext.Contains("rtf"))
            {
                ft = Filetype.Rtf;
                this.ImageIndex = 4;
            }
            else if (ext.Contains("pdf"))
            {
                ft = Filetype.Pdf;
                this.ImageIndex = 4;
            }
            else if (ext.Contains("ffx"))
            {
                ft = Filetype.FFX;
                this.ImageIndex = 4;
            }

            return ft;
        }

        
    
    }
}
