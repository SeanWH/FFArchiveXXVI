namespace FFArchiveXXVI.Model.Extensions;

using System;

public static class DateTimeExtensions
{
    public static DateTime UnixEpoch => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static DateTime FromUnixTime(this long unixTime)
    {
        return UnixEpoch.AddSeconds(unixTime);
    }

    public static long ToUnixTime(this DateTime dateTime)
    {
        return (long)(dateTime - UnixEpoch).TotalSeconds;
    }
}