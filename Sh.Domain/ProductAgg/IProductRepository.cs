
using _01_framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long,Product>
    {
       Product GetProductAndCAtegoryById(long id);
        List<ProductViewModel> GetAll(SearchModelProduct search);
        EditProduct GetDetail(long id);
        List<ProductViewModel> GetAllProducts();

    }
}
