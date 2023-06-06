using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;
using webApi.DataClasses.Entities;

namespace webApi.DataClasses;

public class DataContext : DbContext
{
    public DbSet<Writer> Writers { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<TestEntityOne> EntityOnes { get; set; } = null!;
    public DbSet<TestEntityThree> TestAutoEntities { get; set; } = null!;

    public static readonly string DbPath = @"Data/base.db";

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        var optionsForTests = options.FindExtension<InMemoryOptionsExtension>();

        if ((optionsForTests is null) && !Directory.Exists(Path.GetDirectoryName(DbPath)))
            throw new Exception("'Data' folder for database file not exists.");

        if (optionsForTests is null)
            this.Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
            options.UseSqlite($"Data Source={DbPath}");
    }
}
