using Microsoft.EntityFrameworkCore;

namespace DemoShopApplication.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly DemoShopPieDBContext _demoShopPieDbContext;

        public PieRepository(DemoShopPieDBContext bethanysPieShopDbContext)
        {
            _demoShopPieDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _demoShopPieDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _demoShopPieDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _demoShopPieDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
