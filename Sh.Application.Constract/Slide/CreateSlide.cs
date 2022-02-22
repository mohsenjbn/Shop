

using _01_framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        
        public IFormFile? Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Btntext { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { set; get; }
      

    }
}
