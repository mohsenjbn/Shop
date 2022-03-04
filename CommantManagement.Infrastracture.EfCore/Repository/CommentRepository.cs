using _0_Framework.Application;
using _01_framework.Infrastracture;
using CommentManagement.Domain.CommentAgg;
using CommnetManagement.Application.Contracts.Comment;

namespace CommantManagement.Infrastracture.EfCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context):base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetAll(CommentSearchModel searchModel)
        {
            var query = _context.Comments.Select(p => new CommentViewModel
            {
               Id=p.Id,
               Email=p.Email,
               IsCanceled=p.Cancel,
               CreationDate=p.CreationDate.ToFarsi(),
               IsConfirmed=p.Confirm,
               Message=p.Message,
               Name=p.Name,
               OwnerRecordId=p.OwnerRecordId,
               Type=p.Type,
               WebSite=p.WebSite,
               OwnerRecord=p.OwnerRecord,
              
            });
            
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            if(searchModel.Type > 0)
                query=query.Where(p=>p.Type==searchModel.Type);


            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
