using MediatR;

namespace RMP.Host.Abstarctions.CQRS;

public interface ICommand : ICommand<Unit>
{

}
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}