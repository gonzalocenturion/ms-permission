using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Enums;

namespace Permission.Application.Permission.Update;

public sealed record ModifyPermissionCommand(int id, string forename, string surname, PermissionTypes permissiontype) : ICommand;
