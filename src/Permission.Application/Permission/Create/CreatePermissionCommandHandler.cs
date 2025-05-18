using Microsoft.Extensions.Logging.Abstractions;
using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Entities;
using Permission.Domain.Repository;
using Serilog;
using SharedKernel;

namespace Permission.Application.Permission.Create;

internal sealed class CreatePermissionCommandHandler(IWrapperRepository _uow)
    : ICommandHandler<CreatePermissionCommand, int>
{
    public async Task<Result<int>> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {
        var permission = new EmployeePermission
        {
            EmployeeForename = command.EmployeeForename,
            EmployeeSurname = command.EmployeeSurname,
            PermissionDate = DateTime.Now,
            PermissionTypeId = (int)command.PermissionType,
        };

        await _uow.Permission.AddAsync(permission);
        await _uow.SaveChangesAsync();

        Log.Information("PermissionRecord: {@Permission}", permission);

        return permission.Id;
    }
}