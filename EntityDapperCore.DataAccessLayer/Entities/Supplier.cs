using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDapperCore.DataAccessLayer.Entities
{
    public class Supplier
    {
        [Column("SupplierId")]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
