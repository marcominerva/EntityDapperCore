using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDapperCore.Shared.Models;

namespace EntityDapperCore.BusinessLayer.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAsync(bool includeProducts);
    }
}