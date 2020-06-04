namespace BuilderCompositeVisitor
{
    public class Address
    {
        public Address(
            string name,
            string line1,
            string line2,
            string city,
            string country,
            string postalCode)
        {
            Name = name;
            Line1 = line1;
            Line2 = line2;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}