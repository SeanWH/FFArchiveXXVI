namespace FFArchiveXXVI.Model.LocalFiles;

using System.IO;

public class LocalFileObject
{
    public LocalFileObject(string pathToFileObject)
    {
        PathToFileObject = pathToFileObject;

        IsFolder = Directory.Exists(pathToFileObject);

        if (!IsFolder)
        {
            string[] parts = pathToFileObject.Split(Path.DirectorySeparatorChar);
            Title = parts[0];
            Author = parts[1];
            Universe = parts[2];
            WebSite = parts[3];

            FileName = System.IO.Path.GetFileNameWithoutExtension(PathToFileObject);
            FileType = System.IO.Path.GetExtension(PathToFileObject).TrimStart('.').ToUpperInvariant();
        }
    }

    public string PathToFileObject { get; }
    public string FileName { get; } = string.Empty;
    public string FileType { get; } = string.Empty;
    public string Universe { get; } = string.Empty;
    public string Author { get; } = string.Empty;
    public string Title { get; } = string.Empty;
    public string WebSite { get; } = string.Empty;
    public bool IsFolder { get; } = false;
}