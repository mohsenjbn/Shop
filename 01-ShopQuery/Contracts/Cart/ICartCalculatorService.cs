using _01_framework.Application;
using AccountManagement.Configuration;
using DiscontManagement.Infrastracture.EfCore;
using ShopManagement.Application.Contracts.Product;


namespace _01_ShopQuery.Contracts.Cart
{
    public interface ICartCalculatorService
    {
        ShopManagement.Application.Contracts.Product.Cart ComputeCart(List<CartItem> cartItems);
    }

    public class CartCalculatorService : ICartCalculatorService
    {
        private readonly IAuthHelper _authHelper;
        private readonly DiscountContext _discountContext;

        public CartCalculatorService(IAuthHelper authHelper, DiscountContext discountContext)
        {
            _authHelper = authHelper;
            _discountContext = discountContext;
        }

        public ShopManagement.Application.Contracts.Product.Cart ComputeCart(List<CartItem> cartItems)
        {
            var Cart = new ShopManagement.Application.Contracts.Product.Cart();

            var ColleagueDiscounts = _discountContext.ColleagueDiscounts.Where(p => !p.IsRemove)
                .Select(p => new { p.ProductId, p.DiscoiuntRate });

            var CustomerDiscounts = _discountContext.CustomerDiscounts
                .Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(p => new { p.ProductId, p.DiscountRate });

            var CurrentRoleUser = _authHelper.GetCurrentRoleId();

            foreach (var item in cartItems)
            {
                if (CurrentRoleUser == Roles.ColleagueUser)
                {
                    var itemDiscount = ColleagueDiscounts.FirstOrDefault(p => p.ProductId == item.Id);
                    if (itemDiscount != null)
                    {
                        item.DiscountRate = itemDiscount.DiscoiuntRate;

                    }
                    else
                    {
                        var itemCustomerDiscount = CustomerDiscounts.FirstOrDefault(p => p.ProductId == item.Id);
                        if (itemCustomerDiscount != null)
                            item.DiscountRate = itemCustomerDiscount.DiscountRate;
                    }
                }
                else
                {
                    var itemDiscount = CustomerDiscounts.FirstOrDefault(p => p.ProductId == item.Id);
                    if (itemDiscount != null)
                        item.DiscountRate = itemDiscount.DiscountRate;
                }

                item.TotalDiscount = ((item.ToTalPrice * item.DiscountRate) / 100);
                item.AmountPayable = item.ToTalPrice - item.TotalDiscount;
                Cart.Add(item);
            }
            return Cart;
        }
    }
}
