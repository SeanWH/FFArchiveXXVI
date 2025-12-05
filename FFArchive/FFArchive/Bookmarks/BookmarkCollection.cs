using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFArchive.Bookmarks
{
    public class BookmarkCollection : CollectionBase
    {
        
        public int Add(Bookmark item)
        {
            int r = 0;

            if (List.Count > 0)
            {
                bool found = false;
                for (int i = 0; i < List.Count; i++)
                {
                    Bookmark b = (Bookmark)List[i];
                    if (b.CompareTo(item) == 0)
                    {
                        found = true;
                        break;   
                    }
                }
                if (!found)
                {
                    r = List.Add(item);
                }
                else
                {
                    r = -1;
                }
            }
            else
            {
                r =  List.Add(item);
            }

            return r;
        }

        public void Insert(int index, Bookmark item)
        {
            if (List.Count > 0)
            {
                bool found = false;
                for (int i = 0; i < List.Count; i++)
                {
                    Bookmark b = (Bookmark)List[i];
                    if (b.CompareTo(item) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    List.Insert(index, item);
                }
                else
                {
                    return;
                }
            }
        }

        public void Remove(Bookmark item)
        {
            List.Remove(item);
        }

        public bool Contains(Bookmark item)
        {
            return List.Contains(item);
        }

        public int IndexOf(Bookmark item)
        {
            return List.IndexOf(item);
        }

        public void CopyTo(Bookmark[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public Bookmark this[int index]
        {
            get { return (Bookmark)List[index]; }
            set { List[index] = value; }
        }

        public void Sort()
        {
            ArrayList l = new ArrayList();

            foreach (Bookmark b in this.List)
            {
                l.Add(b);
            }
            
            l.Sort();
            
            this.List.Clear();

            for (int i = 0; i < l.Count; i++)
                this.List.Add((Bookmark)l[i]);
        }

        public int SiteCount(string sitename)
        {
            int count = 0;
            for (int i = 0; i < List.Count; i++)
            {
                Bookmark b = (Bookmark)List[i];
                if (b.Address.Contains(sitename))
                {
                    count++;
                }
            }
            return count;
        }

    }
}
