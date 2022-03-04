using _01_ShopQuery.Contracts.Product;
using CommnetManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryViewModel product { get; set; }
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {

            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            product=_productQuery.GetProducutBy(id);
        }

        public IActionResult OnPost(AddComment command,string productSlug)
        {
            command.Type = CommentTypes.Product;
            _commentApplication.AddComment(command);

            return RedirectToPage("/Product", new{ Id= productSlug });

        }
    }
}
