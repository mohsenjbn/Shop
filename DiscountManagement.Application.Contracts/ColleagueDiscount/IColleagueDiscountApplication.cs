using _01_framework.Application;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(Define command);
        OperationResult Edit(Edit command);
        List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearch search);
        Edit GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Active(long id);


    }
}
