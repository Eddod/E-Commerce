using MediatR;

namespace Application.Orders;

public sealed record CreateOrdersCommand(Guid CusomerId) : IRequest;

