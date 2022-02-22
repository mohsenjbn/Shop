using _0_Framework.Application;
using _01_ShopQuery.Contracts.Product;
using _01_ShopQuery.Contracts.ProductCategory;
using DiscontManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastracture.EfCore;
using System;

namespace _01_ShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discontContext;

        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _inventoryContext = inventoryContext;
            _discontContext = discountContext;
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetAllCategories()
        {

            return _shopContext.productCategories.Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug,


            }).OrderByDescending(p => p.Id).Take(3).ToList();
        }

        public List<ProductCategoryQueryModel> GetAllCategoryWithProducts()
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice }).ToList();
            var Discount = _discontContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();
            var result = _shopContext.productCategories.
                Include(p => p.Products)
                .ThenInclude(p => p.ProductCategory)
                .Select(p => new ProductCategoryQueryModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Products = MapProducts(p.Products)

                }).ToList();

            foreach (var category in result)
            {
                foreach (var item in category.Products)
                {
                    var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == item.Id);
                    if (inventory != null)
                    {
                        var price = inventory.UnitPrice;
                        item.UnitPrice = price.ToMoney();

                        var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == item.Id);
                        if (ProductDiscount != null)
                        {
                            var DiscontRate = ProductDiscount.DiscountRate;
                            item.DiscountRate = DiscontRate;
                            item.Discount = DiscontRate > 0;
                            var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                            item.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                        }
                    }




                }
            }

            return result;
        }

        private static List<ProductQueryViewModel> MapProducts(List<Product> products)
        {


            var result = new List<ProductQueryViewModel>();

            foreach (var product in products)
            {
                var Item = new ProductQueryViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.ProductCategory.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,
                    



                };
                result.Add(Item);


            }
            return result;
        }

        public ProductCategoryQueryModel GetProductCategoryandProductsBy(string value)
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice }).ToList();
            var Discount = _discontContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();

            var result = _shopContext.productCategories.
               Include(p => p.Products)
               .ThenInclude(p => p.ProductCategory)
               .Select(p => new ProductCategoryQueryModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Products = MapProducts(p.Products),
                   Slug=p.Slug

               }).FirstOrDefault(p=>p.Slug==value);

            foreach (var item in result.Products)
            {

                var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == item.Id);
                if (inventory != null)
                {
                    var price = inventory.UnitPrice;
                    item.UnitPrice = price.ToMoney();

                    var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == item.Id);
                    if (ProductDiscount != null)
                    {
                        var DiscontRate = ProductDiscount.DiscountRate;
                        item.DiscountRate = DiscontRate;
                        item.EndDateDiscount = ProductDiscount.EndDate.ToDiscountFormat();
                        item.Discount = DiscontRate > 0;
                        var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                        item.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                    }
                }





            }

            return result;
        }
    }
}
