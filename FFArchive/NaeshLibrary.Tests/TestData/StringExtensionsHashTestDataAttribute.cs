#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: StringExtensionsHashTestDataAttribute.cs

#endregion File Info

namespace NaeshLibrary.Tests.TestData
{
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public class StringExtensionsHashTestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "this is a test.", 1315942058 };
            yield return new object[] { "THIS IS A TEST.", 1585662934 };
            yield return new object[] { "This is a test.", -336158040 };
        }
    }
}