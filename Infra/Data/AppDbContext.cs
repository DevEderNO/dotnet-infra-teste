using Infra.Domain.People;
using Infra.Infra.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  public DbSet<People> Peoples { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<People>()
    .Property(p => p.Email)
    .HasConversion(EmailConverter.Converter);

    modelBuilder.Entity<People>()
    .Property(p => p.Phone)
    .HasConversion(PhoneConverter.Converter);
  }
}
