using _01_framework.Domain;
using CommnetManagement.Application.Contracts.Comment;

namespace CommentManagement.Domain.CommentAgg
{
    public  interface  ICommentRepository:IRepository<long,Comment>
    {
        List<CommentViewModel> GetAll(CommentSearchModel searchModel);

    }
}
