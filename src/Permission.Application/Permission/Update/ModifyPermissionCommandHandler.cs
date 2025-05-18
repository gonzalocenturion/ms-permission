using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Entities;
using Permission.Domain.Repository;
using Serilog;
using SharedKernel;
using System.Security;

namespace Permission.Application.Permission.Update;

internal sealed class ModifyPermissionCommandHandler(IWrapperRepository _uow)
    : ICommandHandler<ModifyPermissionCommand>
{
    public async Task<Result> Handle(ModifyPermissionCommand command, CancellationToken cancellationToken)
    {
        var permissionToUpdate = await _uow.Permission.GetByIdAsync(command.id);

        if (permissionToUpdate is null) return Result.Failure(PermissionError.NotFound(command.id));

        permissionToUpdate.PermissionDate = DateTime.UtcNow;
        permissionToUpdate.EmployeeForename = command.forename;
        permissionToUpdate.EmployeeSurname = command.surname;
        permissionToUpdate.PermissionTypeId = (int)command.permissiontype;

        _uow.Permission.Update(permissionToUpdate);

        await _uow.SaveChangesAsync();

        Log.Information("PermissionRecord: {@Permission}", permissionToUpdate);

        return Result.Success();
    }
}