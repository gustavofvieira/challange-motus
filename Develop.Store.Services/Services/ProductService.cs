using Develop.Store.Domain.Exceptions;
using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task CreateProduct(Product Product)
        {
            try
            {
                _logger.LogInformation("[{0}] - Started", nameof(CreateProduct));

                await _productRepository.CreateProduct(Product);
                //if (userBd is not null)
                //    throw new DomainException("E-mail Has Existent");

                //_validator.ValidateAndThrow(user);
                //user.Password = EncryptPassword(user.Password);
                //await _userRepository.Add(user);

                //_logger.LogInformation("Send Email to: {0}", user.EmailAddress);
                //_emailService.SendConfirmation(user);
                //_logger.LogInformation("[{Method}] Send Email with success", nameof(Add));
                //_logger.LogInformation("[{Method}] - Finish", nameof(Add));
            }
            catch (Exception ex)
            {
                //_logger.LogError("[{Method}] is failed! with message: {Message}", nameof(Add), ex.Message);
                //throw new DomainException(ex.Message);
            }
        }

        public async Task<Product> GetProductById(Guid id)
        {
            _logger.LogInformation("[{0}] - Started", nameof(GetProductById));
            try
            {
                var product = await _productRepository.GetProductById(id);
                
                if (product is null)
                {
                    _logger.LogWarning("[{Method}] - Product with Id: {id} not found", nameof(GetProductById), id);
                    throw new NotFoundException($"[{nameof(GetProductById)}] - Product with Id: {id} not found");// verificar retornando 500
                } 

                return product;
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(GetProductById), ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveProduct(Guid id)
        {
            _logger.LogInformation("[{0}] - Started", nameof(RemoveProduct));
            try
            {
                await _productRepository.RemoveProduct(id);
                _logger.LogInformation("[{0}] - Finished with success", nameof(RemoveProduct));
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(RemoveProduct), ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateProduct(Product Product)
        {
            _logger.LogInformation("[{0}] - Started", nameof(UpdateProduct));
            try
            {
                await _productRepository.UpdateProduct(Product);
                _logger.LogInformation("[{0}] - Finished with success", nameof(UpdateProduct));
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(UpdateProduct), ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
