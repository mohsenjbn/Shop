using _01_framework.Domain;
using Blog.Management.Domain.ArticleCategoryAgg;
using System;

namespace Blog.Management.Domain.ArticleAgg
{
    public class Article:EntityBase
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string ShortDescribtion { get; private set; }
        public string Describtion { get; private set; }
        public string picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string pictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string MetaDescribtion { get; private set; }
        public string KeyWords { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory  Category { get; private set; }
        protected Article() { }

        public Article(string title, string slug, string shortDescribtion,
            string describtion, string picture, string pictureAlt, string pictureTitle,
            DateTime publishDate, string metaDescribtion, string keyWords,
            string canonicalAddress, long categoryId)
        {
            Title = title;
            Slug = slug;
            ShortDescribtion = shortDescribtion;
            Describtion = describtion;
            this.picture = picture;
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            PublishDate = publishDate;
            MetaDescribtion = metaDescribtion;
            KeyWords = keyWords;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }

        public void Edit(string title, string slug, string shortDescribtion,
            string describtion, string picture, string pictureAlt, string pictureTitle,
            DateTime publishDate, string metaDescribtion, string keyWords,
            string canonicalAddress, long categoryId)
        {
            Title = title;
            Slug = slug;
            ShortDescribtion = shortDescribtion;
            Describtion = describtion;
            if(!string .IsNullOrEmpty(picture))
            {
                this.picture = picture;

            }
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            PublishDate = publishDate;
            MetaDescribtion = metaDescribtion;
            KeyWords = keyWords;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
