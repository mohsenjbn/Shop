using _0_Framework.Application;
using _01_framework.Infrastracture;
using AccountManagement.Infrastracture.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using OrderItem = ShopManagement.Application.Contracts.Order.OrderItems;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class OrderRepository:RepositoryBase<long,Order>,IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;
        public OrderRepository(ShopContext context,AccountContext accountContext) : base(context)
        {
            _shopContext = context;
            _accountContext = accountContext;
        }

        public double GetAmountBy(long orderId)
        {
            var amounts = _shopContext.Orders.Select(p => new { p.Id, p.PayAmount }).ToList();
            return amounts.FirstOrDefault(p => p.Id == orderId)!.PayAmount;
        }

        public List<OrderViewModel> GetAllOrders(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts.Select(p => new { p.Id, p.FullName }).ToList();
            var query = _shopContext.Orders.Select(p => new OrderViewModel
            {
                Id = p.Id,
                IssueTrackingNo = p.IssueTrackingNo,
                IsCanceled = p.IsCanceled,
                IsPayed = p.IsPayed,
                RefId = p.RefId,
                AccountId = p.AccountId,
                CreationDate = p.CreationDate.ToFarsi(),
                DiscountAmount = p.DiscountAmount,
                PayAmount = p.PayAmount,
                TotalAmount=p.TotalAmount,
                PaymentMethod = p.PaymentMethod

            });

            query = query.Where(p => p.IsCanceled == searchModel.IsCanceled);

            if (searchModel.AccountId > 0)
                query = query.Where(p => p.AccountId == searchModel.AccountId);

            var order = query.OrderByDescending(p => p.Id).ToList();

            foreach (var item in order)
            {
                item.PaymentMethodName = PaymentMethod.GetBy(item.PaymentMethod).Name;
                item.AccountName = accounts.FirstOrDefault(p => p.Id == item.AccountId)?.FullName;
            }


            return order;

        }

        public List<OrderItems> GetItemsBy(long OrderId)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name });
            var order = _shopContext.Orders.FirstOrDefault(p => p.Id == OrderId);

            var items = order.Items.Select(x => new OrderItem
            {
                Id = x.Id,
                Count = x.Count,
                DisCountRate = x.DisCountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.ProductName = products.FirstOrDefault(p => p.Id == item.ProductId)?.Name;
            }

            return items;
        }
    }
}
