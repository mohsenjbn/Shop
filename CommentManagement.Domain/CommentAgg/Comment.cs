using _01_framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public string WebSite { get; private set; }
        public bool Confirm { get; private set; }
        public bool Cancel { get; private set; }
        public int Type { get; private set; }
        public long OwnerRecordId { get; private set; }
        public string OwnerRecord { get;private set; }
        public long ParentId { get; private set; }
        public Comment parent { get; private set; }

        protected Comment()
        {

        }

        public Comment(string name, string email, string message, string webSite, int type, long ownerRecordId, long parentId,string ownerRecord)
        {
            Name = name;
            Email = email;
            Message = message;
            WebSite = webSite;
            Type = type;
            OwnerRecordId = ownerRecordId;
            ParentId = parentId;
            OwnerRecord = ownerRecord;  
        }

        public void IsConfirm()
        {
            Confirm = true;
        }

        public void ISCancel()
        {
            Cancel = true;  
        }
    }
}
