using Microsoft.EntityFrameworkCore;
using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Enums;
using Permission.Domain.Repository;
using Serilog;
using SharedKernel;
using SharedKernel.Extensions;
using System.Security;

namespace Permission.Application.Permission.Get;

internal sealed class GetPermissionQueryHandler(IWrapperRepository _uow)
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
                Log.Information("PermissionRecord: {@Permission}", permission);
            }
        }

        return permissions;
    }
}