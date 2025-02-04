using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Models;
using Develop.Store.Infra.Data.Context;
using System.Threading.Tasks;

namespace Develop.Store.Infra.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DevelopStoreContext _context;
        public SaleRepository(
            DevelopStoreContext context)
        {
            _context = context;
        }

        public async Task AddSale(Sale sale) => await _context.Sales.InsertOneAsync(sale);
    }
}
