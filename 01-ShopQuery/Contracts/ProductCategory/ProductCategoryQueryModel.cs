﻿using _01_ShopQuery.Contracts.Product;

namespace _01_ShopQuery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string KeyWords { get; set; }
        public string MetaDescribtion { get; set; }

        public List<ProductQueryViewModel> Products { get; set; }
    }
}
