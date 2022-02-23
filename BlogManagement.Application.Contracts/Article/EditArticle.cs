using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.Article
{
    public class EditArticle:CreateArticle
    {
        public long Id { get; set; }
        public IFormFile? pictureEdit { get; set; }


    }
}
