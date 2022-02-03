namespace Composite.Products
{
    public class CompositeProduct: AbstractProduct
    {
        private List<AbstractProduct> Products = new List<AbstractProduct>();
        public CompositeProduct(String name) : base(name, 0)
        {

        }

        public double GetPrice()
        {
            double price = 0d;

            foreach (AbstractProduct product in Products)
            {
                price += product.Price;
            }

            return price;
        }

        public void AddProduct(AbstractProduct product)
        {
            this.Products.Add(product);
        }

        public bool RemoveProduct(AbstractProduct product)
        {
            return this.Products.Remove(product);
        }
    }
}
