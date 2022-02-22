using _01_framework.Domain;
using ShopiManagement.Application.Contracts.ProductCategory;

using System.Linq.Expressions;


namespace Sh.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        string GetSlugPrudyctAndCategory(long id);
        List<ProductCategoryViewModel> Categories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchmodel);
        EditProductCategory GetDatail(long id);
    }
}
