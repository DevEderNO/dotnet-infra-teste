using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data;

public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionsBuilder.UseNpgsql("Host=localhost;Database=Infra;Username=postgres;Password=postgres");
    return new AppDbContext(optionsBuilder.Options);
  }
}
