
using _01_framework.Application;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        List<CustomerDiscountViewModel> GetAll(SearchCustomerDiscunt searchmodel);
        EditCustomerDiscount GetDetails(long id);
    }
}
