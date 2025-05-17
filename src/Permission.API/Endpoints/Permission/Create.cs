using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permission.API.Extensions;
using Permission.API.Infrastructure;
using Permission.Application.Permission.Create;
using Permission.Domain.Enums;
using SharedKernel;

namespace Permission.API.Endpoints.Permission;

public class Create : IEndpoint
{
    public sealed class RequestPermission
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
        app.MapPost("permission", async ([FromBody] RequestPermission request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreatePermissionCommand
            {
                EmployeeForename = request.EmployeeForename,
                EmployeeSurname = request.EmployeeSurname,
                PermissionType = request.PermissionType
            };

            Result<int> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags("permission")
        .WithSummary("Create a permission")
        .WithDescription("Create a permission.");
    }
}