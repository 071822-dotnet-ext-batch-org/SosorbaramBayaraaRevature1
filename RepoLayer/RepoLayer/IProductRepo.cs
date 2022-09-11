using ModelsLayer;

namespace Project2.DataAccessLayer.RepoLayer
{
    public interface IProductRepo : IRepo<Product>
    {
        void Update(Product product);
    }
}
