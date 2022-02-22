using _01_framework.Domain;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:EntityBase
    {
        public string Name { get;private  set; }
        public int ShowOrder { get; private  set; }
        public string picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string pictureTitle { get; private set; }
        public string Describtion { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescribtion { get; private set; }
        public string Slug { get; private set; }
        public string CanonicalAddress { get; private set; }
        protected ArticleCategory() { }

        public ArticleCategory(string name, int showOrder, string picture, string pictureAlt,
            string pictureTitle, string describtion, string keyWords,
            string metaDescribtion, string slug, string canonicalAddress)
        {
            Name = name;
            ShowOrder = showOrder;
            this.picture = picture;
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            Describtion = describtion;
            KeyWords = keyWords;
            MetaDescribtion = metaDescribtion;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(string name, int showOrder, string picture, string pictureAlt,
            string pictureTitle, string describtion, string keyWords,
            string metaDescribtion, string slug, string canonicalAddress)
        {
            Name = name;
            ShowOrder = showOrder;
            if(!string.IsNullOrEmpty(picture))
            {
                this.picture = picture;

            }
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            Describtion = describtion;
            KeyWords = keyWords;
            MetaDescribtion = metaDescribtion;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
        }
    }
    
}
