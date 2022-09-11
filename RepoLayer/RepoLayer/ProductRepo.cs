using ModelsLayer;
using RepoLayer.Data;

namespace Project2.DataAccessLayer.RepoLayer
{
    public class ProductRepo : Repo<Product>, IProductRepo
    {
        private ProjectDbContext _context;
        public ProductRepo(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDb = _context.Products.FirstOrDefault(x=> x.ProductId == product.ProductId);
            if (productDb != null)
            {
                productDb.ProductName = product.ProductName;
                productDb.ProductDetail = product.ProductDetail;
                productDb.ProductPrice = product.ProductPrice;
                if (product.ProductImageUrl != null)
                {
                    product.ProductImageUrl = product.ProductImageUrl;
                }
            }
        }
    }
}
