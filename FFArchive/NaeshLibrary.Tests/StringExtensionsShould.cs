#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: StringExtensionsShould.cs

#endregion File Info

namespace NaeshLibrary.Tests
{
    using Extensions;
    using TestData;
    using Xunit;

    public class StringExtensionsShould
    {
        [Theory, InlineData("target", "ed", "targeted")]
        public void ReturnAffixAppendedToTarget(string target, string affix, string expected)
        {
            string result = target.Affix(affix);

            Assert.Equal(expected, result);
        }

        [Theory, StringExtensionsHashTestData]
        public void ReturnCorrectHashValue(string testVal, int expected)
        {
            int value = testVal.StringHash256();
            Assert.Equal(expected, value);
        }

        [Fact]
        public void ReturnFalseIfDoesNotContainInvalidPathCharacters()
        {
            var test = "this can be a valid path string.";
            bool isBadPathString = test.IsInvalidPath();
            Assert.False(isBadPathString);
        }

        [Theory, InlineData("pre", "fix", "prefix")]
        public void ReturnPrefixPrependedToTarget(string prefix, string target, string expected)
        {
            Assert.Equal(expected, target.Prefix(prefix));
        }

        [Theory, StringExtensionArrayTestData]
        public void ReturnTrueIfAnyElementsAreNullOrEmptyOrWhitespace(string[] testArray, bool expected)
        {
            bool val = testArray.IsAnyNullOrWhitespace();
            Assert.Equal(expected, val);
        }

        [Theory, InlineData("<this is a bad path* string?>")]
        public void ReturnTrueIfContainsInvalidPathCharacters(string test)
        {
            bool isBadPathString = test.IsInvalidPath();
            Assert.True(isBadPathString);
        }

        [Theory, InlineData("This! is; a. test: string, to strip.", "This is a test string to strip")]
        public void StripAllPunctuation(string test, string expected)
        {
            Assert.Equal(expected, test.StripPunctuation());
        }
    }
}