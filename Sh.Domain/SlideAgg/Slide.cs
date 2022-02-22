using _01_framework.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide:EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get;private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Btntext { get; private set; }
        public bool IsRemoved { get; private set; }
        public string Link { get;private set; }

        protected Slide()
        {

        }

        public Slide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string btntext,string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Btntext = btntext;
            IsRemoved = false;
            Link = link;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title, string btntext,string link)
        {
            if(!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Btntext = btntext;
            Link = link;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
