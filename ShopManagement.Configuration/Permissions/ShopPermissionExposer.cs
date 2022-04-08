using _01_framework.Infrastracture;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermission.ListProducts,"ListProducts"),
                        new PermissionDto(ShopPermission.AddProduct,"AddProduct"),
                        new PermissionDto(ShopPermission.EditProduct,"EditProduct"),
                        new PermissionDto(ShopPermission.SearchProducts,"SearchProducts"),

                    }


                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermission.ListProductCategories,"ListProductCategories"),
                        new PermissionDto(ShopPermission.AddProductCategory,"AddProductCategory"),
                        new PermissionDto(ShopPermission.EditProductCategory,"EditProductCategory"),
                        new PermissionDto(ShopPermission.SearchProductCategories,"SearchProductCategories"),

                    }
                }

            };
        }
    }
}
