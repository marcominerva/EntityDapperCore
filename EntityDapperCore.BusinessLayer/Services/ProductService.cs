using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityDapperCore.BusinessLayer.Extensions;
using EntityDapperCore.DataAccessLayer;
using EntityDapperCore.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDapperCore.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext dataContext;

        public ProductService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var query = dataContext.Products.OrderBy(p => p.Name);
            var products = await query.Select(p => p.ToDto()).ToListAsync();

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var dbProduct = await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null)
            {
                return null;
            }

            var product = dbProduct.ToDto();
            return product;
        }

        public async Task DiscontinueAsync(int id)
        {
            var dbProduct = await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct != null)
            {
                dbProduct.Discontinued = true;
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var dbProduct = await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct != null)
            {
                dataContext.Products.Remove(dbProduct);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
