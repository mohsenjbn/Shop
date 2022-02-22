
using _01_ShopQuery.Contracts.Slide;
using ShopManagement.Infrastracture.EfCore;

namespace _01_ShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetAllSlide()
        {
            return _context.slides.Where(p=>p.IsRemoved==false).Select(p=>new SlideQueryModel
            {
                Btntext=p.Btntext,
                Heading=p.Heading,
                Picture=p.Picture,
                PictureAlt=p.PictureAlt,
                PictureTitle=p.PictureTitle,
                Title=p.Title,
                Link=p.Link,
            }).ToList();
        }
    }
}
