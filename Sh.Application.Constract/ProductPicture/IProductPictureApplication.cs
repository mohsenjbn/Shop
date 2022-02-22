using _01_framework.Application;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult IsRemove(long id);
        OperationResult Restore(long id);
        List<ProductPictureViewModel> GetAll(SearchProductPicture search);
        EditProductPicture GetDetails(long id);
    }
}
