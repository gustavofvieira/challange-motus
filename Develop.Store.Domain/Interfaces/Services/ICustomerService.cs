using Develop.Store.Domain.Models;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(Customer customer);
    }
}
