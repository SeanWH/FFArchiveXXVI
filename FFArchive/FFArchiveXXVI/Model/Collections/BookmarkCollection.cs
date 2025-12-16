namespace FFArchiveXXVI.Model.Collections;

using System.Collections;
using System.Collections.Generic;

using FFArchiveXXVI.Model.Bookmarks;

/// <summary>
/// A List<Bookmark> that prevents duplicate bookmarks from being added.
/// </summary>
public class BookmarkCollection : IList<Bookmark>
{
    private readonly List<Bookmark> _list = [];

    public int Count => ((ICollection<Bookmark>)_list).Count;

    public bool IsReadOnly => ((ICollection<Bookmark>)_list).IsReadOnly;

    public Bookmark this[int index] { get => ((IList<Bookmark>)_list)[index]; set => ((IList<Bookmark>)_list)[index] = value; }

    public BookmarkCollection(List<Bookmark> list)
    {
        // Saying this._list = list would bypass
        // uniqueness requirement--don't want to
        // do that.
        foreach (Bookmark b in list)
        {
            Add(b);
        }
    }

    public void Add(Bookmark item)
    {
        if (_list.Count > 0)
        {
            bool found = false;
            for (int i = 0; i < _list.Count; i++)
            {
                Bookmark b = _list[i];
                if (b.CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                _list.Add(item);
            }
        }
        else
        {
            _list.Add(item);
        }
    }

    public void Insert(int index, Bookmark item)
    {
        if (_list.Count > 0)
        {
            bool found = false;
            for (int i = 0; i < _list.Count; i++)
            {
                Bookmark b = _list[i];
                if (b.CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                _list.Insert(index, item);
            }
        }
    }

    public int SiteCount(string sitename)
    {
        int count = 0;
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] is Bookmark b && b.Url?.Contains(sitename) == true)
            {
                count++;
            }
        }
        return count;
    }

    public int IndexOf(Bookmark item)
    {
        return ((IList<Bookmark>)_list).IndexOf(item);
    }

    public void RemoveAt(int index)
    {
        ((IList<Bookmark>)_list).RemoveAt(index);
    }

    public void Clear()
    {
        ((ICollection<Bookmark>)_list).Clear();
    }

    public bool Contains(Bookmark item)
    {
        return ((ICollection<Bookmark>)_list).Contains(item);
    }

    public void CopyTo(Bookmark[] array, int arrayIndex)
    {
        ((ICollection<Bookmark>)_list).CopyTo(array, arrayIndex);
    }

    public bool Remove(Bookmark item)
    {
        return ((ICollection<Bookmark>)_list).Remove(item);
    }

    public IEnumerator<Bookmark> GetEnumerator()
    {
        return ((IEnumerable<Bookmark>)_list).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }
}