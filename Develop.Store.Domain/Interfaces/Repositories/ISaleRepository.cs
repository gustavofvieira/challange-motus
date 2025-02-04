using Develop.Store.Domain.Models;
using System.Threading.Tasks;

namespace Develop.Store.Domain.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task AddSale(Sale sale);
    }
}
