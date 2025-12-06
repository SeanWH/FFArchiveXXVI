#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-09
//
// SOLUTION: FFArchiverCore
// PROJECT: FFArchiver
// FILE: IFfnAddress.cs

#endregion File Info

namespace FFArchiver.Data.PageAddresses
{
    using System;

    public interface IFfnAddress : IComparable<IFfnAddress>, IEquatable<IFfnAddress>
    {
        string Address { get; }
        string LinkedId { get; }
        string LinkTarget { get; }
    }
}