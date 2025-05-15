using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Permission.Infrastructure.Permission;

public class PermissionConfiguration : IEntityTypeConfiguration<Domain.Entities.Permission>
{
    private const int NAME_MAX_LEN = 100;

    public void Configure(EntityTypeBuilder<Domain.Entities.Permission> builder)
    {
        builder.HasOne(p => p.PermissionType)
            .WithMany()
            .HasForeignKey(p => p.PermissionTypeId);

        builder.Property(p => p.EmployeeForename)
            .IsRequired()
            .HasMaxLength(NAME_MAX_LEN);

        builder.Property(p => p.EmployeeSurname)
            .IsRequired()
            .HasMaxLength(NAME_MAX_LEN);

        builder.Property(t => t.PermissionDate)
           .IsRequired();
    }
}