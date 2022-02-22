namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ShowOrder { get; set; }
        public string picture { get; set; }
        public string Describtion { get; set; }
        public string CreationDate { get; set; }

    }
}
