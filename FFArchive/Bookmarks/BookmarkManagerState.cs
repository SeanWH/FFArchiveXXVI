// // **************************************************************************************************************
// // FILENAME: BookmarkManagerState.cs
// // AUTHOR:  (Dad)
// // CREATED: --
// // LAST MODIFIED: 2019-07-21
// //
// // PART OF: FanFictionArchive IN SOLUTION: FanFictionArchive
// // **************************************************************************************************************
namespace FFArchive.Bookmarks
{
    public enum BookmarkManagerState
    {
        None,
        Import,
        Save,
        Load,
        Update,
        Add,
        Delete
    }
}