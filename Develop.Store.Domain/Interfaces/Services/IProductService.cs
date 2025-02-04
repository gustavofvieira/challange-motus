using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(Guid id);
    }
}
