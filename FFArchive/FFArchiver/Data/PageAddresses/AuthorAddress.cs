#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: AuthorAddress.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using NaeshLibrary.Extensions;

    public class AuthorAddress : IFfnAddress
    {
        public AuthorAddress(string address, string authorName, string linkedId)
        {
            Address = address;
            AuthorName = authorName;
            LinkedId = linkedId;
        }

        public string Address { get; }
        public string AuthorName { get; }
        public string LinkedId { get; }
        public string LinkTarget => "author";

        public static bool operator !=(AuthorAddress left, AuthorAddress right) => !(left == right);

        public static bool operator <(AuthorAddress left, AuthorAddress right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(AuthorAddress left, AuthorAddress right) => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator ==(AuthorAddress left, AuthorAddress right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator >(AuthorAddress left, AuthorAddress right) => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(AuthorAddress left, AuthorAddress right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;

        public int CompareTo(IFfnAddress other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other is AuthorAddress otherAuthor)
            {
                int val = string.CompareOrdinal(LinkTarget, otherAuthor.LinkTarget);
                val = val == 0 ? string.CompareOrdinal(AuthorName, otherAuthor.AuthorName) : val;
                val = val == 0 ? string.CompareOrdinal(LinkedId, otherAuthor.LinkedId) : val;
                return val == 0 ? string.CompareOrdinal(Address, otherAuthor.Address) : val;
            }

            return string.CompareOrdinal(LinkTarget, other.LinkTarget);
        }

        public bool Equals(IFfnAddress other)
        {
            if (other is AuthorAddress otherAuthor)
            {
                return AuthorName.Equals(otherAuthor.AuthorName) &&
                       LinkedId.Equals(otherAuthor.LinkedId) &&
                       Address.Equals(otherAuthor.Address);
            }

            return false;
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

            if (obj is IFfnAddress address)
            {
                return Equals(address);
            }

            return false;
        }

        public override int GetHashCode() => LinkTarget.StringHash256() ^ Address.StringHash256() ^ LinkedId.StringHash256() ^ AuthorName.StringHash256();
    }
}