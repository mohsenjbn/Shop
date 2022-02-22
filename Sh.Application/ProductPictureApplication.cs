using _01_framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploder _fileUploder;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploder fileUploder)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploder = fileUploder;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var Operation=new OperationResult();
            //if (_productPictureRepository.IsExist(p => p.Picture == command.Picture))
            //    return Operation.Failed(ResultMessage.IsDoblicated);
            var ProductAndCategory = _productRepository.GetProductAndCAtegoryById(command.ProductId);
            var path = $"{ProductAndCategory.Slug}/{ProductAndCategory.ProductCategory.Slug}";
            var picturename=_fileUploder.Upload(command.Picture, path);
            var ProductPicture=new ProductPicture(picturename,command.
                PictureTitle,command.PictureAlt,command.ProductId);

            _productPictureRepository.Create(ProductPicture);
            _productPictureRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var Operation= new OperationResult();

            var ProductPicture = _productPictureRepository.GetProducPictireAndCategory(command.Id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            //if (_productPictureRepository.IsExist(p => p.Picture == command.Picture && p.ProductId != command.ProductId))
            //    return Operation.Failed(ResultMessage.IsDoblicated);
            var path = $"{ProductPicture.product.Slug}/{ProductPicture.product.ProductCategory.Slug}";
            var picturename = _fileUploder.Upload(command.Picture, path);
            ProductPicture.Edit(picturename, command.
                PictureTitle, command.PictureAlt, command.ProductId);
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public List<ProductPictureViewModel> GetAll(SearchProductPicture search)
        {
            return _productPictureRepository.GetAll(search);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetals(id);
        }

        public OperationResult IsRemove(long id)
        {
            var Operation = new OperationResult();

            var ProductPicture = _productPictureRepository.GetBy(id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);



            ProductPicture.Remove();
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();

            var ProductPicture = _productPictureRepository.GetBy(id);

            if (ProductPicture == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);



            ProductPicture.Restore();
            _productPictureRepository.Savechanges();

            return Operation.IsSucssed();
        }
    }
}
