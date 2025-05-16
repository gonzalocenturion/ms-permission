using System.ComponentModel;

namespace Permission.Domain.Enums;

public enum PermissionTypes
{
    [Description("Vacation")]
    Vacation,

    [Description("Sick Leave")]
    SickLeave,

    [Description("Personal Leave")]
    PersonalLeave,

    [Description("Bereavement Leave")]
    BereavementLeave,

    [Description("Jury Duty")]
    JuryDuty,

    [Description("Parental Leave")]
    ParentalLeave,

    [Description("Unpaid Leave")]
    UnpaidLeave,

    [Description("Remote Work")]
    RemoteWork,

    [Description("Study Leave")]
    StudyLeave 
}