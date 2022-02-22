

using _0_Framework.Application;
using _01_framework.Infrastracture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastracture.EfCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _context= context;
        }

        public List<SlideViewModel> GetAll()
        {
            return _context.slides.Select(x => new SlideViewModel
            {
                Id=x.Id,
                Btntext=x.Btntext,
                Heading=x.Heading,
                IsRemoved=x.IsRemoved,
                picture=x.Picture,
                CreationDate=x.CreationDate.ToFarsi(),

            }).ToList();

            
        }

        public EditSlide GetDetail(long id)
        {
            return _context.slides.Select(p=>new EditSlide
            {
                Id = p.Id,
                Btntext = p.Btntext,
                Heading = p.Heading,
                //Picture = p.Picture,
                PictureAlt=p.PictureAlt,
                PictureTitle=p.PictureTitle,
                Title=p.Title,
                Link=p.Link
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}
