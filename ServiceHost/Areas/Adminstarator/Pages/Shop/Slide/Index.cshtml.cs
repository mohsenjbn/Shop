using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
       
        public List<SlideViewModel> Slides { get; set; }
        
        private readonly ISlideApplication _SlideApplication;
       
        public IndexModel(ISlideApplication slideApplication)
        {
            _SlideApplication = slideApplication;
        }
        public void OnGet()
        {
            Slides = _SlideApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
           
            return Partial("./Create",new CreateSlide());
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _SlideApplication.CreateSlide(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var Slide = _SlideApplication.GetDetail(Id);
            
            return Partial("./Edit", Slide);

        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _SlideApplication.EditSlide(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _SlideApplication.Remove(id);
            return RedirectToPage("./Index", result);

        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _SlideApplication.Restore(id);
            return RedirectToPage("./Index", result);

        }
    }
}
