namespace FFArchiveXXVI.Model.Addresses;

public static class FfnAddressFactory
{
    private const int AUTHOR_ID = 2;
    private const int AUTHOR_NAME = 3;
    private const int CHAPTER_IDX = 3;
    private const int GROUP_ID = 3;
    private const int GROUP_NAME = 2;
    private const int STORY_ID = 2;
    private const int STORY_NAME = 4;
    private const int TARGET_IDX = 1;

    private static string RemoveProtocol(string address)
    {
        if (address.StartsWith("https://"))
        {
            //removes https://www.
            address = address[12..];
        }

        if (address.StartsWith("http://"))
        {
            //removes http://www.
            address = address[11..];
        }

        return address;
    }

    private static string[] SplitAddress(string address)
    {
        address = RemoveProtocol(address);

        return address.Split('/');
    }

    public static IFfnAddress GetAddress(string address)
    {
        if (!address.Contains("fanfiction.net/"))
        {
            return new PageAddress(address);
        }

        string[] parts = SplitAddress(address);

        return parts[TARGET_IDX] switch
        {
            "s" => new StoryAddress(address, parts[STORY_ID], parts[STORY_NAME], "", parts[CHAPTER_IDX]),
            "u" => new AuthorAddress(address, parts[AUTHOR_NAME], parts[AUTHOR_ID]),
            "community" => new GroupAddress(address, parts[GROUP_ID], parts[GROUP_NAME]),
            _ => new PageAddress(address),
        };
    }
}