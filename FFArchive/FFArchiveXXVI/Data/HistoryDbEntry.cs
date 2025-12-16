namespace FFArchiveXXVI.Data;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HistoryDbEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime? VisitedDate { get; set; }

    [ForeignKey(nameof(BookmarkDbEntry.Id))]
    public int BookmarkId { get; set; }
}