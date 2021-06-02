using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityDapperCore.BusinessLayer.Extensions;
using EntityDapperCore.DataAccessLayer;
using EntityDapperCore.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDapperCore.BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext dataContext;

        public CategoryService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Category>> GetAsync(bool includeProducts)
        {
            var query = dataContext.Categories.AsQueryable();
            if (includeProducts)
            {
                query = query.Include(c => c.Products);
            }

            var categories = await query.OrderBy(c => c.Name).Select(c => c.ToDto()).ToListAsync();

            return categories;
        }
    }
}
