using System.Collections.Generic;

namespace EntityDapperCore.DataAccessLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
