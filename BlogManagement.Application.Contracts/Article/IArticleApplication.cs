﻿using _01_framework.Application;

namespace BlogManagement.Application.Contracts.Article
{
    public interface  IArticleApplication
    {
        OperationResult CreateArticle(CreateArticle command);
        OperationResult operationResult(EditArticle command);
        EditArticle GetDetails(long Id);
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);

    }
}
