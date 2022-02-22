namespace InventoryManagement.Application.Contracts.Inventory
{
    public class ReduceInventory:IncreaseInventory
    {
        public long ProductId { get; set; }
        public long OederId { get; set; }
    }

}
