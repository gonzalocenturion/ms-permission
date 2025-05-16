using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Application.Permission.Create;

public record CreatePermissionResponse
{
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }

    //Todo: refactorizarlo por enum
    public string PermissionType { get; set; }
}


