#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: GroupAddress.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using NaeshLibrary.Extensions;

    public class GroupAddress : IFfnAddress
    {
        public GroupAddress(string address, string linkedId, string groupName)
        {
            Address = address;
            LinkedId = linkedId;
            GroupName = groupName;
        }

        public string GroupName { get; }

        public string Address { get; }
        public string LinkedId { get; }
        public string LinkTarget => "group";

        public int CompareTo(IFfnAddress other)
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

            return string.CompareOrdinal(LinkTarget, other.LinkTarget);
        }

        public bool Equals(IFfnAddress other)
        {
            if (other is GroupAddress otherGroup)
            {
                return GroupName.Equals(otherGroup.GroupName) && Address.Equals(otherGroup.Address) && LinkedId.Equals(otherGroup.LinkedId);
            }

            return false;
        }

        public static bool operator !=(GroupAddress left, GroupAddress right) => !(left == right);

        public static bool operator <(GroupAddress left, GroupAddress right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(GroupAddress left, GroupAddress right) => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator ==(GroupAddress left, GroupAddress right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator >(GroupAddress left, GroupAddress right) => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(GroupAddress left, GroupAddress right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;

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

            if (obj is GroupAddress address)
            {
                return Equals(address);
            }

            return false;
        }

        public override int GetHashCode() => GroupName.StringHash256() ^ Address.StringHash256() ^ LinkTarget.StringHash256() ^ LinkedId.StringHash256();
    }
}