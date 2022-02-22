using _01_framework.Application;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public interface  IInventoryApplication
    {
        OperationResult CreateInventory(CreateInventory command);
        OperationResult EditInventory(EditInventory command);
        OperationResult IncreaseInventory(IncreaseInventory command);
        OperationResult ReduceInventory(ReduceInventory command);
        OperationResult ReduceInventory(List<ReduceInventory> command);
        List<InventoryViewModel> GetAll(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetInventoryLogs(long InventoryId);
        EditInventory GetDetails(long Id);
    }
}
