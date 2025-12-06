#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: StringExtensionArrayTestDataAttribute.cs

#endregion File Info

namespace NaeshLibrary.Tests.TestData
{
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public class StringExtensionArrayTestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new string[] { "item 1", "item 2", "item 3", "item 4", "item 5" }, false };
            yield return new object[] { new string[] { "item 1", "item 2", "item 3", "item 4", "" }, true };
            yield return new object[] { new string[] { "item 1", "item 2", "item 3", "", "item 5" }, true };
            yield return new object[] { new string[] { "item 1", "item 2", null, "item 4", "item 5" }, true };
            yield return new object[] { new string[] { "item 1", "      ", "item 3", "item 4", "item 5" }, true };
            yield return new object[] { new string[] { string.Empty, "item 2", "item 3", "item 4", "item 5" }, true };
        }
    }
}