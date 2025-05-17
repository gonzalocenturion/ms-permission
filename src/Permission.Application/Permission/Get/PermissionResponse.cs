namespace Permission.Application.Permission.Get;

public record PermissionResponse
{
    public int Id { get; init; }
    public string EmployeeForename { get; init; }
    public string EmployeeSurname { get; init; }
    public string PermissionType { get; init; }
    public DateTime PermissionDate { get; init; }
}