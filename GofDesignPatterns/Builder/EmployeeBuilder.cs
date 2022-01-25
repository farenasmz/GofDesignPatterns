using Builder.Dto;

namespace Builder
{
    public class EmployeeBuilder : IBuilder<Employee>
    {
        private string Name;
        private string LastName;
        private Address Adress;
        private readonly List<Phone> Phones = new List<Phone>();

        public EmployeeBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public EmployeeBuilder SetLastName(string lastname)
        {
            this.LastName = lastname;
            return this;
        }

        public EmployeeBuilder SetAddress(string address, string city, string country, string cp)
        {
            Adress = new Address()
            {
                addre = address,
                City = city,
                Country = country,
                Cp = cp
            };
            return this;
        }

        public EmployeeBuilder SetPhone(string phone, string ext, string phoneType)
        {
            Phones.Add(new Phone()
            {
                Ext = ext,
                PhoneType = phoneType,
                PhoneNumber = phone,
            });
            return this;
        }

        public Employee Build()
        {
            return new Employee(Name, LastName, Adress, Phones);
        }
    }
}