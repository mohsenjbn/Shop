namespace ShopManagement.Application.Contracts.Product
{
    public class CartItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }
        public bool IsInStock { get; set; }
        public int DiscountRate { get; set; }
        public double ToTalPrice { get; set; }
        public double TotalDiscount { get; set; }
        public double AmountPayable { get; set; }


    }
}
