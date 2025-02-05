using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductById(Guid id);
        Task UpdateProduct(Product product);
        Task RemoveProduct(Guid id);
    }
}
