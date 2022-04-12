using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> cartItems = new List<CartItem>();
        public void OnGet()
        {

            var serializer = new JavaScriptSerializer();
            var CartItems = Request.Cookies["cart-items"];
            cartItems = serializer.Deserialize<List<CartItem>>(CartItems);
            if (cartItems.Count == 0)
            {
                Response.Cookies.Delete("cart-items");

            }
            foreach (var item in cartItems)
            {
                item.ToTalPrice = item.UnitPrice * item.Count;
            }


        }

        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var cartItem = Request.Cookies["cart-items"];
            Response.Cookies.Delete("cart-items");
            var value = serializer.Deserialize<List<CartItem>>(cartItem);
            var itemToRemove = value.FirstOrDefault(p => p.Id == id);
            value.Remove(itemToRemove);
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(2),
                IsEssential = true,
                Path = "/",


            };
            Response.Cookies.Append("cart-items", serializer.Serialize(value), options);
            return RedirectToPage("./Cart");

        }
    }
}
