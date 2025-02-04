using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Models;
using Develop.Store.Infra.Data.Context;
using System.Threading.Tasks;

namespace Develop.Store.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DevelopStoreContext _context;
        public CustomerRepository(
            DevelopStoreContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(Customer customer) => await _context.Customers.InsertOneAsync(customer);
    }
}
