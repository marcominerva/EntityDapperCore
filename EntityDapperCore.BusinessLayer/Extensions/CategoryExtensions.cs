using System.Linq;
using EntityDapperCore.Shared.Models;
using Entities = EntityDapperCore.DataAccessLayer.Entities;

namespace EntityDapperCore.BusinessLayer.Extensions
{
    public static class CategoriesExtensions
    {
        public static Category ToDto(this Entities.Category category)
            => new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category.Products?.Select(p => p.ToDto()).OrderBy(p => p.Name)
            };
    }
}
