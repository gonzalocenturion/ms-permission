﻿namespace Permission.Domain.Entities;

public class PermissionType
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<EmployeePermission> Permissions { get; set; }
}