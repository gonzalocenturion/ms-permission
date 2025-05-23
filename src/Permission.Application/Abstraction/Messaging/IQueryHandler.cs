﻿using MediatR;
using SharedKernel;

namespace Permission.Application.Abstraction.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
