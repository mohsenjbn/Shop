namespace ShopManagement.Application.Contracts.Order
{
    public class OrderItems
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int DisCountRate { get;  set; }
        public double UnitPrice { get;  set; }
        public int Count { get;  set; }
        public long OrderId { get;  set; }
    }
}
