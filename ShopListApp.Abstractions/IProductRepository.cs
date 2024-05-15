using ShopListApp.Domain.Models;

namespace ShopListApp.Abstractions
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        ICollection<Product> GetProducts();
        bool CreateProduct(string name, double cost);
        bool DeleteProduct(int id);
        bool UpdateProduct(Product product);
    }
}
