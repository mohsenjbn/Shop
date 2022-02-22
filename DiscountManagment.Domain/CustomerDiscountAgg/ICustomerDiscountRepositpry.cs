using _01_framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;

namespace DiscountManagment.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepositpry:IRepository<long,CustomerDiscount>
    {
        List<CustomerDiscountViewModel> GetAll(SearchCustomerDiscunt searchmodel);
        EditCustomerDiscount GetDetails(long id);
    }
}
