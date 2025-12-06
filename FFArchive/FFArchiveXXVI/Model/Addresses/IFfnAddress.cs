namespace FFArchiveXXVI.Model.Addresses;

using System;

public interface IFfnAddress : IComparable<IFfnAddress>, IEquatable<IFfnAddress>
{
    string Address { get; }
    string? LinkedId { get; }
    FfnUrlType LinkTarget { get; }
}