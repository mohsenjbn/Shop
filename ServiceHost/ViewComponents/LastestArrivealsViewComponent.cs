using _01_ShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LastestArrivealsViewComponent:ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LastestArrivealsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var LastestProduct = _productQuery.LatestArrivals();
            return View(LastestProduct);
        }
    }
}
