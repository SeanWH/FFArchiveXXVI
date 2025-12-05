using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace FFArchive.Settings
{
    //public enum SaveAsType { HTML, TEXT, RTF, PDF, NONE };
    public enum PdfGenFrom { HTML, TEXT, RTF, FFX, NONE };
    
    class AppSettings
    {
        private PdfGenFrom pgf = PdfGenFrom.NONE;
        
        private StringCollection _filters = new StringCollection();
        private int _filterCount;

        private string savePath = " ";
        private bool useCompression = false;
        private bool autoSaveBookmarks = true;
       
        private bool saveAsHtml = true;
        private bool saveAsText = true;
        private bool saveAsRtf = false;
        private bool saveAsPdf = false;
        private bool saveAsFfx = false;
        
        private bool displayHtml = true;
        private bool displayText = true;
        private bool displayRtf = false;
        private bool displayPdf = false;
        private bool displayFfx = false;

        public AppSettings()
        {
            pgf = PdfGenFrom.NONE;
            savePath = " ";
            useCompression = false;
            autoSaveBookmarks = true;
            saveAsHtml = true;
            saveAsText = false;
            saveAsRtf = false;
            saveAsPdf = false;
            
            _filters.Add("fanfiction.net");
            _filters.Add("fanficauthors.net");
            _filters.Add("adultfanfiction.net");
            _filters.Add("harrypotterfanfiction.com");
            _filters.Add("portkey.org");
            _filters.Add("schnoogle.com");
            _filters.Add("skyehawke.com");
            _filters.Add("fictionalley.org");
            _filters.Add("astronomytower.org");
            _filters.Add("thedarkarts.org");
            _filters.Add("riddikulus.org");
            _filters.Add("ficwad.com");
            _filterCount = _filters.Count;
        }
        
        [DescriptionAttribute("Save file as HTML?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsHtml
        {
            get { return saveAsHtml; }
            set { saveAsHtml = value; }
        }

        [DescriptionAttribute("Save file as Text?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsText
        {
            get { return saveAsText; }
            set { saveAsText = value; }
        }

        [DescriptionAttribute("Save file as RTF?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsRtf
        {
            get { return saveAsRtf; }
            set { saveAsRtf = value; }
        }

        [DescriptionAttribute("Save file in PDF Format?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsPdf
        {
            get { return saveAsPdf; }
            set { saveAsPdf = value; }
        }

        [DescriptionAttribute("Save file in FFX Format?"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool SaveDocumentAsFfx
        {
            get { return saveAsFfx; }
            set { saveAsFfx = value; }
        }

        [DescriptionAttribute("Create PDF File based on selected file type."),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(PdfGenFrom.NONE)]
        public PdfGenFrom CreatePdfFrom
        {
            get { return pgf; }
            set { pgf = value; }
        }

        [DescriptionAttribute("Path to directory that archive is built under."),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute("")]
        public string SavePath {
            get { return savePath; }
            set { savePath = value; }
        }

        [DescriptionAttribute("Specifies whether or not archive is kept compressed on disk (i.e. in a Zip File)"),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(false)]
        public bool UseCompression
        {
            get { return useCompression; }
            set { useCompression = value; }
        }

        [DescriptionAttribute("Controls whether or not Bookmarks are automatically saved after they are imported."),
        CategoryAttribute("SaveOptions"),
        DefaultValueAttribute(true)]
        public bool AutoSaveBookmarksAfterImport
        {
            get { return autoSaveBookmarks; }
            set { autoSaveBookmarks = value; }
        }

        [DescriptionAttribute("Controls whether or not HTML files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(true)]
        public bool DisplayHtml
        {
            get { return displayHtml; }
            set { displayHtml = value; }
        }

        [DescriptionAttribute("Controls whether or not TEXT files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(true)]
        public bool DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        [DescriptionAttribute("Controls whether or not RTF files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(false)]
        public bool DisplayRtf
        {
            get { return displayRtf; }
            set { displayRtf = value; }
        }

        [DescriptionAttribute("Controls whether or not PDF files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(false)]
        public bool DisplayPdf
        {
            get { return displayPdf; }
            set { displayPdf = value; }
        }

        [DescriptionAttribute("Controls whether or not FFX files are displayed in the local file tree."),
        CategoryAttribute("DisplayOptions"),
        DefaultValueAttribute(false)]
        public bool DisplayFfx
        {
            get { return displayFfx; }
            set { displayFfx = value; }
        }

        [DescriptionAttribute("List of currently supported websites."),
        CategoryAttribute("Supported Sites"),
        ReadOnlyAttribute(true)]
        public StringCollection Filters
        {
            get { return _filters; }
            set { 
                    _filters = value;
                    _filterCount = _filters.Count;
            }
        }

        [DescriptionAttribute("Count of currently supported websites."),
        CategoryAttribute("Supported Sites"),
        ReadOnlyAttribute(true)]
        public int FilterCount
        {
            get { return _filterCount; }
        }
    
    }
}
