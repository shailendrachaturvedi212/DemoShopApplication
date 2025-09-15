using BethanysPieShop.Controllers;
using DemoShopApplication.Controllers;
using DemoShopApplication.ViewModels;
using ShopApplicationTests.Mocks;
using System.Linq;
using Xunit;

namespace ShopApplicationTests.Controllers
{
    public class HomeControllerTests
    {

        [Fact]
        public void Index_Use_PieOfTheWeeks_FromRepository()
        {
            var mockPieRepository = RepositoryMocks.GetPieRepository();

            HomeController homeController = new HomeController(mockPieRepository.Object);

            var result = homeController.Index().ViewData.Model
                    as HomeViewModel;

            Assert.NotNull(result);

            var piesOfTheWeek = result?.PiesOfTheWeek?.ToList();
            Assert.NotNull(piesOfTheWeek);
            Assert.True(piesOfTheWeek?.Count() == 3);
            Assert.Equal("Apple Pie", piesOfTheWeek?[0].Name);


        }
    }
}
