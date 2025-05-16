using FluentValidation;
using Permission.Application.Extensions;

namespace Permission.Application.Permission.Update;

public class ModifyPermissionCommandValidator : AbstractValidator<ModifyPermissionCommand>
{
    public ModifyPermissionCommandValidator()
    {
        RuleFor(x => x.forename).NotNullOrWhiteSpace("EmployeeForename");
        RuleFor(x => x.surname).NotNullOrWhiteSpace("EmployeeSurname");
        RuleFor(x => x.permissiontype).MustBeDefinedEnum("PermissionType");
    }
}