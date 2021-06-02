using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityDapperCore.BusinessLayer.Extensions;
using EntityDapperCore.DataAccessLayer;
using EntityDapperCore.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities = EntityDapperCore.DataAccessLayer.Entities;

namespace EntityDapperCore.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbContext dataContext;
        private readonly ISqlContext sqlContext;

        public ProductService(IDbContext dataContext, ISqlContext sqlContext, IConfiguration configuration)
        {
            this.dataContext = dataContext;
            this.sqlContext = sqlContext;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var query = dataContext.GetData<Entities.Product>().OrderBy(p => p.Name);
            var products = await query.Select(p => p.ToDto()).ToListAsync();

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var dbProduct = await dataContext.GetData<Entities.Product>().FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null)
            {
                return null;
            }

            var product = dbProduct.ToDto();
            return product;
        }

        public async Task DiscontinueAsync(int id)
        {
            await sqlContext.ExecuteAsync("UPDATE Products SET Discontinued = 1 WHERE ProductId = @id", new { id });

            //var dbProduct = await dataContext.GetData<Entities.Product>(true).FirstOrDefaultAsync(p => p.Id == id);
            //if (dbProduct != null)
            //{
            //    dbProduct.Discontinued = true;
            //    await dataContext.SaveChangesAsync();
            //}
        }

        public async Task DeleteAsync(int id)
        {
            await sqlContext.ExecuteAsync("DELETE FROM Products WHERE ProductId = @id", new { id });

            //var dbProduct = await dataContext.GetData<Entities.Product>(true).FirstOrDefaultAsync(p => p.Id == id);
            //if (dbProduct != null)
            //{
            //    dataContext.Products.Remove(dbProduct);
            //    await dataContext.SaveChangesAsync();
            //}
        }
    }
}
