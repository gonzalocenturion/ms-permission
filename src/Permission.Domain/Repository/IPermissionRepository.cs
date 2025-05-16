using Permission.Domain.Entities;

namespace Permission.Domain.Repository;

public interface IPermissionRepository
{
    Task<EmployeePermission?> GetByIdAsync(int id);
    IQueryable<EmployeePermission> GetAll();
    Task AddAsync(EmployeePermission Permission);
    void Update(EmployeePermission Permission);
    void Delete(EmployeePermission Permission);
}