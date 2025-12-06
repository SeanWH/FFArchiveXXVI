#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: DateTimeTestDataAttribute.cs

#endregion File Info

namespace NaeshLibrary.Tests.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public class DateTimeTestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1000000000L, new DateTime(2001, 09, 09, 1, 46, 40, DateTimeKind.Utc) };
            yield return new object[] { 0L, new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
            yield return new object[] { 99999999999L, new DateTime(5138, 11, 16, 9, 46, 39, DateTimeKind.Utc) };
        }
    }
}