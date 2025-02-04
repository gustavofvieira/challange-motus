using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Models;
using System.Threading.Tasks;
using System;

namespace Develop.Store.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomer(Customer customer)
        {

            try
            {

                //_logger.LogInformation("[{0}] - Started", nameof(Add));

                await _customerRepository.AddCustomer(customer);
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
    }
}
