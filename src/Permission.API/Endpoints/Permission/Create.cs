using MediatR;
using Permission.API.Extensions;
using Permission.API.Infrastructure;
using Permission.Application.Permission.Create;
using Permission.Domain.Enums;
using SharedKernel;

namespace Permission.API.Endpoints.Permission;

public class Create : IEndpoint
{
    public sealed class Request
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public PermissionTypes PermissionType { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("permission", async (Request request, ISender sender, CancellationToken cancellationToken) =>
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
        .WithTags("permission");
    }
}