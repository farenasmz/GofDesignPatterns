namespace Builder.Dto
{
    public class Address
    {
        public string addre { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Cp { get; set; }

        public Address()
        {
        }

        public Address(string address, string city, string country, string cp)
        {
            this.addre = address;
            this.City = city;
            this.Country = country;
            this.Cp = cp;
        }
    }
}
