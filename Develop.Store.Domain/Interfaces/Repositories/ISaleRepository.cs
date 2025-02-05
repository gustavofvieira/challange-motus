using Develop.Store.Domain.DTO;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task AddSaleDto(SaleDTO saleDto);
    }
}
