using FFArchive.LocalFiles.Collections;
using FFArchive.LocalFiles.Objects;
using FFArchive.LocalFiles.SiteProcessing;

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FFArchive.LocalFiles
{
    public class LocalFileManager
    {
        private readonly string _savePath;

        //save booleans

        //filter booleans

        //collections
        private readonly SiteCollection _local = new SiteCollection();

        private readonly List<string> _filters;

        public LocalFileManager(string path, ref TreeView fileTreeView, List<string> filters)
        {
            _savePath = path;
            _filters = filters;
            GetFileSystemInfo();
            LocalFileDisplay.InitTreeView(_local, ref fileTreeView);
        }

        public bool ShowHtml { get; set; } = true;

        public bool ShowText { get; set; } = true;

        public bool ShowRtf { get; set; }

        public bool ShowFfx { get; set; }

        public bool ShowPdf { get; set; }

        public bool SaveAsHtml { private get; set; }

        public bool SaveAsText { private get; set; }

        public bool SaveAsRtf { get; set; }

        private void GetFileSystemInfo()
        {
            DirectoryInfo root = new DirectoryInfo(_savePath);

            if (!root.Exists)
            {
                Directory.CreateDirectory(_savePath);
            }
            else
            {
                DirectoryInfo[] sites = root.GetDirectories();
                foreach (DirectoryInfo site in sites)
                {
                    GenreCollection genreCollection = GetGenres(site);
                    _local.Add(site.Name, genreCollection);
                }
            }
        }

        private GenreCollection GetGenres(DirectoryInfo site)
        {
            GenreCollection genreCollection = new GenreCollection();
            DirectoryInfo[] genres = site.GetDirectories();
            foreach (DirectoryInfo genre in genres)
            {
                AuthorCollection authors = GetAuthors(genre);
                genreCollection.Add(genre.Name, authors);
            }

            return genreCollection;
        }

        private AuthorCollection GetAuthors(DirectoryInfo genre)
        {
            AuthorCollection authorCollection = new AuthorCollection();
            DirectoryInfo[] authors = genre.GetDirectories();
            foreach (DirectoryInfo author in authors)
            {
                TitleCollection titles = GetTitles(author);
                authorCollection.Add(author.Name, titles);
            }

            return authorCollection;
        }

        private TitleCollection GetTitles(DirectoryInfo author)
        {
            TitleCollection titleCollection = new TitleCollection();
            DirectoryInfo[] titles = author.GetDirectories();
            foreach (DirectoryInfo title in titles)
            {
                FileCollection files = GetFiles(title);
                titleCollection.Add(title.Name, files);
            }

            return titleCollection;
        }

        private FileCollection GetFiles(DirectoryInfo title)
        {
            FileCollection fileCollection = new FileCollection();
            FileInfo[] files = title.GetFiles();

            foreach (FileInfo file in files)
            {
                LocalFile localFile = new LocalFile(file.FullName);
                fileCollection.Add(localFile.Type, localFile);
            }

            return fileCollection;
        }

        public void SaveDocument(ref WebBrowser webBrowser, string address)
        {
            string site = GetSite(address);
            FanFictionDocument ffnDoc = new FanFictionDocument(ref webBrowser, address, _savePath, site);
            if (ffnDoc.SaveMe)
            {
                if (SaveAsHtml)
                {
                    ffnDoc.WriteHtml();
                }

                if (SaveAsText)
                {
                    ffnDoc.WriteText();
                }
            }
        }

        private string GetSite(string address)
        {
            foreach (string siteName in _filters)
            {
                if (address.Contains(siteName))
                {
                    return siteName;
                }
            }

            return string.Empty;
        }
    }
}