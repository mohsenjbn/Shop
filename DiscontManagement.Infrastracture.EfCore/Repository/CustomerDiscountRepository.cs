using _0_Framework.Application;
using _01_framework.Infrastracture;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastracture.EfCore;

namespace DiscontManagement.Infrastracture.EfCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepositpry
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
        {
            _context=context;
            _shopContext=shopContext;
        }

        public List<CustomerDiscountViewModel> GetAll(SearchCustomerDiscunt searchmodel)
        {
            var Products = _shopContext.Products.Select(c => new { c.Id, c.Name }).ToList();
            var query=_context.CustomerDiscounts.Select(x=> new CustomerDiscountViewModel
            {
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi(),
                StartDateGr=x.StartDate,
                EndDateGr=x.EndDate,
                Id=x.Id,
               

            });

            if(searchmodel.ProductId > 0)
            {
                query= query.Where(p=>p.ProductId == searchmodel.ProductId);
            }

            if(!string.IsNullOrWhiteSpace(searchmodel.StartDate))
            {
                query = query.Where(p => p.StartDateGr > searchmodel.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchmodel.EndDate))
            {
                query = query.Where(p => p.EndDateGr < searchmodel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount =>
            discount.ProductName = Products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;

        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(c => new EditCustomerDiscount
            {

                Id = id,
                DiscountRate = c.DiscountRate,
                StartDate = c.StartDate.ToString(),
                EndDate=c.EndDate.ToString(),
                ProductId = c.ProductId,
                Reason = c.Reason,
                



            }).FirstOrDefault(x => x.Id==id);
        }
    }
}
