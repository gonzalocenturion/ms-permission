using System.ComponentModel;

namespace Permission.Domain.Enums;

public enum PermissionTypes
{
    [Description("Vacation")]
    Vacation = 1,

    [Description("Sick Leave")]
    SickLeave = 2,

    [Description("Personal Leave")]
    PersonalLeave = 3,

    [Description("Bereavement Leave")]
    BereavementLeave = 4,

    [Description("Jury Duty")]
    JuryDuty = 5,

    [Description("Parental Leave")]
    ParentalLeave = 6,

    [Description("Unpaid Leave")]
    UnpaidLeave = 7,

    [Description("Remote Work")]
    RemoteWork = 8,

    [Description("Study Leave")]
    StudyLeave = 9
}