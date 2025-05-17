using MediatR;
using Permission.API.Extensions;
using Permission.API.Infrastructure;
using Permission.Application.Permission.Update;
using Permission.Domain.Enums;
using SharedKernel;

namespace Permission.API.Endpoints.Permission;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public PermissionTypes PermissionType { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("permission/{id:int}", async (int id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command =  new ModifyPermissionCommand(id, request.EmployeeForename, request.EmployeeSurname, request.PermissionType);
            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags("permission");
    }
}