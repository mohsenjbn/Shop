using _01_framework.Domain;

namespace ShopManagement.Domain.OrderAgg;

public class OrderItem:EntityBase
{
    public long ProductId { get;private set; }
    public int DisCountRate { get; private set; }
    public double UnitPrice { get; private set; }
    public int Count { get; private set; }
    public long OrderId { get; private set; }
    public Order Order { get; set; }

    public OrderItem(long productId, int disCountRate, double unitPrice, int count)
    {
        ProductId = productId;
        DisCountRate = disCountRate;
        UnitPrice = unitPrice;
        Count = count;
    }
}