using _01_framework.Domain;
using Invertory.Application.Contracts.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface  IInventoryRepository:IRepository<long,Inventory>
    {
        Inventory Getfrom(long ProductId);
        List<InventoryViewModel> GetAll(InventorySeacrModel seacrhmodel);
        UpdateInventory GetDetails(long id);
        List<InventoryOperationViewModel> InventoryOperations(long InventoryId);

    }
}
