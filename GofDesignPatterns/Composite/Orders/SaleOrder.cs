using Composite.Products;

namespace Composite.Orders
{
    public class SaleOrder
    {
        private long OrderId;
        private string Customer;
        private List<AbstractProduct> Products = new List<AbstractProduct>();

        public SaleOrder(long orderId, string customer)
        {
            Customer = customer;
            OrderId = orderId;
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
            Products.Add(product);
        }

        public void PrintOrder()
        {
            Console.WriteLine("\\\n============================================="
                    + "\nOrden: " + OrderId + "\nCustomer: " + Customer
                    + "\nProducts:\n");
            foreach (AbstractProduct prod in Products)
            {
                Console.WriteLine(prod.Name + "\t\t\t$ "
                        + prod.Price.ToString("###,##0.0000"));
            }
            Console.WriteLine("Total: " + GetPrice().ToString("###,##0.0000")
                    + "\n=============================================");
        }

        public long GetOrderId()
        {
            return OrderId;
        }

        public void SetOrderId(long orderId)
        {
            this.OrderId = orderId;
        }

        public string GetCustomer()
        {
            return Customer;
        }

        public void SetCustomer(string customer)
        {
            this.Customer = customer;
        }

        public List<AbstractProduct> GetProducts()
        {
            return Products;
        }

        public void SetProducts(List<AbstractProduct> products)
        {
            this.Products = products;
        }
    }
}
