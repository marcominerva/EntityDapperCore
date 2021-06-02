using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityDapperCore.BusinessLayer.Extensions;
using EntityDapperCore.DataAccessLayer;
using EntityDapperCore.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Entities = EntityDapperCore.DataAccessLayer.Entities;

namespace EntityDapperCore.BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbContext dataContext;

        public CategoryService(IDbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Category>> GetAsync(bool includeProducts)
        {
            var query = dataContext.GetData<Entities.Category>().AsQueryable();
            if (includeProducts)
            {
                query = query.Include(c => c.Products);
            }

            var categories = await query.OrderBy(c => c.Name).Select(c => c.ToDto()).ToListAsync();

            return categories;
        }
    }
}
