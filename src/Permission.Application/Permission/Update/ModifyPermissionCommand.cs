using Permission.Application.Abstraction.Messaging;

namespace Permission.Application.Permission.Update;

public sealed record ModifyPermissionCommand(int id, string forename, string surname, string permissiontype) : ICommand;
