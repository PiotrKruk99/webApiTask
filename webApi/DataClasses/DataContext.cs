using Microsoft.EntityFrameworkCore;
using webApi.DataClasses.Entities;

namespace webApi.DataClasses;

public class DataContext : DbContext
{
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Book> Books { get; set; }

    public string DbPath { get; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        DbPath = @"Data/base.db";

        if (!Directory.Exists(Path.GetDirectoryName(DbPath)))
            throw new Exception("'Data' folder for database file not exists.");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
