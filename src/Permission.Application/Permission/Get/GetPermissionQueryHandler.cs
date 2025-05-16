using Microsoft.EntityFrameworkCore;
using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Repository;
using SharedKernel;

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
                                                   PermissionType = "enum.todescription()--implementar"
                                               })
                                               .ToListAsync(cancellationToken);


        return permissions;
    }
}