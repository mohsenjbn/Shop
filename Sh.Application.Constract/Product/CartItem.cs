namespace ShopManagement.Application.Contracts.Product
{
    public class CartItem
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }
        public double ToTalPrice { get; set; }

       
    }
}
