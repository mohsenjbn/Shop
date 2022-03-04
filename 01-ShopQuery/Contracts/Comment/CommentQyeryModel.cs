namespace _01_ShopQuery.Contracts.Comment
{
    public class CommentQyeryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public long ParentId { get; set; }
        public long OwnerRecordId { get; set; }
        public string CreationDate { get; set; }
        public string ParentName { get; set; }
    }
}
