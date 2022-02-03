namespace Composite.Products
{
    public abstract class AbstractProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public AbstractProduct(string name, double price)
        {
            Price = price;
            Name = name;
        }
    }
}
