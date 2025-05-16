using MediatR;
using SharedKernel;

namespace Permission.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
