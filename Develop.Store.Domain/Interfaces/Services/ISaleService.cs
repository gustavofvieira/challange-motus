using Develop.Store.Domain.DTO;
using Develop.Store.Domain.Models;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        Task AddSale(SaleDTO saleDto);
    }
}
