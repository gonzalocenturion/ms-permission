using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission.Domain.Enums;
using SharedKernel.Extensions;

namespace Permission.Infrastructure.PermissionType;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.PermissionType>
{
    private const int DESCRIPTION_MAX_LEN = 500;

    public void Configure(EntityTypeBuilder<Domain.Entities.PermissionType> builder)
    {
        builder.HasData(
            new Domain.Entities.PermissionType { Id = 1, Description = PermissionTypes.Vacation.ToDescription() },
            new Domain.Entities.PermissionType { Id = 2, Description = PermissionTypes.SickLeave.ToDescription() },
            new Domain.Entities.PermissionType { Id = 3, Description = PermissionTypes.PersonalLeave.ToDescription() },
            new Domain.Entities.PermissionType { Id = 4, Description = PermissionTypes.BereavementLeave.ToDescription() },
            new Domain.Entities.PermissionType { Id = 5, Description = PermissionTypes.JuryDuty.ToDescription() },
            new Domain.Entities.PermissionType { Id = 6, Description = PermissionTypes.ParentalLeave.ToDescription() },
            new Domain.Entities.PermissionType { Id = 7, Description = PermissionTypes.UnpaidLeave.ToDescription() },
            new Domain.Entities.PermissionType { Id = 8, Description = PermissionTypes.RemoteWork.ToDescription() },
            new Domain.Entities.PermissionType { Id = 9, Description = PermissionTypes.StudyLeave.ToDescription() }
        );

        builder.Property(e => e.Description)
               .HasMaxLength(DESCRIPTION_MAX_LEN)
               .IsRequired();
    }
}