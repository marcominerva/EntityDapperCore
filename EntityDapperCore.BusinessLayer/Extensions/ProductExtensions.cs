using EntityDapperCore.Shared.Models;
using Entities = EntityDapperCore.DataAccessLayer.Entities;

namespace EntityDapperCore.BusinessLayer.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToDto(this Entities.Product product)
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
