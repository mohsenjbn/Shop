using _01_ShopQuery.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Persentation.Api.Controller
{
    [Route("api/[Controller]")]
    [ApiController]

    
    public class InventoryController:ControllerBase
    {
        private readonly IInventoryQuery _inventoryQuery;

        public InventoryController(IInventoryQuery inventoryQuery)
        {
            _inventoryQuery = inventoryQuery;
        }

        [HttpPost]
        public StockStatus GetStatus(CheckStatus command)
        {
            return _inventoryQuery.IsInStock(command);
        }
    }
}
