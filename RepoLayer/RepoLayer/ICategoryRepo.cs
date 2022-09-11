using ModelsLayer;

namespace Project2.DataAccessLayer.RepoLayer
{
    public interface ICategoryRepo : IRepo<Category>
    {
        void Update(Category category);
    }
}
