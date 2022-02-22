using DiscountManagement.Application.Contracts.ColleagueDiscount;
using Invertory.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Adminstarator.Pages.Inventory;

public class IndexModel : PageModel
{
    public List<InventoryViewModel> Inventory { get; set; }
    public InventorySeacrModel Search { get; set; }
    public SelectList Products;

    private readonly IInventoryApplication _inventoryApplication;
    private readonly IProductApplication _productApplication;

    public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
    {
        _inventoryApplication = inventoryApplication;
        _productApplication = productApplication;
    }

    public void OnGet(InventorySeacrModel Search)
    {
        Inventory = _inventoryApplication.GetAll(Search);
        Products = new SelectList(_productApplication.GetAllProducts(), "Id", "Name");
    }


    public IActionResult OnGetCreate()
    {
        var createInventory = new CreateInventory()
        {
            Products = _productApplication.GetAllProducts()
        };

        return Partial("./Create", createInventory);
    }

    public JsonResult OnPostCreate(CreateInventory command)
    {
        var result = _inventoryApplication.Create(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var Inventory = _inventoryApplication.GetDetails(id);
        Inventory.Products = _productApplication.GetAllProducts();
        return Partial("./Edit", Inventory);
    }

    public JsonResult OnPostEdit(UpdateInventory command)
    {
        var result = _inventoryApplication.Edit(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetIncrease(long id)
    {
        
        var command = new Increase()
        {
            InventoryId = id
        };
  
        return Partial("./Increase", command);
    }

    public JsonResult OnPostIncrease(Increase command)
    {
        var result = _inventoryApplication.Increase(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetReduce(long id)
    {

        var command = new Reduce()
        {
            InventoryId = id
        };

        return Partial("./Reduce", command);
    }

    public JsonResult OnPostReduce(Reduce command)
    {
        var result = _inventoryApplication.Reduce(command);
        return new JsonResult(result);
    }

    public  IActionResult OnGetInventoryOperations(long id)
    {
        var InventoryOperations=_inventoryApplication.InventoryOperations(id);
        return Partial("./InventoryOperations",InventoryOperations);
    }


}
