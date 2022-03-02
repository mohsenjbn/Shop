﻿namespace CommnetManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string WebSite { get; set; }
        public int Type { get; set; }
        public long OwnerRecordId { get; set; }
        public string OwnerRecord { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string CreationDate { get; set; }
    }
}