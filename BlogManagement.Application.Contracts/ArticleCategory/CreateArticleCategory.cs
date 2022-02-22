using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        public string Name { get; set; }
        public int ShowOrder { get; set; }
        public IFormFile picture { get; set; }
        public string PictureAlt { get; set; }
        public string pictureTitle { get; set; }
        public string Describtion { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescribtion { get; set; }
        public string Slug { get; set; }
        public string? CanonicalAddress { get; set; }
    }
}
