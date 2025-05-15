using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Permission.Infrastructure.PermissionType;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.PermissionType>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.PermissionType> builder)
    {
        builder.Property(e => e.Description)
                .IsRequired();
    }
}