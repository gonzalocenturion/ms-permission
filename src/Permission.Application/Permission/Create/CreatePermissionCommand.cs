using Permission.Application.Abstraction.Messaging;
using SharedKernel;

namespace Permission.Application.Permission.Create;

public sealed record CreatePermissionCommand : ICommand<int>
{
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }

    //Todo: refactorizarlo por enum
    public string PermissionType { get; set; }
}
