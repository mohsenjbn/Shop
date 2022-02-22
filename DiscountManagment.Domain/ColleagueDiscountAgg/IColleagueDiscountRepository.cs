using _01_framework.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscount;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public interface  IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
    {
        List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearch search);
        Edit GetDetails(long id);
    }
}
