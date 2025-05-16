using Microsoft.EntityFrameworkCore;
using Permission.Domain.Repository;
using Permission.Infrastructure.Database;

namespace Permission.Infrastructure.Repository;

public class PermissionRepository : IPermissionRepository
{
    private readonly PermissionDbContext _dbContext;

    public PermissionRepository(PermissionDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(Domain.Entities.Permission permission) => await _dbContext.Permission.AddAsync(permission);

    public void Delete(Domain.Entities.Permission permission) => _dbContext.Permission.Remove(permission);

    public async Task<IEnumerable<Domain.Entities.Permission>> GetAllAsync() => await _dbContext.Permission.AsNoTracking().ToListAsync();

    public async Task<Domain.Entities.Permission?> GetByIdAsync(Guid id) => await _dbContext.Permission.FindAsync(id);

    public void Update(Domain.Entities.Permission permission) => _dbContext.Permission.Update(permission);
}