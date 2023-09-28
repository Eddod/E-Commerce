using MediatR;

namespace Application.Orders.Create;

public sealed record CreateOrdersCommand(Guid CusomerId) : IRequest;

