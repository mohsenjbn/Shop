
using _0_Framework.Application;
using _01_framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>,IProductPictureRepository
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductPictureViewModel> GetAll(SearchProductPicture search)
        {
            var query=_context.ProductPictures.Include(p=>p.product).Select(x=>new ProductPictureViewModel
            {
             Id=x.Id,
             CreationDate=x.CreationDate.ToFarsi(),
             IsRemove=x.IsDeleted,
             picture=x.Picture,
             ProductName=x.product.Name,
             ProductId=x.ProductId,

            }).ToList();

            if (search.ProdctId != 0)
                query = query.Where(x => x.ProductId == search.ProdctId).ToList();

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public EditProductPicture GetDetals(long id)
        {
            return _context.ProductPictures.Select(p=>new EditProductPicture
            {
                Id=p.Id,
                //Picture=p.Picture,
                IsDeleted=p.IsDeleted,
                PictureAlt=p.PictureAlt,
                PictureTitle=p.PictureTitle,
                ProductId=p.ProductId,

            }).FirstOrDefault(p=>p.Id == id);
        }

        public ProductPicture GetProducPictireAndCategory(long id)
        {
           return _context.ProductPictures.Include(p=>p.product).ThenInclude(p=>p.ProductCategory).FirstOrDefault(p=>p.Id==id);
        }
    }
}
