
using _01_framework.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        List<SlideViewModel> GetAll();
        EditSlide GetDetail(long id);
    }
}
