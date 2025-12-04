using MediatR;

namespace Athr.Application.Abstractions.Messaging;

public interface IBaseCommand
{
}

public interface ICommand : IRequest, IBaseCommand
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>, IBaseCommand
{
}
