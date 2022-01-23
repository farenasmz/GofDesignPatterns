namespace FactoryMethod.Entity
{
    public class Product
    {
        public Product(Int64 idProduct, string productName, double price)
        {
            this.IdProduct = idProduct;
            this.ProductName = productName;
            this.Price = price;
        }
        public Product()
        {

        }

        public Int64 IdProduct { get; set; }
        public String ProductName { get; set; }
        public double Price { get; set; }
    }
}
