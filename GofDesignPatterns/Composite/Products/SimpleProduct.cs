namespace Composite.Products
{
    public class SimpleProduct : AbstractProduct
    {
        public string Brand { get; set; }

        public SimpleProduct(string name, double price, string brand) : base(name, price)
        {
            Brand = brand;
        }
    }
}
