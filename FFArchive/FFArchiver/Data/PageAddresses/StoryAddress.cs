#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: StoryAddress.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using NaeshLibrary.Extensions;

    public class StoryAddress : IFfnAddress
    {
        public StoryAddress(string address, string linkedId, string storyTitle, string chapterTitle, string chapterIndex)
        {
            Address = address;
            LinkedId = linkedId;
            StoryTitle = storyTitle;
            ChapterTitle = chapterTitle;
            ChapterIndex = chapterIndex;
        }

        public string Address { get; }
        public string ChapterIndex { get; }
        public string ChapterTitle { get; }
        public string LinkedId { get; }
        public string LinkTarget => "story";
        public string StoryTitle { get; }

        public static bool operator !=(StoryAddress left, StoryAddress right) => !(left == right);

        public static bool operator <(StoryAddress left, StoryAddress right) => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(StoryAddress left, StoryAddress right) => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator ==(StoryAddress left, StoryAddress right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator >(StoryAddress left, StoryAddress right) => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(StoryAddress left, StoryAddress right) => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;

        public int CompareTo(IFfnAddress other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other is StoryAddress otherStory)
            {
                int val = string.CompareOrdinal(StoryTitle, otherStory.StoryTitle);
                val = val == 0 ? string.CompareOrdinal(ChapterTitle, otherStory.ChapterTitle) : val;
                val = val == 0 ? string.CompareOrdinal(ChapterIndex, otherStory.ChapterIndex) : val;
                val = val == 0 ? string.CompareOrdinal(Address, otherStory.Address) : val;
                return val == 0 ? string.CompareOrdinal(LinkedId, otherStory.LinkedId) : val;
            }

            return string.CompareOrdinal(LinkTarget, other.LinkTarget);
        }

        public bool Equals(IFfnAddress other)
        {
            if (other is StoryAddress otherStory)
            {
                return StoryTitle.Equals(otherStory.StoryTitle) &&
                       ChapterTitle.Equals(otherStory.ChapterTitle) &&
                       ChapterIndex.Equals(otherStory.ChapterIndex) &&
                       Address.Equals(otherStory.Address) &&
                       LinkedId.Equals(otherStory.LinkedId);
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

            if (obj is StoryAddress otherAddress)
            {
                return Equals(otherAddress);
            }

            return false;
        }

        public override int GetHashCode() =>
            StoryTitle.StringHash256() ^
            ChapterTitle.StringHash256() ^
            ChapterIndex.StringHash256() ^
            Address.StringHash256() ^
            LinkedId.StringHash256() ^
            LinkTarget.StringHash256();
    }
}