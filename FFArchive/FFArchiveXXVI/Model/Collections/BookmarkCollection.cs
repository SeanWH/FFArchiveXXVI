namespace FFArchiveXXVI.Model.Collections;

using FFArchiveXXVI.Model.Bookmarks;

using System.Collections.Generic;

/// <summary>
/// A List<Bookmark> that prevents duplicate bookmarks from being added.
/// </summary>
public class BookmarkCollection : List<Bookmark>
{
    private readonly List<Bookmark> List = [];

    public new void Add(Bookmark item)
    {
        if (List.Count > 0)
        {
            bool found = false;
            for (int i = 0; i < List.Count; i++)
            {
                Bookmark b = List[i];
                if (b.CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                List.Add(item);
            }
        }
        else
        {
            List.Add(item);
        }
    }

    public new void Insert(int index, Bookmark item)
    {
        if (List.Count > 0)
        {
            bool found = false;
            for (int i = 0; i < List.Count; i++)
            {
                Bookmark b = List[i];
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
        }
    }

    public int SiteCount(string sitename)
    {
        int count = 0;
        for (int i = 0; i < List.Count; i++)
        {
            if (List[i] is Bookmark b && b.Url?.Contains(sitename) == true)
            {
                count++;
            }
        }
        return count;
    }
}