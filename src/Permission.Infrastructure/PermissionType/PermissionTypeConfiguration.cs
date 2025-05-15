using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Permission.Infrastructure.PermissionType;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.PermissionType>
{
    private const int DESCRIPTION_MAX_LEN = 500;

    public void Configure(EntityTypeBuilder<Domain.Entities.PermissionType> builder)
    {
        builder.HasData(
            new Domain.Entities.PermissionType { Id = 1, Description = "Vacation" },
            new Domain.Entities.PermissionType { Id = 2, Description = "Sick Leave" },
            new Domain.Entities.PermissionType { Id = 3, Description = "Personal Leave" },
            new Domain.Entities.PermissionType { Id = 4, Description = "Bereavement Leave" },
            new Domain.Entities.PermissionType { Id = 5, Description = "Jury Duty" },
            new Domain.Entities.PermissionType { Id = 6, Description = "Parental Leave" },
            new Domain.Entities.PermissionType { Id = 7, Description = "Unpaid Leave" },
            new Domain.Entities.PermissionType { Id = 8, Description = "Remote Work" },
            new Domain.Entities.PermissionType { Id = 9, Description = "Study Leave" }
        );

        builder.Property(e => e.Description)
               .HasMaxLength(DESCRIPTION_MAX_LEN)
               .IsRequired();
    }
}