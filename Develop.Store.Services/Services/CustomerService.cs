using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace Develop.Store.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task CreateCustomer(Customer customer)
        {
            try
            {
                _logger.LogInformation("[{0}] - Started", nameof(CreateCustomer));

                await _customerRepository.CreateCustomer(customer);
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

        public async Task<Customer> GetCustomerById(Guid id) 
        {
            _logger.LogInformation("[{0}] - Started", nameof(GetCustomerById));
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(GetCustomerById), ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveCustomer(Guid id)
        {
            _logger.LogInformation("[{0}] - Started", nameof(RemoveCustomer));
            try
            {
                await _customerRepository.RemoveCustomer(id);
                _logger.LogInformation("[{0}] - Finished with success", nameof(RemoveCustomer));
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(RemoveCustomer), ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _logger.LogInformation("[{0}] - Started", nameof(UpdateCustomer));
            try
            {
                await _customerRepository.UpdateCustomer(customer);
                _logger.LogInformation("[{0}] - Finished with success", nameof(UpdateCustomer));
            }
            catch (Exception ex)
            {
                _logger.LogError("[{Method}] is failed! with message: {Message}", nameof(UpdateCustomer), ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
