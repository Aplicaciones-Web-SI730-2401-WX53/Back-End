using _3._Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._Data.Context;

public class LearningCenterDBContext : DbContext
{
    public LearningCenterDBContext()
    {
    }

    public LearningCenterDBContext(DbContextOptions<LearningCenterDBContext> options) : base(options)
    {
    }

    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Section> Sections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=Upc123!;Database=LearningCenter",
                serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Tutorial>().ToTable("Tutorial");

        builder.Entity<Section>().ToTable("Section");
    }
}