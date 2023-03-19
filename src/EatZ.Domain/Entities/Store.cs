using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class Store : Entity<string>
    {
        public Store(string name, string documentNumber, string phone, string zipCode, string country, string state, string city, string neighborhood, string street, int streetNumber, string complement, string description)
        {
            Name = name;
            DocumentNumber = documentNumber;
            Phone = phone;
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
            CreatedAt = DateTime.Now;
            Description = description;
        }

        public string Name { get; private set; }

        public string DocumentNumber { get; private set; }

        public string Phone { get; private set; }

        public string ZipCode { get; private set; }

        public string Country { get; private set; }

        public string State { get; private set; }

        public string City { get; private set; }

        public string Neighborhood { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }

        public string Complement { get; private set; }

        public string AdminId { get; private set; }

        public User Admin { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string Description { get; private set; }

        public ICollection<StoreImages> Images { get; private set; }

        public void SetAdmin(User admin)
        {
            Admin = admin;
            AdminId = admin.Id;
        }

        public void SetImages(ICollection<StoreImages> images)
        {
            Images = images;
        }
    }
}