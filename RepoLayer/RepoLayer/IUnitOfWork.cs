namespace Project2.DataAccessLayer.RepoLayer
{
    public interface IUnitOfWork
    {
        ICategoryRepo Category { get; }

        IProductRepo Product { get; }

        void Save();
    }
}
