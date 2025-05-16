namespace Permission.Domain.Repository;

public interface IPermissionRepository
{
    Task<Entities.Permission?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Permission>> GetAllAsync();
    Task AddAsync(Entities.Permission Permission);
    void Update(Entities.Permission Permission);
    void Delete(Entities.Permission Permission);
}