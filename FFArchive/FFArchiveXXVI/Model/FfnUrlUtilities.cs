namespace FFArchiveXXVI.Model;

using System;

public static class FfnUrlUtilities
{
    public static FfnUrlType GetFfnUrlTypeFromUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return FfnUrlType.Unknown;
        }
        Uri uri;
        try
        {
            uri = new Uri(url);
        }
        catch (UriFormatException)
        {
            return FfnUrlType.Unknown;
        }
        string host = uri.Host.ToLower();
        string[] segments = uri.Segments;
        if (host.Contains("fanfiction.net"))
        {
            if (segments.Length > 1)
            {
                if (segments[1].Trim('/').Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    return FfnUrlType.Story;
                }
                else if (segments[1].Trim('/').Equals("u", StringComparison.OrdinalIgnoreCase))
                {
                    return FfnUrlType.Author;
                }
                else if (segments[1].Trim('/').Equals("community", StringComparison.OrdinalIgnoreCase))
                {
                    return FfnUrlType.C2Group;
                }
                else if (segments[1].Trim('/').Equals("c2", StringComparison.OrdinalIgnoreCase))
                {
                    return FfnUrlType.C2Group;
                }
                else if (segments[1].Trim('/').Contains("profile.php", StringComparison.OrdinalIgnoreCase))
                {
                    return FfnUrlType.Author;
                }
            }
        }
        return FfnUrlType.Unknown;
    }
}