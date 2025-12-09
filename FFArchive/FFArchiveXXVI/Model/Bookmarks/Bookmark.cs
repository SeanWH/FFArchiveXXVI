namespace FFArchiveXXVI.Model.Bookmarks;

using FFArchiveXXVI.Model.Addresses;

using System;

public class Bookmark(string title, string url) : TreeNode, IComparable
{
    public string? Title { get; set; } = title;
    public string? Url { get; set; } = url;
    public IFfnAddress? Address { get; set; } = FfnAddressFactory.GetAddress(url);
    public FfnUrlType Target { get; } = FfnUrlUtilities.GetFfnUrlTypeFromUrl(url);
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Modified { get; set; } = DateTime.Now;

    private (string, string) ParseUrls(string otherUrl)
    {
        if (!string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(otherUrl))
        {
            int pos = Url.LastIndexOf('/');
            string url1 = Url[..pos];
            pos = url1.LastIndexOf('/');
            string title1 = url1[..pos];

            pos = otherUrl.LastIndexOf('/');
            string oUrl = otherUrl[..pos];
            pos = oUrl.LastIndexOf('/');
            string oTitle = oUrl[..pos];
            return (title1, oTitle);
        }

        return (string.Empty, string.Empty);
    }

    public int CompareTo(object? obj)
    {
        if (obj is Bookmark bookmark)
        {
            if (Title?.CompareTo(bookmark.Title) == 0)
            {
                if (Url?.CompareTo(bookmark.Url) == 0)
                {
                    return 0;
                }
                else
                {
                    var (title1, bTitle) = ParseUrls(bookmark.Url ?? string.Empty);

                    if (title1.Equals(bTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        return 0;
                    }
                    else
                    {
                        return title1.CompareTo(bTitle);
                    }
                }
            }
            else
            {
                if (Title != null && bookmark.Title != null)
                {
                    return Title.CompareTo(bookmark.Title);
                }
                else if (Title == null && bookmark.Title == null)
                {
                    return 0;
                }
                else if (Title == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        return -1;
    }

    public override bool Equals(object? obj)
    {
        return obj is Bookmark bookmark && ReferenceEquals(this, bookmark) && CompareTo(obj) == 0;
    }

    public override int GetHashCode()
    {
        return (Title?.GetHashCode() ?? 0) ^
               (Url?.GetHashCode() ?? 0) ^
               nameof(Target).GetHashCode() ^
               Created.GetHashCode() ^
               Modified.GetHashCode();
    }

    public static bool operator ==(Bookmark left, Bookmark right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Bookmark left, Bookmark right)
    {
        return !(left == right);
    }

    public static bool operator <(Bookmark left, Bookmark right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(Bookmark left, Bookmark right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(Bookmark left, Bookmark right)
    {
        return left?.CompareTo(right) > 0;
    }

    public static bool operator >=(Bookmark left, Bookmark right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}