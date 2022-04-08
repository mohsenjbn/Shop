using _01_framework.Infrastracture;

namespace InventoryManagement.Infrastracture.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
           return new Dictionary<string, List<PermissionDto>>
           {
               {
                   "Inventory",new List<PermissionDto>
                   {
                       new PermissionDto(InventoryPermission.ListInventory,"ListInventory"),
                       new PermissionDto(InventoryPermission.AddInventory,"AddInventory"),
                       new PermissionDto(InventoryPermission.EditInventory,"EditInventory"),
                       new PermissionDto(InventoryPermission.SearchInventory,"SearchInventory"),
                       new PermissionDto(InventoryPermission.ReduceInventory,"ReduceInventory"),
                       new PermissionDto(InventoryPermission.IncreaseInventory,"IncreaseInventory"),
                       new PermissionDto(InventoryPermission.OperationsLogInventory,"OperationsLogInventory"),
                   }
               }
           };
        }
    }
}
