using Develop.Store.Domain.DTO;
using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Develop.Store.Services.Services
{
    public class SaleService : ISaleService
    {

        private readonly IValidator<ProductDTO> _validator;
        private readonly ILogger _logger;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductService _productService;
        //private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository,
            IProductService productService,
            IValidator<ProductDTO> validator,
            ILogger<SaleService> logger
            //IMapper mapper
            )
        {
            _saleRepository = saleRepository;
            _productService = productService;
            _validator = validator;
            _logger = logger;
            //_mapper = mapper;
        }

        public async Task AddSale(SaleDTO saleDto)
        {
            _logger.LogInformation("[{0}] - Started", nameof(AddSale));
            //var sale = _mapper.Map<Sale>(saleDto);
            try
            {
                //_validator.ValidateAndThrow(saleDto.);
                await ApplyDiscountInProducts(saleDto.Products);
                await _saleRepository.AddSaleDto(saleDto);
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
                //_logger.LogError("[{Method}] is failed! with message: {Message}", nameof(AddSale), ex.Message);
                //throw new DomainException(ex.Message);
            }

            _logger.LogInformation("[{0}] - Finished", nameof(AddSale));
        }

        private async Task ApplyDiscountInProducts(List<ProductDTO> productsDTO)
        {
            try
            {
                foreach (var product in productsDTO)
                {
                    _validator.ValidateAndThrow(product);
                    var productDb = await _productService.GetProductById(product.Id);

                    if(product.Quantities > 4 && product.Quantities < 10)
                    {
                        product.TotalValue = product.Quantities * productDb.Value;
                        product.TotalValueAfterDiscount = product.TotalValue - (product.TotalValue * 0.1);  
                    }
                    else 
                    if (product.Quantities >= 10 && product.Quantities <= 20)
                    {
                        product.TotalValue = product.Quantities * productDb.Value;
                        product.TotalValueAfterDiscount = product.TotalValue - (product.TotalValue * 0.2);
                    }
                    else
                    {
                        product.TotalValue = product.Quantities * productDb.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(ApplyDiscountInProducts), ex.Message);
                //throw new DomainException(ex.Message);
            }
        }
    }
}
