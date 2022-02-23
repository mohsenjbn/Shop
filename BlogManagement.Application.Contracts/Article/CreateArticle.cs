using _01_framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescribtion { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Describtion { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public IFormFile picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string pictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PublishDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string MetaDescribtion { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string KeyWords { get; set; }

        public string? CanonicalAddress { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
    }
}
