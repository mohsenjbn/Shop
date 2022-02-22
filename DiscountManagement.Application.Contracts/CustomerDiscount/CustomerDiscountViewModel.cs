using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }

        public long ProductId { get; set; }

        public int DiscountRate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Reason { get; set; }
        public string CreationDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }


    }
}

