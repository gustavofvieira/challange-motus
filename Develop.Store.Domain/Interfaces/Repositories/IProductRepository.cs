using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(Guid id);
    }
}
