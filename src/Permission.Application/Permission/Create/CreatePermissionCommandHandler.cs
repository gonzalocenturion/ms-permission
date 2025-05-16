using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Entities;
using Permission.Domain.Repository;
using SharedKernel;

namespace Permission.Application.Permission.Create;

internal sealed class CreatePermissionCommandHandler(IWrapperRepository _uow) 
    : ICommandHandler<CreatePermissionCommand, int>
{
    public async Task<Result<int>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = new EmployeePermission
        {
            EmployeeForename = request.EmployeeForename,
            EmployeeSurname = request.EmployeeSurname,
            PermissionDate = DateTime.Now,
            PermissionTypeId = 1 //agregar string to enum 
        };


        await _uow.Permission.AddAsync(permission);

        await _uow.SaveChangesAsync();

       return permission.Id;
    }
}