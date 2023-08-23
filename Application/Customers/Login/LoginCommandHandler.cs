using Application.Abstractions.Messaging;
using Domain.Shared;
using MediatR;

namespace Application.Customers.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{

    Task<Result<string>> IRequestHandler<LoginCommand, Result<string>>.Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
