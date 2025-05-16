using Permission.Application.Abstraction.Messaging;
using Permission.Domain.Repository;
using SharedKernel;

namespace Permission.Application.Permission.Update;

internal sealed class ModifyPermissionCommandHandler(IWrapperRepository _wrapperRepository) 
    : ICommandHandler<ModifyPermissionCommand>
{
    public Task<Result> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}