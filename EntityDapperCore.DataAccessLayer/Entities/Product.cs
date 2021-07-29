namespace EntityDapperCore.DataAccessLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short? UnitsInStock { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
