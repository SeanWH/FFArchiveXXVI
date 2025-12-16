namespace FFArchiveXXVI.Data;

using Microsoft.EntityFrameworkCore;

public class FfnDataDbContext : DbContext
{
    public DbSet<BookmarkDbEntry> Bookmarks { get; set; }
    public DbSet<HistoryDbEntry> History { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ffndata.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}