using _01_framework.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication

    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;
        private readonly IShopInventoryAcl _inventoryAcl;

        public OrderApplication(IAuthHelper authHelper, IConfiguration configuration, IOrderRepository orderRepository, IShopInventoryAcl shopInventoryAcl)
        {
            _authHelper = authHelper;
            _configuration = configuration;
            _orderRepository = orderRepository;
            _inventoryAcl = shopInventoryAcl;
        }

        public long PlaceOrder(Cart cart)
        {
            var CurrentAccountId = _authHelper.GetCurrentAccountId();
            var Oreder = new Order(CurrentAccountId, cart.PaymentMethod, cart.AmountPayable, cart.FinalAmount, cart.AmountOfDiscount);

            foreach (var items in cart.CartItems)
            {
                var item = new OrderItem(items.Id, items.DiscountRate, items.UnitPrice, items.Count);
                Oreder.Add(item);
            }
            _orderRepository.Create(Oreder);
            _orderRepository.Savechanges();
            return Oreder.Id;
        }

        public string PaymentSucceeded(long orderId, long refId)
        {
            var order = _orderRepository.GetBy(orderId);
            var IssueTrackingNo = CodeGenerator.Generate("A");
            order.SetIssueTrackingNo(IssueTrackingNo);
            order.IsSuccessPayment(refId);
            if (_inventoryAcl.ReduceInventory(order.Items) == true)
            {
                _orderRepository.Savechanges();
                return order.IssueTrackingNo;
            }

            return "";
        }

        public double GetAmountBy(long orderId)
        {
            return _orderRepository.GetAmountBy(orderId);
        }

        public List<OrderViewModel> GetAllOrders(OrderSearchModel searchModel)
        {
            return _orderRepository.GetAllOrders(searchModel);
        }

        public List<OrderItems> GetItemsBy(long OrderId)
        {
            return _orderRepository.GetItemsBy(OrderId);
        }

        public void IsCanceled(long Id)
        {
            var order = _orderRepository.GetBy(Id);
            if (order != null)
            {
                order.Cancel();
                _orderRepository.Savechanges();

            }


        }
    }
}
