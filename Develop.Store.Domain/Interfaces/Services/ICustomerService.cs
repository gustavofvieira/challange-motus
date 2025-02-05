using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
        Task<Customer> GetCustomerById(Guid id);
        Task UpdateCustomer(Customer customer);
        Task RemoveCustomer(Guid id);
    }
}
