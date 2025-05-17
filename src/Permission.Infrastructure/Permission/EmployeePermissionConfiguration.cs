using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Permission.Infrastructure.Permission;

public class EmployeePermissionConfiguration : IEntityTypeConfiguration<Domain.Entities.EmployeePermission>
{
    private const int NAME_MAX_LEN = 100;
    private const string PERMISSION_TABLE_NAME = "Permission";

    public void Configure(EntityTypeBuilder<Domain.Entities.EmployeePermission> builder)
    {
        builder.ToTable(PERMISSION_TABLE_NAME); 

        builder.Property(p => p.PermissionTypeId)
               .HasColumnName("PermissionType")
               .IsRequired();

        builder.HasOne(p => p.PermissionType)
               .WithMany(pt => pt.Permissions)
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