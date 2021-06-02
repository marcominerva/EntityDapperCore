using System.Collections.Generic;

namespace EntityDapperCore.Shared.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string City { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
