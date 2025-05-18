using Permission.Application.Abstraction.EventBus;
using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Entities;
using Permission.Domain.Enums;
using Permission.Domain.Events;
using Permission.Domain.Repository;
using Serilog;
using SharedKernel;

namespace Permission.Application.Permission.Create;

internal sealed class CreatePermissionCommandHandler(IWrapperRepository _uow, IEventBus eventBus)
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

        Log.Information("Request-Permission: {@Permission}", permission);

        await eventBus.PublishAsync(new OperationProducer(Guid.NewGuid(), Operations.Request.ToString()));

        return permission.Id;
    }
}