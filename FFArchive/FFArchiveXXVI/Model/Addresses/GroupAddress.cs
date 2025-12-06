namespace FFArchiveXXVI.Model.Addresses;

using FFArchiveXXVI.Model.Extensions;

using System.Diagnostics.CodeAnalysis;

public sealed class GroupAddress(string address, string linkedId, string groupName) : IFfnAddress
{
    public string GroupName { get; } = groupName;

    public string Address { get; } = address;
    public string LinkedId { get; } = linkedId;

    public FfnUrlType LinkTarget => FfnUrlType.C2Group;

    public int CompareTo(IFfnAddress? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is GroupAddress otherGroup)
        {
            int val = string.CompareOrdinal(GroupName, otherGroup.GroupName);
            val = val == 0 ? string.CompareOrdinal(Address, otherGroup.Address) : val;
            return val == 0 ? string.CompareOrdinal(LinkedId, otherGroup.LinkedId) : val;
        }

        return string.CompareOrdinal(nameof(LinkTarget), nameof(other.LinkTarget));
    }

    // Move all 'Equals' overloads to be adjacent for S4136 compliance

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

        if (obj is GroupAddress groupAddress)
        {
            return Equals(groupAddress);
        }

        return false;
    }

    public bool Equals(IFfnAddress? other)
    {
        if (other is GroupAddress otherGroup)
        {
            return GroupName.Equals(otherGroup.GroupName) && Address.Equals(otherGroup.Address) && LinkedId.Equals(otherGroup.LinkedId);
        }

        return false;
    }

    public bool Equals(IFfnAddress? x, IFfnAddress? y)
    {
        return x?.Equals(y) ?? y is null;
    }

    public static bool operator ==(GroupAddress left, GroupAddress right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(GroupAddress left, GroupAddress right) => !(left == right);

    public static bool operator <(GroupAddress left, GroupAddress right) => left is null ? right is not null : left.CompareTo(right) < 0;

    public static bool operator <=(GroupAddress left, GroupAddress right) => left is null || left.CompareTo(right) <= 0;

    public static bool operator >(GroupAddress left, GroupAddress right) => left?.CompareTo(right) > 0;

    public static bool operator >=(GroupAddress left, GroupAddress right) => left is null ? right is null : left.CompareTo(right) >= 0;

    public override int GetHashCode() => GroupName.StringHash256() ^ Address.StringHash256() ^ nameof(LinkTarget).StringHash256() ^ LinkedId.StringHash256();

    public int GetHashCode([DisallowNull] IFfnAddress obj)
    {
        if (obj.LinkedId is null)
        {
            return obj.Address.StringHash256() ^ nameof(LinkTarget).StringHash256();
        }

        return obj.Address.StringHash256() ^ obj.LinkedId.StringHash256() ^ nameof(LinkTarget).StringHash256();
    }
}