#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: PageAddress.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using NaeshLibrary.Extensions;

    public class PageAddress : IFfnAddress
    {
        public PageAddress(string address, string linkedId = null)
        {
            Address = address;
            LinkedId = linkedId;
        }

        public string Address { get; }
        public string LinkedId { get; }
        public string LinkTarget => "ffnpage";

        public static bool operator !=(PageAddress left, PageAddress right) => !(left == right);

        public static bool operator <(PageAddress left, PageAddress right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(PageAddress left, PageAddress right) => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator ==(PageAddress left, PageAddress right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator >(PageAddress left, PageAddress right) => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(PageAddress left, PageAddress right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;

        public int CompareTo(IFfnAddress other)
        {
            int val = string.CompareOrdinal(LinkTarget, other.LinkTarget);
            val = val == 0 ? string.CompareOrdinal(Address, other.Address) : val;
            return val;
        }

        public bool Equals(IFfnAddress other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return LinkTarget.Equals(other.LinkTarget) && Address.Equals(other.Address);
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

            if (obj is PageAddress address)
            {
                return Equals(address);
            }

            return false;
        }

        public override int GetHashCode() => Address.StringHash256() ^ LinkedId.StringHash256() ^ LinkTarget.StringHash256();
    }
}