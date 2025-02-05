using Develop.Store.Domain.DTO;
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

        public async Task AddSaleDto(SaleDTO saleDto) => await _context.SalesDto.InsertOneAsync(saleDto);
    }
}
