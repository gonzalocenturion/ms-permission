using FluentValidation;
using Permission.Application.Extensions;

namespace Permission.Application.Permission.Create;

public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(x => x.EmployeeForename).NotNullOrWhiteSpace("EmployeeForename");
        RuleFor(x => x.EmployeeSurname).NotNullOrWhiteSpace("EmployeeSurname");
        RuleFor(x => x.PermissionType).MustBeDefinedEnum("PermissionType");
    }
}