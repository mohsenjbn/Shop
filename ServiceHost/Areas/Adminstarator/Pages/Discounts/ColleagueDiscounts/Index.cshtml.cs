using DiscountManagement.Application.Contracts.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Adminstarator.Pages.Discounts.ColleagueDiscounts;

public class IndexModel : PageModel
{
    public List<ColleagueDiscountViewModel> ColleagueDisCounts { get; set; }
    public ColleagueDiscountSearch Search { get; set; }
    public SelectList Products;

    private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
    private readonly IProductApplication _productApplication;

    public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
    {
        _colleagueDiscountApplication = colleagueDiscountApplication;
        _productApplication = productApplication;
    }

    public void OnGet(ColleagueDiscountSearch Search)
    {
        ColleagueDisCounts = _colleagueDiscountApplication.GetAll(Search);
        Products = new SelectList(_productApplication.GetAllProducts(), "Id", "Name");
    }


    public IActionResult OnGetCreate()
    {
        var Define = new Define()
        {
            Products = _productApplication.GetAllProducts()
        };

        return Partial("./Create", Define);
    }

    public JsonResult OnPostCreate(Define command)
    {
        var result = _colleagueDiscountApplication.Define(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var CollegueDiscunts = _colleagueDiscountApplication.GetDetails(id);
        CollegueDiscunts.Products = _productApplication.GetAllProducts();
        return Partial("./Edit", CollegueDiscunts);
    }

    public JsonResult OnPostEdit(Edit command)
    {
        var result = _colleagueDiscountApplication.Edit(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetActive(long id)
    {
        var result=_colleagueDiscountApplication.Active(id);
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetRemove(long id)
    {
        var result = _colleagueDiscountApplication.Remove(id);
        return RedirectToPage("./Index");
    }
}
