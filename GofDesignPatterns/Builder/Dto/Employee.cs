namespace Builder.Dto
{
    public class Employee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }
        public Address Address { get; set; }

        public Employee(string name, string lastname, Address adress, List<Phone> phones)
        {
            this.Name = name;
            this.Address = adress;
            this.Phones = phones;
            this.LastName = lastname;
        }
    }
}
