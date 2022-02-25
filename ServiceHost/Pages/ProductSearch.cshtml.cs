using _01_ShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Pages;

public class ProductSearch : PageModel
{
    public List<ProductQueryViewModel> Products { get; set; }
    public string Value { get; set; }
    private readonly IProductQuery _productQuery;

    public ProductSearch(IProductQuery productQuery)
    {
        _productQuery = productQuery;
    }

    public void OnGet(string value)
    {
        Products = _productQuery.Search(value);
        Value = value;

    }
}
