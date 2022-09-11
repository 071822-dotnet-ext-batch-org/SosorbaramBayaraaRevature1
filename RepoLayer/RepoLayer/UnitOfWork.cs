using RepoLayer.Data;

namespace Project2.DataAccessLayer.RepoLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectDbContext _context;
        public ICategoryRepo Category { get; private set; }

        public IProductRepo Product { get; private set; }

        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
            Category = new CategoryRepo(context);
            Product = new ProductRepo(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
