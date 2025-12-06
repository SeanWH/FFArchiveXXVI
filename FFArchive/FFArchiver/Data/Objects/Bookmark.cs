#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: Bookmark.cs

#endregion File Info

namespace FFArchiver.Data.Objects
{
    using PageAddresses;
    using System;

    public class Bookmark : IComparable<Bookmark>, IEquatable<Bookmark>
    {
        public Bookmark(string address, DateTime? dateAdded, DateTime? dateLastVisited)
        {
            FfnAddress = FfnAddressFactory.GetAddress(address);
            DateAdded = dateAdded ?? DateTime.Now;
            DateLastVisited = dateLastVisited ?? DateTime.Now;
        }

        public DateTime DateAdded { get; }
        public DateTime DateLastVisited { get; }
        public IFfnAddress FfnAddress { get; }

        public int CompareTo(Bookmark other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            int val = DateAdded.CompareTo(other.DateAdded);
            val = val == 0 ? DateLastVisited.CompareTo(other.DateLastVisited) : val;
            return val == 0 ? FfnAddress.CompareTo(other.FfnAddress) : val;
        }

        public bool Equals(Bookmark other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Bookmark left, Bookmark right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Bookmark left, Bookmark right)
        {
            return !(left == right);
        }

        public static bool operator <(Bookmark left, Bookmark right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Bookmark left, Bookmark right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Bookmark left, Bookmark right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Bookmark left, Bookmark right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}