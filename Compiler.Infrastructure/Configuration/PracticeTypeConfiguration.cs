using Compiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compiler.Infrastructure.Configuration;

internal class PracticeTypeConfiguration : IEntityTypeConfiguration<PracticeCard>
{
    public void Configure(EntityTypeBuilder<PracticeCard> builder)
    {
        builder.OwnsOne(x => x.ProjectData);
    }
}
