using SharedKernel;

namespace Permission.Domain.Entities;
public static class PermissionError
{
    public static Error NotFound(int permissionId) => Error.NotFound(
       "Permission.NotFound",
       $"The employee permission with the Id = '{permissionId}' was not found");
}