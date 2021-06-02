using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDapperCore.Shared.Models;

namespace EntityDapperCore.BusinessLayer.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync();

        Task<Product> GetAsync(int id);

        Task DiscontinueAsync(int id);

        Task DeleteAsync(int id);
    }
}