using _01_framework.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]

        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.DiscountRange)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}

