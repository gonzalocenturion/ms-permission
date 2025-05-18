using Permission.Domain.Enums;

namespace Permission.Domain.Events;
public sealed record OperationProducer(Guid Id, string OperationName);