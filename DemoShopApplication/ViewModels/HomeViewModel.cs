using DemoShopApplication.Models;

namespace DemoShopApplication.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
            PiesOfTheWeek = piesOfTheWeek;
        }
    }
}
