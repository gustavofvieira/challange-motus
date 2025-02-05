using Develop.Store.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task RemoveCustomer(Guid id);
        Task UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(Guid id);
    }
}
