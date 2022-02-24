using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ShopQuery.Contracts.ArticleCategory
{
    public interface  IArticlecategoryQuery
    {
        ArticleCategoryQueryModel GetArticlesBy(string slug); 
        List<ArticleCategoryQueryModel> GetAll();
    }
}
