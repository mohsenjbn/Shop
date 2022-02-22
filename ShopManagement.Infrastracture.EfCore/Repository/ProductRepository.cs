using _0_Framework.Application;
using _01_framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductViewModel> GetAll(SearchModelProduct search)
        {
            var query = _context.Products.Include(p => p.ProductCategory).Select(p => new ProductViewModel()
            {
                Name=p.Name,
                CategoryName=p.ProductCategory.Name,
                code=p.Code,
                CreationDate=p.CreationDate.ToFarsi(), 
                Id=p.Id,
                Picture=p.Picture,
                CategoryId=p.ProductCategory.Id
                

            }).ToList();

            if (!string.IsNullOrWhiteSpace(search.Name))
                query=query.Where(p => p.Name.Contains(search.Name)).ToList();

            if(!string.IsNullOrWhiteSpace(search.Code))
                query = query.Where(p => p.code.Contains(search.Code)).ToList();

            if(search.CategoryId != 0)
                query = query.Where(p=>p.CategoryId==search.CategoryId).ToList();

            return query.OrderByDescending(p => p.Id).ToList();


        }

        public List<ProductViewModel> GetAllProducts()
        {
            return _context.Products.Select(p => new ProductViewModel
            {
                Id=p.Id,
                Name=p.Name

            }).ToList();
        }

        public EditProduct GetDetail(long id)
        {
            return _context.Products.Select(p => new EditProduct()
            {
                Code = p.Code,
                Id = p.Id,
                Describtion = p.Describtion,
                keyWords = p.keyWords,
                MetaDescribtion = p.MetaDescribtion,
                Name = p.Name,
                //Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                ProductCatagoryId = p.ProductCatagoryId,
                ShortDescribtion = p.ShortDescribtion,
                Slug = p.Slug,
            }).FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductAndCAtegoryById(long id)
        {
            return _context.Products.Include(p => p.ProductCategory).FirstOrDefault(p => p.Id == id);
        }
    }
}
