using Microsoft.EntityFrameworkCore;
using Permission.Application.Abstraction.EventBus;
using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Enums;
using Permission.Domain.Events;
using Permission.Domain.Repository;
using Serilog;
using SharedKernel;
using SharedKernel.Extensions;

namespace Permission.Application.Permission.Get;

internal sealed class GetPermissionQueryHandler(IWrapperRepository _uow, IEventBus eventBus)
    : IQueryHandler<GetPermissionQuery, List<PermissionResponse>>
{
    public async Task<Result<List<PermissionResponse>>> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _uow.Permission.GetAll()
                                               .Select(permission => new PermissionResponse
                                               {
                                                   EmployeeForename = permission.EmployeeForename,
                                                   EmployeeSurname = permission.EmployeeSurname,
                                                   Id = permission.Id,
                                                   PermissionDate = permission.PermissionDate,
                                                   PermissionType = ((PermissionTypes)permission.PermissionTypeId).ToDescription()
                                               })
                                               .ToListAsync(cancellationToken);

        if (permissions != null && permissions.Any())
        {
            foreach (var permission in permissions)
            {
                Log.Information("Get-Permission: {@Permission}", permission);
            }
        }

        await eventBus.PublishAsync(new OperationProducer(Guid.NewGuid(), Operations.Get.ToString()));

        return permissions;
    }
}