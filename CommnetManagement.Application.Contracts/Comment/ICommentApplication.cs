using _01_framework.Application;

namespace CommnetManagement.Application.Contracts.Comment
{
    public interface  ICommentApplication
    {
        OperationResult AddComment(AddComment command);
        OperationResult Confirm(long Id);
        OperationResult Cancel(long Id);
        List<CommentViewModel> GetAll(CommentSearchModel searchModel);
    }
}
