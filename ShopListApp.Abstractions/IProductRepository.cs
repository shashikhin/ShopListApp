using ShopListApp.Domain.Models;

namespace ShopListApp.Abstractions
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        ICollection<Product> GetProducts();
        bool CreateProduct(Product product);
        bool DeleteProduct(int id);
        bool UpdateProduct(Product product);
    }
}
