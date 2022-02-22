

using _01_framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult CreateSlide(CreateSlide command);
        OperationResult EditSlide(EditSlide command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<SlideViewModel> GetAll();
        EditSlide GetDetail(long id);
         
    }
}
