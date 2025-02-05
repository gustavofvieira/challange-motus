using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductById(Guid id);
        Task RemoveProduct(Guid id);
        Task UpdateProduct(Product product);
    }
}
