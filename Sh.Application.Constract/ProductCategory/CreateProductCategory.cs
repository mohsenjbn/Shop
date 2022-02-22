using Microsoft.AspNetCore.Http;
using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopiManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [FileExtentionAttr(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فایل نادرست است ")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "حجم فایل بیش تر از حد مجاز می باشد ")]
        public IFormFile Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Describtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescribtion { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
