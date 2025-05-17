using MediatR;
using Permission.API.Extensions;
using Permission.API.Infrastructure;
using Permission.Application.Permission.Get;
using SharedKernel;

namespace Permission.API.Endpoints.Permission;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("permission", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetPermissionQuery();

            Result<List<PermissionResponse>> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags("permission")
        .WithSummary("Get Permission List")
        .WithDescription("Get Permission List.");
    }
}
