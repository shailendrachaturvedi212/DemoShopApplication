namespace DemoShopApplication.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DemoShopPieDBContext _demoshoppieDbContext;

        public CategoryRepository(DemoShopPieDBContext bethanysPieShopDbContext)
        {
            _demoshoppieDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _demoshoppieDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
