using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permission.API.Extensions;
using Permission.API.Infrastructure;
using Permission.Application.Permission.Update;
using Permission.Domain.Enums;
using SharedKernel;

namespace Permission.API.Endpoints.Permission;

internal sealed class Update : IEndpoint
{
    public sealed class ModifyPermission
    {
        /// <summary>
        /// Employee Name
        /// </summary>
        public string EmployeeForename { get; set; }

        /// <summary>
        /// Employee Surname
        /// </summary>
        public string EmployeeSurname { get; set; }

        /// <summary>
        /// Allowed values: Vacation, SickLeave, PersonalLeave, BereavementLeave, JuryDuty, ParentalLeave, UnpaidLeave, RemoteWork, StudyLeave.
        /// </summary>
        public PermissionTypes PermissionType { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("permission/{id:int}", async (int id, [FromBody] ModifyPermission request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new ModifyPermissionCommand(id, request.EmployeeForename, request.EmployeeSurname, request.PermissionType);
            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags("permission")
        .WithSummary("Modifies an existing permission")
        .WithDescription("Modifies existing permission identified by its ID.")
        .WithOpenApi(op =>
        {
            op.Parameters[0].Description = "The ID of the permission to modify.";
            return op;
        });
    }
}