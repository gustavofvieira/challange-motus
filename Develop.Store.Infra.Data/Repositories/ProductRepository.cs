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

        public async Task AddProduct(Product product) => await _context.Products.InsertOneAsync(product);
        public async Task<Product> GetProductById(Guid id) => await _context.Products.AsQueryable().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
