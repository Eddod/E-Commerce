using Domain.Entities.Customers;
using Domain.Entities.Products;

namespace Domain.Entities.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private Order()
    {

    }
    public OrderId Id { get; private set; }

    public CustomerId CustomerId { get; private set; }

    public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

    public OrderStatus OrderStatus { get; private set; }

    public static Order Create(CustomerId customerId)
    {
        var order = new Order()
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
            OrderStatus = OrderStatus.Pending
        };
        return order;
    }
    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem
            (new LineItemId(Guid.NewGuid()),
            Id,
            productId,
            price);
        _lineItems.Add(lineItem);
    }
}
public enum OrderStatus
{
    Pending = 0,
    Failed = 1,
    Submitted = 2
}