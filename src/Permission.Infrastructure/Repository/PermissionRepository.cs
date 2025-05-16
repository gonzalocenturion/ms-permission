using Microsoft.EntityFrameworkCore;
using Permission.Domain.Entities;
using Permission.Domain.Repository;
using Permission.Infrastructure.Database;

namespace Permission.Infrastructure.Repository;

public class PermissionRepository : IPermissionRepository
{
    private readonly PermissionDbContext _dbContext;

    public PermissionRepository(PermissionDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(EmployeePermission permission) => await _dbContext.Permission.AddAsync(permission);

    public void Delete(EmployeePermission permission) => _dbContext.Permission.Remove(permission);

    public IQueryable<EmployeePermission> GetAll() => _dbContext.Permission.AsNoTracking();

    public async Task<EmployeePermission?> GetByIdAsync(Guid id) => await _dbContext.Permission.FindAsync(id);

    public void Update(EmployeePermission permission) => _dbContext.Permission.Update(permission);
}