using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDapperCore.DataAccessLayer.Entities
{
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        public short? UnitsInStock { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public bool Discontinued { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
    }
}
