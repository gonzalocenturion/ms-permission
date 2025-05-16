using Permission.Domain.Repository;
using Permission.Infrastructure.Database;

namespace Permission.Infrastructure.Repository;
public class WrapperRepository(PermissionDbContext dbContext, IPermissionRepository permissionRepository) : IWrapperRepository
{
    private readonly PermissionDbContext _dbContext = dbContext;
    private readonly IPermissionRepository _permissionRepository = permissionRepository;

    public IPermissionRepository Permission => _permissionRepository ?? new PermissionRepository(_dbContext);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();    
}