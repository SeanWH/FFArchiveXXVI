using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FFArchive.Bookmarks
{
    public class BookmarkList : IList<Bookmark>
    {
        private readonly List<Bookmark> _list = new List<Bookmark>();

        public IEnumerator<Bookmark> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }

        public void Add(Bookmark item)
        {
            if (_list.Any())
            {
                if (_list.Contains(item))
                {
                    return;
                }
            }

            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(Bookmark item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Bookmark[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Bookmark item)
        {
            return _list.Remove(item);
        }

        public int Count => _list.Count;

        public bool IsReadOnly => ((ICollection<Bookmark>)_list).IsReadOnly;

        public int IndexOf(Bookmark item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Bookmark item)
        {
            if (_list.Any())
            {
                if (_list.Contains(item))
                {
                    return;
                }

                _list.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public Bookmark this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
    }
}