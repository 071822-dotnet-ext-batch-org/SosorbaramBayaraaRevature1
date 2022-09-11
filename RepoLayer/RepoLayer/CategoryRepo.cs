using ModelsLayer;
using RepoLayer.Data;

namespace Project2.DataAccessLayer.RepoLayer
{
    public class CategoryRepo : Repo<Category>, ICategoryRepo
    {
        private ProjectDbContext _context;
        public CategoryRepo(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDB = _context.Categories.FirstOrDefault(x => x.ProductId == category.ProductId);
            if (categoryDB != null)
            {
                categoryDB.ProductName = category.ProductName;
                categoryDB.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
