using ShopListApp.Domain.Models;
using ShopListApp.Data.Context;
using ShopListApp.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ShopListApp.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return Save();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }

        public bool DeleteProduct(int productId)
        {
            var _product = GetProduct(productId);
            _context.Products.Remove(_product);

            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
