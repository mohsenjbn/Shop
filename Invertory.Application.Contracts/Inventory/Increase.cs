using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Invertory.Application.Contracts.Inventory
{
    public class Increase
    {
        [Range(1, 10000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long InventoryId { get; set; }
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long Count { get; set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Describtion { get; set; }

    }

}