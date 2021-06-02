using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDapperCore.Shared.Models;

namespace EntityDapperCore.BusinessLayer.Services.EntityFrameworkCore
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync();

        Task<Product> GetAsync(int id);
    }
}