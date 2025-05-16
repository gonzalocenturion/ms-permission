using Permission.Application.Abstraction.Messaging;

namespace Permission.Application.Permission.Get;

public sealed record GetPermissionQuery : IQuery<List<PermissionResponse>>;