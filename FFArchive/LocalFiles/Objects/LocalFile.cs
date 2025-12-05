using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace FFArchive.LocalFiles.Objects
{
    [Serializable]
    public class LocalFile : TreeNode
    {
        public LocalFile(string fullPath)
        {
            Filepath = fullPath;
            Type = GetFileType();
            ParsePath();
        }

        protected LocalFile(SerializationInfo info, StreamingContext context)
        {
        }

        public string Filename { get; private set; }

        public string Filepath { get; }

        public string Universe { get; private set; }

        public string Author { get; private set; }

        public string Title { get; private set; }

        public string WebSite { get; private set; }

        public FileType Type { get; }

        private void ParsePath()
        {
            Filename = Path.GetFileNameWithoutExtension(Filepath);

            string path = Path.GetFullPath(Filepath);

            Text = Path.GetFileName(path);

            Author = LocalPath.GetAuthor(path);
            WebSite = LocalPath.GetSite(path);
            Title = LocalPath.GetTitle(path);
            Universe = LocalPath.GetUniverse(path);
        }

        private FileType GetFileType()
        {
            FileType ft = FileType.Unknown;

            string ext = Path.GetExtension(Filepath)?.ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(ext))
            {
                if (ext.Contains("htm"))
                {
                    ft = FileType.Html;
                    ImageIndex = 5;
                }

                if (ext.Contains("txt"))
                {
                    ft = FileType.Text;
                    ImageIndex = 4;
                }

                if (ext.Contains("rtf"))
                {
                    ft = FileType.Rtf;
                    ImageIndex = 4;
                }

                if (ext.Contains("pdf"))
                {
                    ft = FileType.Pdf;
                    ImageIndex = 4;
                }
            }

            return ft;
        }
    }
}