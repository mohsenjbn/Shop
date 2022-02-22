
using _0_Framework.Application;
using _01_framework.Application;
using Sh.Domain.ProductCategoryAgg;
using ShopiManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploder _fileUploder;

       
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploder fileUploder)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploder = fileUploder;
        }
           
        public OperationResult Create(CreateProductCategory Command)
        {
            var Operation = new OperationResult();
            if (_productCategoryRepository.IsExist(p=>p.Name==Command.Name))
             return   Operation.Failed(ResultMessage.IsDoblicated);

            var Slug = Command.Slug.Slugify();
            var path = $"{Command.Slug}";
            var picture = _fileUploder.Upload(Command.Picture, path);
            var ProductCategory=new ProductCategory(Command.Name, picture, Command.Describtion,Command.PictureAlt,Command.PictureTitle,Slug
               ,Command.KeyWords,Command.MetaDescribtion);
            _productCategoryRepository.Create(ProductCategory);
            _productCategoryRepository.Savechanges();
           return Operation.IsSucssed();
        }

        public OperationResult Edit(EditProductCategory Command)
        {
            var Operation=new OperationResult();
            var ProductCategory=_productCategoryRepository.GetBy(Command.Id);

            if (ProductCategory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_productCategoryRepository.IsExist(p => p.Name == Command.Name && p.Id != Command.Id)) 
            return Operation.Failed(ResultMessage.IsDoblicated);

            var Slug = Command.Slug.Slugify();
            var path = $"{Command.Slug}";
            
            var picture = _fileUploder.Upload(Command.Picture, path);
            ProductCategory.Edit(Command.Name, picture, Command.Describtion, Command.PictureAlt, Command.PictureTitle,
                Slug, Command.KeyWords, Command.MetaDescribtion);

            _productCategoryRepository.Savechanges();
            return Operation.IsSucssed();

        }

        public List<ProductCategoryViewModel> GetAll(ProductCategorySearchModel command)
        {
            return _productCategoryRepository.Search(command);
        }

        public List<ProductCategoryViewModel> GetCategories()
        {
            return _productCategoryRepository.Categories();
        }

        public EditProductCategory GetDetail(long id)
        {
            return _productCategoryRepository.GetDatail(id);
        }
    }
}
