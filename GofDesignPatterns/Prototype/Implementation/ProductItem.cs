namespace Prototype.Implementation
{
    public class ProductItem : IPrototype
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public IPrototype Clone()
        {
            return new ProductItem(Name, Price);
        }

        public IPrototype DeepClone()
        {
            return Clone();
        }
    }
}
