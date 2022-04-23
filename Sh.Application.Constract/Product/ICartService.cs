namespace ShopManagement.Application.Contracts.Product
{
    public interface  ICartService
    {
        void Set(Cart cart);
        Cart Get();
    }

    public class CartService:ICartService
    {
        public Cart Cart { get; set; }
        public void Set(Cart cart)
        {
            Cart = cart;
        }

        public Cart Get()
        {
            return Cart;
        }
    }
}
