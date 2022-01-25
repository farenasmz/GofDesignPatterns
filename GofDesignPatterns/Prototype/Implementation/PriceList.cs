namespace Prototype.Implementation
{
    public class PriceList : IPrototype
    {
        private string ListName;
        private List<ProductItem> Products = new List<ProductItem>();

        public PriceList(string listName)
        {
            ListName = listName;
        }

        public List<ProductItem> GetProducts()
        {
            return Products;
        }

        public void AddProducts(ProductItem product)
        {
            Products.Add(product);
        }

        public void SetProducts(List<ProductItem> products)
        {
            Products = (products);
        }

        public string GetListName()
        {
            return ListName;
        }

        public void SetListName(string listName)
        {
            ListName = listName;
        }

        public IPrototype Clone()
        {
            PriceList clone = new PriceList(ListName);
            clone.SetProducts(Products);
            return clone;
        }

        public IPrototype DeepClone()
        {
            List<ProductItem> cloneProducts = new List<ProductItem>();

            foreach (ProductItem? item in Products)
            {
                ProductItem cloneItem = (ProductItem)item.Clone();
                cloneProducts.Add(cloneItem);
            }

            PriceList clone = new PriceList(ListName);
            clone.SetProducts(cloneProducts);
            return clone;
        }
    }
}
