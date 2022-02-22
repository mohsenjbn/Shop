

namespace ShopManagement.Application.Contracts.Slide
{
    public class SlideViewModel
    {
        public long Id { get; set; }
        public string picture { get; set; }
        public string Heading { get; set; }
        public string Btntext { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }

    }
}
