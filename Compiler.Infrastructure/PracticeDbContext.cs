using Compiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Compiler.Infrastructure;

public class PracticeDbContext : DbContext
{
    public DbSet<PracticeCard> PracticeCards => Set<PracticeCard>();

    public PracticeDbContext(DbContextOptions<PracticeDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
