namespace _01_ShopQuery.Contracts.Article
{
    public class ArticleQueryModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public string Slug { get;  set; }
        public string ShortDescribtion { get;  set; }
        public string Describtion { get;  set; }
        public string picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string pictureTitle { get;  set; }
        public string KeyWords { get; set; }
        public string PublishDate { get;  set; }
        public DateTime PublishDateGe { get; set; }
        public string MetaDescribtion { get;  set; }
        public string CanonicalAddress { get;  set; }
        public long CategoryId { get;  set; }
        public string Category { get;  set; }
        public string CategorySlug { get; set; }
        public List<string> KeyWordList { get; set; }
    }
}
