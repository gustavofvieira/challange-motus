using Develop.Store.Domain.Models;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
    }
}
