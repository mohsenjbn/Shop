using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get;  set; }
        public string Slug { get;  set; }
        public string ShortDescribtion { get;  set; }
        public string Describtion { get;  set; }
        public IFormFile picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string pictureTitle { get;  set; }
        public string PublishDate { get;  set; }
        public string MetaDescribtion { get;  set; }
        public string KeyWords { get;  set; }
        public string CanonicalAddress { get;  set; }
        public long CategoryId { get;  set; }
    }
}
