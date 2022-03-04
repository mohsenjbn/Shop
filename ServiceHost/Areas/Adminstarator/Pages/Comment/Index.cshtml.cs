using CommnetManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Adminstarator.Pages.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        public CommentSearchModel searchModel { get; set; }
        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            Comments = _commentApplication.GetAll(searchModel);
        }


        public IActionResult OnGetCancel(long id)
        {
            var Result = _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetConfirm(long id)
        {
            var Result = _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }
    }
}
