using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(Product product)
        {
            await _productRepository.AddProduct(product);
        }

        public async Task<Product> GetProductById(Guid id) => await _productRepository.GetProductById(id);
    }
}
