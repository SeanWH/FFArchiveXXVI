#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: DateTimeExtensionsShould.cs

#endregion File Info

namespace NaeshLibrary.Tests
{
    using Extensions;
    using System;
    using TestData;
    using Xunit;

    public class DateTimeExtensionsShould
    {
        [Theory, DateTimeTestData]
        public void ConvertFromUnixTime(long unixTime, DateTime expected)
        {
            DateTime sut = unixTime.FromUnixTime();
            Assert.Equal(expected, sut);
        }

        [Theory, DateTimeTestData]
        public void ConvertToUnixTime(long expected, DateTime dateTime)
        {
            long sut = dateTime.ToUnixTime();
            Assert.Equal(expected, sut);
        }
    }
}