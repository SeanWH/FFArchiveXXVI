using System;
using System.Collections.Generic;
using System.Text;

namespace FFArchive.Bookmarks
{
    class SiteInfo
    {
        private string _name;
        private int _author_count;
        private int _story_count;
        private int _c2_count;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int AuthorCount
        {
            get { return _author_count; }
            set { _author_count = value; }
        }

        public int StoryCount
        {
            get { return _story_count; }
            set { _story_count = value; }
        }

        public int C2Count
        {
            get { return _c2_count; }
            set { _c2_count = value; }
        }
    }
}
