namespace Facade.Util
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; }

        public Customer()
        {
        }

        public Customer(Int64 id, string name, double balance, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
            this.Status = status;
        }
    }
}
