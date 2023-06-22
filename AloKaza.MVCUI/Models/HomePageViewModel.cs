using AloKaza.Core.Entities;

namespace AloKaza.MVCUI.Models
{
    public class HomePageViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<News> News { get; set; }
        public List<AppUser> AppUser { get; set; }

        public Contact Contact { get; set; }

    }
}
