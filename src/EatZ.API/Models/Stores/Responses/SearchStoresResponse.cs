namespace EatZ.API.Models.Stores.Responses
{
    public class SearchStoresResponse
    {
        public SearchStoresResponse(string id, string name, string phone, string zipCode, string country, string state, string city, string neighborhood, string street, int streetNumber, string complement)
        {
            Id = id;
            Name = name;
            Phone = phone;
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string Complement { get; set; }
    }
}
