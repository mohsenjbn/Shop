﻿using _0_Framework.Application;
using _01_ShopQuery.Contracts.Product;
using CommantManagement.Infrastracture.EfCore;
using DiscontManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastracture.EfCore;

namespace _01_ShopQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext shopContext, DiscountContext discountContext, InventoryContext inventoryContext,CommentContext commentContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
            _commentContext = commentContext;
        }

        public ProductQueryViewModel GetProducutBy(string slug)
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice, p.Instock }).ToList();
            var Discount = _discountContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();
            

            var product = _shopContext.Products.Include(p => p.ProductCategory).Include(p => p.ProductPictures).Select(p => new ProductQueryViewModel
            {
                Id = p.Id,
                Category = p.ProductCategory.Name,
                Name = p.Name,
                Describtion = p.Describtion,
                KeyWords = p.keyWords,
                MetaDescribtion = p.MetaDescribtion,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                ProductCategoryId = p.ProductCategory.Id,
                ShortDescribtion = p.ShortDescribtion,
                Slug = p.Slug,
                ProductCategorySlug = p.ProductCategory.Slug,
                Code = p.Code,
                ProducPictures = MapProductPictures(p.ProductPictures),
               

            }).FirstOrDefault(p => p.Slug == slug);

            if (product == null)
                return new ProductQueryViewModel();

            var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == product.Id);
            if (inventory != null)
            {
                var price = inventory.UnitPrice;
                
                product.UnitPrice = price.ToMoney();
                product.DoublePrice=price;
                if (inventory.Instock)
                {
                    product.IsInStock = true;
                }

                var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == product.Id);
                if (ProductDiscount != null)
                {
                    var DiscontRate = ProductDiscount.DiscountRate;
                    product.DiscountRate = DiscontRate;
                    product.Discount = DiscontRate > 0;
                    product.EndDateDiscount = ProductDiscount.EndDate.ToDiscountFormat();
                    var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                    product.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                }

            }


            var Comment = _commentContext.Comments.Where(p=>p.Confirm && !p.Cancel).Where(p => p.OwnerRecordId == product.Id).ToList();
            product.Comment = Comment.Select(p => new Contracts.Comment.CommentQyeryModel
            {
                Id = p.Id,
                Message=p.Message,
                Name=p.Name,
                OwnerRecordId=p.OwnerRecordId,
               CreationDate=p.CreationDate.ToFarsi()
                
            }).ToList();

            return product;
        }

        private static List<ProducPictureQueryModel> MapProductPictures(List<ProductPicture> productPictures)
        {
            return productPictures.Select(p => new ProducPictureQueryModel
            {
                Id = p.Id,
                IsRemove = p.IsDeleted,
                Picture = p.Picture,
                pictureAlt = p.PictureAlt,
                picturetitle = p.PictureTitle,
                ProductId = p.ProductId
            }).Where(p => p.IsRemove == false).ToList();
        }

        public List<ProductQueryViewModel> LatestArrivals()
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice }).ToList();
            var Discount = _discountContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();
            var Products = _shopContext.Products.Include(p => p.ProductCategory).Select(p => new ProductQueryViewModel
            {
                Id = p.Id,
                Category = p.ProductCategory.Name,
                Name = p.Name,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                Slug = p.Slug,


            }).OrderByDescending(p => p.Id).Take(6).AsNoTracking().ToList(); ;

            foreach (var Product in Products)
            {
                var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == Product.Id);
                if (inventory != null)
                {
                    var price = inventory.UnitPrice;
                    Product.UnitPrice = price.ToMoney();

                    var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == Product.Id);
                    if (ProductDiscount != null)
                    {
                        var DiscontRate = ProductDiscount.DiscountRate;
                        Product.DiscountRate = DiscontRate;
                        Product.Discount = DiscontRate > 0;
                        var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                        Product.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                    }

                }

            }

            return Products;
        }

        public List<CartItem> CheckInStock(List<CartItem> cartItems)
        {
            var inventory = _inventoryContext.Inventory.ToList();

            foreach (var item in cartItems)
            {
                var ItemInventory = inventory.FirstOrDefault(p => p.ProductId == item.Id && p.Instock);
                if (ItemInventory !=null)
                {
                    item.IsInStock = ItemInventory.CurrentCountInventory() >= item.Count;
                }
                else
                {
                    item.IsInStock = false;
                }
            }

            return cartItems;
        }

        public List<ProductQueryViewModel> Search(string val)
        {
            var inventoryProduct = _inventoryContext.Inventory.Select(p => new { p.ProductId, p.UnitPrice }).ToList();
            var Discount = _discountContext.CustomerDiscounts.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate ,c.EndDate}).ToList();
            var Products = _shopContext.Products.Include(p => p.ProductCategory).Where(p => p.Name.Contains(val) || p.ShortDescribtion.Contains(val)).Select(p => new ProductQueryViewModel
            {
                Id = p.Id,
                Category = p.ProductCategory.Name,
                Name = p.Name,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                Slug = p.Slug,


            }).ToList();

            foreach (var Product in Products)
            {
                var inventory = inventoryProduct.FirstOrDefault(p => p.ProductId == Product.Id);
                if (inventory != null)
                {
                    var price = inventory.UnitPrice;
                    Product.UnitPrice = price.ToMoney();

                    var ProductDiscount = Discount.FirstOrDefault(p => p.ProductId == Product.Id);
                    if (ProductDiscount != null)
                    {
                        var DiscontRate = ProductDiscount.DiscountRate;
                        Product.DiscountRate = DiscontRate;
                        Product.Discount = DiscontRate > 0;
                        Product.EndDateDiscount = ProductDiscount.EndDate.ToDiscountFormat();
                        var PriceWithDiscount = Math.Round((price * DiscontRate) / 100);
                        Product.PriceWithDiscoint = (price - PriceWithDiscount).ToMoney();
                    }

                }

            }

            return Products;
        }
    }
}
