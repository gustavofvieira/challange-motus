using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Models;
using Develop.Store.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Develop.Store.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevelopStoreContext _context;
        public ProductRepository(
            DevelopStoreContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product) => await _context.Products.InsertOneAsync(product);
        public async Task<Product> GetProductById(Guid id) => await _context.Products.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        public async Task RemoveProduct(Guid id) => await _context.Products.DeleteOneAsync(c => c.Id.Equals(id));
        public async Task UpdateProduct(Product product) =>
            await _context.Products.FindOneAndUpdateAsync(
                u => u.Id.Equals(product.Id),
                Builders<Product>.Update.Combine(
                    Builders<Product>.Update.Set(c => c.Name, product.Name),
                    Builders<Product>.Update.Set(c => c.Value, product.Value),
                    Builders<Product>.Update.Set(c => c.Canceled, product.Canceled),
                    Builders<Product>.Update.Set(c => c.Value, product.Value),
                    Builders<Product>.Update.Set(c => c.UpdatedAt, DateTime.UtcNow)
                ));
    }
}
