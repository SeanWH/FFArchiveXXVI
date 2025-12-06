namespace FFArchiver.Tests.Data.PageAddresses
{
    using FFArchiver.Data.PageAddresses;
    using Xunit;

    public class FfnAddressFactoryShould
    {
        [Theory, InlineData("http://www.fanfiction.net/u/606026/")]
        public void ReturnAuthorAddressType(string address)
        {
            IFfnAddress authorAddress = FfnAddressFactory.GetAddress(address);
            Assert.IsType<AuthorAddress>(authorAddress);
        }

        [Theory, InlineData("https://www.fanfiction.net/community/Back-From-Of-The-Grave/9315")]
        public void ReturnGroupAddressType(string address)
        {
            IFfnAddress groupAddress = FfnAddressFactory.GetAddress(address);
            Assert.IsType<GroupAddress>(groupAddress);
        }

        [Theory, InlineData("http://www.fanfiction.net/s/521965/1/")]
        public void ReturnStoryAddressType(string address)
        {
            IFfnAddress storyAddress = FfnAddressFactory.GetAddress(address);
            Assert.IsType<StoryAddress>(storyAddress);
        }
    }
}