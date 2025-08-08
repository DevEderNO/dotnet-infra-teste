using System;
using Infra.Domain.Peaple;
using Infra.Infra.ValueConverters;
using Infra.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  public DbSet<Peaple> Peaples { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Peaple>()
    .Property(p => p.Email)
    .HasConversion(EmailConverter.Converter);

    modelBuilder.Entity<Peaple>()
    .Property(p => p.Phone)
    .HasConversion(PhoneConverter.Converter);
  }
}
