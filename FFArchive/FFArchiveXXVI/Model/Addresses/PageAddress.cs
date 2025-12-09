namespace FFArchiveXXVI.Model.Addresses;

using FFArchiveXXVI.Model.Extensions;

using System.Diagnostics.CodeAnalysis;

public sealed class PageAddress(string address, string? linkedId = null) : IFfnAddress
{
    public string Address { get; } = address;
    public string? LinkedId { get; } = linkedId;
    public FfnUrlType LinkTarget => FfnUrlType.Page;

    public static bool operator !=(PageAddress left, PageAddress right) => !(left == right);

    public static bool operator <(PageAddress left, PageAddress right) => left is null ? right is not null : left.CompareTo(right) < 0;

    public static bool operator <=(PageAddress left, PageAddress right) => left is null || left.CompareTo(right) <= 0;

    public static bool operator ==(PageAddress left, PageAddress right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator >(PageAddress left, PageAddress right) => left?.CompareTo(right) > 0;

    public static bool operator >=(PageAddress left, PageAddress right) => left is null ? right is null : left.CompareTo(right) >= 0;

    public int CompareTo(IFfnAddress? other)
    {
        int val = string.CompareOrdinal(nameof(LinkTarget), nameof(other.LinkTarget));
        return val == 0 ? string.CompareOrdinal(Address, other?.Address) : val;
    }

    public bool Equals(IFfnAddress? other)
    {
        if (other is null)
        {
            return false;
        }

        return LinkTarget.Equals(other.LinkTarget) && Address.Equals(other.Address);
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

        if (obj is PageAddress pageAddress)
        {
            return Equals(pageAddress);
        }

        return false;
    }

    public override int GetHashCode()
    {
        if (LinkedId is null)
        {
            return Address.StringHash256() ^ nameof(LinkTarget).StringHash256();
        }

        return Address.StringHash256() ^ LinkedId.StringHash256() ^ nameof(LinkTarget).StringHash256();
    }

    public bool Equals(IFfnAddress? x, IFfnAddress? y)
    {
        return x?.Equals(y) ?? y is null;
    }

    public int GetHashCode([DisallowNull] IFfnAddress obj)
    {
        if (obj.LinkedId is null)
        {
            return obj.Address.StringHash256() ^ nameof(obj.LinkTarget).StringHash256();
        }

        return obj.Address.StringHash256() ^ obj.LinkedId.StringHash256() ^ nameof(obj.LinkTarget).StringHash256();
    }
}