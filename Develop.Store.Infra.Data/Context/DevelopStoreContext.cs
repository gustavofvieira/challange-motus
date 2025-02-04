using Develop.Store.Domain.Models;
using MongoDB.Driver;

namespace Develop.Store.Infra.Data.Context
{
    public class DevelopStoreContext
    {
        public DevelopStoreContext(IMongoDatabase database) => Database = database;

        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<Product> Products => Database.GetCollection<Product>("Products");
        public IMongoCollection<Customer> Customers => Database.GetCollection<Customer>("Customers");
        public IMongoCollection<Sale> Sales => Database.GetCollection<Sale>("Sales");
    }
}
