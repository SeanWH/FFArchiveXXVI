using System.Collections.Generic;
using System.ComponentModel;

namespace FFArchive.Settings
{
    internal class AppSettings
    {
        private List<string> _filters = new List<string>();

        public AppSettings()
        {
            SavePath = "";
            UseCompression = false;
            AutoSaveBookmarksAfterImport = true;
            SaveDocumentAsHtml = true;
            SaveDocumentAsText = false;
            SaveDocumentAsRtf = false;

            _filters.Add("fanfiction.net");
            _filters.Add("fanficauthors.net");
            _filters.Add("ficwad.com");
            FilterCount = _filters.Count;
        }

        [DescriptionAttribute("Save file as HTML?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsHtml { get; set; }

        [DescriptionAttribute("Save file as Text?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsText { get; set; }

        [DescriptionAttribute("Save file as RTF?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsRtf { get; set; }

        [DescriptionAttribute("Path to directory that archive is built under."),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute("")]
        public string SavePath { get; set; }

        [DescriptionAttribute("Specifies whether or not archive is kept compressed on disk (i.e. in a Zip File)"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(false)]
        public bool UseCompression { get; set; }

        [DescriptionAttribute("Controls whether or not Bookmarks are automatically saved after they are imported."),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool AutoSaveBookmarksAfterImport { get; set; }

        [DescriptionAttribute("Controls whether or not HTML files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(true)]
        public bool DisplayHtml { get; set; } = true;

        [DescriptionAttribute("Controls whether or not TEXT files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(true)]
        public bool DisplayText { get; set; } = true;

        [DescriptionAttribute("Controls whether or not RTF files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(false)]
        public bool DisplayRtf { get; set; }

        [DescriptionAttribute("List of currently supported websites."),
        CategoryAttribute("Supported Sites"),
        ReadOnlyAttribute(true)]
        public List<string> Filters
        {
            get => _filters;
            set
            {
                _filters = value;
                FilterCount = _filters.Count;
            }
        }

        [DescriptionAttribute("Count of currently supported websites."),
        CategoryAttribute("Supported Sites"),
        ReadOnlyAttribute(true)]
        public int FilterCount { get; private set; }
    }
}