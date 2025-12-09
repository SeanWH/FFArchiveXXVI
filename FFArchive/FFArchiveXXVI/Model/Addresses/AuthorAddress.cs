namespace FFArchiveXXVI.Model.Addresses;

using FFArchiveXXVI.Model.Extensions;

using System.Diagnostics.CodeAnalysis;

public sealed class AuthorAddress(string authorName, string address, string linkedId) : IFfnAddress
{
    public string Address { get; } = address;
    public string LinkedId { get; } = linkedId;
    public string AuthorName { get; } = authorName;
    public FfnUrlType LinkTarget => FfnUrlType.Author;

    public int CompareTo(IFfnAddress? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is AuthorAddress otherAuthor)
        {
            int val = string.CompareOrdinal(nameof(LinkTarget), nameof(other.LinkTarget));
            val = val == 0 ? string.CompareOrdinal(AuthorName, otherAuthor.AuthorName) : val;
            val = val == 0 ? string.CompareOrdinal(LinkedId, otherAuthor.LinkedId) : val;
            return val == 0 ? string.CompareOrdinal(Address, otherAuthor.Address) : val;
        }

        return string.CompareOrdinal(nameof(LinkTarget), nameof(other.LinkTarget));
    }

    public bool Equals(IFfnAddress? other)
    {
        if (other is AuthorAddress otherAuthor)
        {
            return AuthorName.Equals(otherAuthor.AuthorName) &&
                   LinkedId.Equals(otherAuthor.LinkedId) &&
                   Address.Equals(otherAuthor.Address);
        }

        return false;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is null)
        {
            return false;
        }

        if (obj is IFfnAddress authorAddress)
        {
            return Equals(authorAddress);
        }

        return false;
    }

    public override int GetHashCode() => nameof(LinkTarget).StringHash256() ^ Address.StringHash256() ^ LinkedId.StringHash256() ^ AuthorName.StringHash256();

    public bool Equals(IFfnAddress? x, IFfnAddress? y)
    {
        return x?.Equals(y) ?? y is null;
    }

    public int GetHashCode([DisallowNull] IFfnAddress obj)
    {
        return obj.GetHashCode();
    }

    public static bool operator ==(AuthorAddress left, AuthorAddress right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(AuthorAddress left, AuthorAddress right)
    {
        return !(left == right);
    }

    public static bool operator <(AuthorAddress left, AuthorAddress right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(AuthorAddress left, AuthorAddress right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(AuthorAddress left, AuthorAddress right)
    {
        return left?.CompareTo(right) > 0;
    }

    public static bool operator >=(AuthorAddress left, AuthorAddress right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}