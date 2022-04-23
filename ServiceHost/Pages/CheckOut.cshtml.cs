
using _01_framework.Application;
using _01_framework.Application.Zarinpal;
using _01_ShopQuery.Contracts.Cart;
using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ZarinPal.Class;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        public Cart Cart;
        private readonly IAuthHelper _authHelper;
        private readonly ICartService _cartService;
        private readonly IZarinpalFactory _zarinpalFactory;
        private readonly IOrderApplication _orderApplication;
        private readonly ICartCalculatorService _cartCalculatorService;

        public CheckOutModel(ICartCalculatorService cartCalculatorService, ICartService service, IOrderApplication orderApplication, IZarinpalFactory zarinpalFactory
        , IAuthHelper authHelper)
        {
            Cart = new Cart();
            _cartCalculatorService = cartCalculatorService;
            _orderApplication = orderApplication;
            _zarinpalFactory = zarinpalFactory;
            _authHelper = authHelper;
            _cartService = service;

        }


        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var CartItems = Request.Cookies["cart-items"];
            var Items = serializer.Deserialize<List<CartItem>>(CartItems);

            foreach (var item in Items)
            {
                item.ToTalPrice = item.UnitPrice * item.Count;
            }

            Cart = _cartCalculatorService.ComputeCart(Items);

            _cartService.Set(Cart);

        }

        public IActionResult OnPostPay(int paymentMethod)
        {
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);
            if (cart.PaymentMethod == 1)
            {
                var orderId = _orderApplication.PlaceOrder(cart);
                var currentAccount = _authHelper.GetCurrentUserInfo();
                var response = _zarinpalFactory.CreatePayment(currentAccount.PhoneNumber, "", currentAccount.Name, cart.AmountPayable.ToString(), orderId);

                return Redirect($"https://{response.Mode}.zarinpal.com/pg/StartPay/{response.Authority}");
            }

            var result = new PaymentResult();
            result.Success("سفارش شما در اسرع وقت پردازش و مبلغ سفارش از طریق پست دریافت می گردد", "");
            Response.Cookies.Delete("cart-items");
            _orderApplication.PlaceOrder(cart);
            return RedirectToPage("/PaymentResult", result);




        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status, [FromQuery] long orderId)
        {
            var amount = _orderApplication.GetAmountBy(orderId);
            var response = _zarinpalFactory.CreateVerificationRequest(authority, amount.ToString());

            var result = new PaymentResult();
            if (status == "OK" && response.Status >= 100)
            {
                var issueTrakingnNo = _orderApplication.PaymentSucceeded(orderId, response.RefId);
                Response.Cookies.Delete("cart-items");
                result = result.Success("پرداخت با موفقیت انجام شد سفارش شما در اسرع وقت ارسال می شود ",
                    issueTrakingnNo);

                return RedirectToPage("/PaymentResult", result);
            }
            else
            {
                result = result.Faild("پرداخت ناموفق بود ،در صورت کسر وجه تا 72 ساعت اینده به حساب شما باز می گردد");
                return RedirectToPage("/PaymentResult", result);

            }
        }
    }
}
