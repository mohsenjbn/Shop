﻿using _01_framework.Infrastracture;
using _01_ShopQuery.Contracts.Cart;
using _01_ShopQuery.Contracts.Product;
using _01_ShopQuery.Contracts.ProductCategory;
using _01_ShopQuery.Contracts.Slide;
using _01_ShopQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sh.Domain.ProductCategoryAgg;
using ShopiManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastracture.EfCore;
using ShopManagement.Infrastracture.EfCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string ConnecttionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository,ProductRepository>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            service.AddTransient<ICartCalculatorService, CartCalculatorService>();
            service.AddTransient<IOrderApplication, OrderApplication>();
            service.AddTransient<IOrderRepository, OrderRepository>();



            service.AddTransient<ICartCalculatorService, CartCalculatorService>();
            service.AddSingleton<ICartService, CartService>();


            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            service.AddTransient<IProductQuery, ProductQuery>();



            service.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnecttionString));


        }
    }
}