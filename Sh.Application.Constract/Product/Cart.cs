namespace ShopManagement.Application.Contracts.Product
{
    public class Cart
    {
        public double AmountPayable   { get; set; }
        public double FinalAmount { get; set; }
        public double AmountOfDiscount { get; set; }
        public int PaymentMethod { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems=new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            AmountPayable += cartItem.AmountPayable;
            FinalAmount += cartItem.ToTalPrice;
            AmountOfDiscount += cartItem.TotalDiscount;
        }

        public void SetPaymentMethod(int methodId)
        {
            PaymentMethod = methodId;
        }
    }
}
