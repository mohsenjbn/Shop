using _01_framework.Application;
using CommentManagement.Domain.CommentAgg;
using CommnetManagement.Application.Contracts.Comment;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult AddComment(AddComment command)
        {
            var operation = new OperationResult();

            var comment = new Comment(command.Name, command.Email,
                command.Message, command.WebSite, command.Type,
                command.OwnerRecordId, command.ParentId,command.OwnerRecord);

            _commentRepository.Create(comment);
            _commentRepository.Savechanges();

            return operation.IsSucssed();

        }

        public OperationResult Cancel(long Id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(Id);

            if (comment == null)
                operation.Failed(ResultMessage.IsNotExistRecord);

            comment.ISCancel();
            _commentRepository.Savechanges();

            return operation.IsSucssed();
        }

        public OperationResult Confirm(long Id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(Id);

            if (comment == null)
                operation.Failed(ResultMessage.IsNotExistRecord);

            comment.IsConfirm();
            _commentRepository.Savechanges();

            return operation.IsSucssed();
        }

        public List<CommentViewModel> GetAll(CommentSearchModel searchModel)
        {
            return _commentRepository.GetAll(searchModel);
        }
    }
}