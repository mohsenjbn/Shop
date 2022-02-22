using _0_Framework.Application;
using _01_framework.Infrastracture;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastracture.EfCore;

namespace DiscontManagement.Infrastracture.EfCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _Context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
        {
            _Context = context;
            _shopContext = shopContext;
        }

        public List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearch search)
        {
            var Products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();
            var query = _Context.ColleagueDiscounts.Select(c => new ColleagueDiscountViewModel
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                DiscountRate=c.DiscoiuntRate,
                IsRemove=c.IsRemove,
                ProductId=c.ProductId,
            });

            if(search.ProductId > 0)
                query=query.Where(p=>p.ProductId == search.ProductId);

            var discounts = query.OrderByDescending(p => p.Id).ToList();
            discounts.ForEach(p => p.ProductName = Products.FirstOrDefault(c => c.Id == p.ProductId)?.Name);
            return discounts;
        }

        public Edit GetDetails(long id)
        {
            return _Context.ColleagueDiscounts.Select(c => new Edit
            {
                DiscountRate=c.DiscoiuntRate,
                Id=c.Id,
                ProductId=c.ProductId,
                
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}
