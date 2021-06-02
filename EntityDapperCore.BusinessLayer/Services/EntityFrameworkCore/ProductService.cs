using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityDapperCore.DataAccessLayer;
using EntityDapperCore.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Entities = EntityDapperCore.DataAccessLayer.Entities;

namespace EntityDapperCore.BusinessLayer.Services.EntityFrameworkCore
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
            var products = await query.Select(p => CreateDto(p)).ToListAsync();

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var dbProduct = await dataContext.Products.FindAsync(id);
            if (dbProduct == null)
            {
                return null;
            }

            var product = CreateDto(dbProduct);
            return product;
        }

        private static Product CreateDto(Entities.Product product)
            => new()
            {
                Id = product.Id,
                Name = product.Name,
                UnitsInStock = product.UnitsInStock.GetValueOrDefault(),
                UnitPrice = product.UnitPrice.GetValueOrDefault(),
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
                QuantityPerUnit = product.QuantityPerUnit,
                SupplierId = product.SupplierId
            };
    }
}
