using Microsoft.EntityFrameworkCore;
using TrailHub.Domain.Entities;

namespace TrailHub.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Trail> Trails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trail>(builder =>
        {

            builder.ToTable("Trails", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_Length_NotNegative", sql: $"\"{nameof(Trail.Length)}\" > 0");
            });

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(30);

            builder.Property(c => c.Description).HasMaxLength(200);
        });
    }
}