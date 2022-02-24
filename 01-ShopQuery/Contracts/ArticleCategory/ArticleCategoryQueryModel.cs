using _01_ShopQuery.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ShopQuery.Contracts.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string pictureTitle { get;  set; }
        public string Describtion { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDescribtion { get;  set; }
        public string Slug { get;  set; }
        public int ArticlesCount { get; set; }
        public List<string> KeyWordsList { get; set; }
        public List<ArticleQueryModel> Articles { get; set; }
    }
}
