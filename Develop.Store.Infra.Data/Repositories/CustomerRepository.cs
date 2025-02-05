using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Models;
using Develop.Store.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
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

        public async Task CreateCustomer(Customer customer) => await _context.Customers.InsertOneAsync(customer);
        public async Task<Customer> GetCustomerById(Guid id) => await _context.Customers.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        public async Task RemoveCustomer(Guid id) => await _context.Customers.DeleteOneAsync(c => c.Id.Equals(id));
        public async Task UpdateCustomer(Customer customer) =>
            await _context.Customers.FindOneAndUpdateAsync(
                u => u.Id.Equals(customer.Id),
                Builders<Customer>.Update.Combine(
                    Builders<Customer>.Update.Set(c => c.Name, customer.Name),
                    Builders<Customer>.Update.Set(c => c.Document, customer.Document),
                    Builders<Customer>.Update.Set(c => c.Birthdate, customer.Birthdate),
                    Builders<Customer>.Update.Set(c => c.UpdatedAt, DateTime.UtcNow)
                ));
    }
}
