namespace FFArchiveXXVI.Model.Addresses;

using FFArchiveXXVI.Model.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;

public sealed class StoryAddress(string address, string? linkedId = null, string? storyTitle = null, string? chapterTitle = null, string? chapterIndex = null) : IFfnAddress
{
    public string Address { get; } = address;

    public string? LinkedId { get; } = linkedId;

    public FfnUrlType LinkTarget => FfnUrlType.Story;

    public string? ChapterIndex { get; set; } = chapterIndex;
    public string? ChapterTitle { get; set; } = chapterTitle;
    public string? StoryTitle { get; set; } = storyTitle;

    public int CompareTo(IFfnAddress? other)
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

        return string.CompareOrdinal(nameof(LinkTarget), nameof(other.LinkTarget));
    }

    public bool Equals(IFfnAddress? other)
    {
        bool isEqual = false;

        if (other is StoryAddress otherStory)
        {
            isEqual = isEqual && otherStory.Address.Equals(Address, StringComparison.Ordinal);

            if (otherStory.StoryTitle is not null && StoryTitle is not null)
            {
                isEqual = otherStory.StoryTitle.Equals(StoryTitle, StringComparison.Ordinal);
            }
            if (otherStory.ChapterTitle is not null && ChapterTitle is not null)
            {
                isEqual = isEqual && otherStory.ChapterTitle.Equals(ChapterTitle, StringComparison.Ordinal);
            }
            if (otherStory.ChapterIndex is not null && ChapterIndex is not null)
            {
                isEqual = isEqual && otherStory.ChapterIndex.Equals(ChapterIndex, StringComparison.Ordinal);
            }
            if (otherStory.LinkedId is not null && LinkedId is not null)
            {
                isEqual = isEqual && otherStory.LinkedId.Equals(LinkedId, StringComparison.Ordinal);
            }
        }

        return isEqual;
    }

    public bool Equals(IFfnAddress? x, IFfnAddress? y)
    {
        return x?.Equals(y) ?? y is null;
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

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        if (StoryTitle is null || ChapterTitle is null || ChapterIndex is null)
        {
            return 0;
        }

        if (LinkedId is null)
        {
            return StoryTitle.StringHash256() ^ ChapterTitle.StringHash256() ^ ChapterIndex.StringHash256() ^ Address.StringHash256();
        }

        return StoryTitle.StringHash256() ^ ChapterTitle.StringHash256() ^ ChapterIndex.StringHash256() ^ Address.StringHash256() ^ LinkedId.StringHash256();
    }

    public int GetHashCode([DisallowNull] IFfnAddress obj)
    {
        if (obj is StoryAddress storyAddress)
        {
            return storyAddress.GetHashCode();
        }
        return 0;
    }

    public static bool operator ==(StoryAddress left, StoryAddress right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(StoryAddress left, StoryAddress right)
    {
        return !(left == right);
    }

    public static bool operator <(StoryAddress left, StoryAddress right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(StoryAddress left, StoryAddress right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(StoryAddress left, StoryAddress right)
    {
        return left?.CompareTo(right) > 0;
    }

    public static bool operator >=(StoryAddress left, StoryAddress right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}