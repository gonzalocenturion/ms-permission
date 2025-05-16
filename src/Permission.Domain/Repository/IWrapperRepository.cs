namespace Permission.Domain.Repository;

public interface IWrapperRepository
{
    IPermissionRepository Permission { get; }

    Task SaveChangesAsync();
}