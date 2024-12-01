using MediatR;

namespace RMP.Host.Abstarctions.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}