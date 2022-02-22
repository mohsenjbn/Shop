
using _0_Framework.Application;
using _01_framework.Application;
using Sh.Domain.ProductCategoryAgg;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploder _fileUploder;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductApplication(IProductRepository productRepository, IFileUploder fileUploder, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploder = fileUploder;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation=new OperationResult();
            if (_productRepository.IsExist(x => x.Name == command.Name))
                return operation.Failed(ResultMessage.IsDoblicated);
            
            var Slug=command.Slug.Slugify();
            var slugCategory = _productCategoryRepository.GetSlugPrudyctAndCategory(command.ProductCatagoryId);
            var path = $"{slugCategory}/{command.Slug}";
            var picturename = _fileUploder.Upload(command.Picture,path);
            var product = new Product(command.Name, command.Code,
                 command.ShortDescribtion, command.Describtion,
                picturename, command.PictureAlt, command.PictureTitle,
                command.MetaDescribtion, command.keyWords, Slug, command.ProductCatagoryId);

            _productRepository.Create(product);
            _productRepository.Savechanges();
            return operation.IsSucssed();


        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductAndCAtegoryById(command.Id);

            if(product == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_productRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            var slug = command.Slug.Slugify();
            var path = $"{product.ProductCategory.Slug}/{command.Slug}";
            var picturename = _fileUploder.Upload(command.Picture, path);
            product.Edit(command.Name, command.Code,
                 command.ShortDescribtion, command.Describtion,
                picturename, command.PictureAlt, command.PictureTitle,
                command.MetaDescribtion, command.keyWords, slug, command.ProductCatagoryId);
            _productRepository.Savechanges();
            return operation.IsSucssed();
        }

        public List<ProductViewModel> GetAll(SearchModelProduct search)
        {
            return _productRepository.GetAll(search);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public EditProduct GetDetails(long id)
        {
          return _productRepository.GetDetail(id);
        }

    
     
       

    }
}
