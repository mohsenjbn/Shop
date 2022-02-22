namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string picture { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemove { get; set; }
        public string ProductName { get; set; }
        public long ProductId { get; set; }
    }
}
