using _01_framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        
        public IFormFile? Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public bool IsDeleted { get;  set; }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get;  set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
