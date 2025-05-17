using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Enums;

namespace Permission.Application.Permission.Create;

public sealed record CreatePermissionCommand : ICommand<int>
{
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }
    public PermissionTypes PermissionType { get; set; }
}
