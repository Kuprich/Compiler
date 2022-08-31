using Compiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Compiler.Persistence;

public class PracticeDbContext : DbContext
{
    public DbSet<Practice> Practices => Set<Practice>();

    public PracticeDbContext(DbContextOptions<PracticeDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
