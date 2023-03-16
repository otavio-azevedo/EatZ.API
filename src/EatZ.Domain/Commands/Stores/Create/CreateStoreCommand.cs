using MediatR;

namespace EatZ.Domain.Commands.Stores.Create
{
    public class CreateStoreCommand : IRequest<string>
    {
        public CreateStoreCommand(string name, string documentNumber, string phone, string zipCode, string country, string neighborhood, string complement, string state, string city, string street, int streetNumber)
        {
            Name = name;
            DocumentNumber = documentNumber;
            Phone = phone;
            ZipCode = zipCode;
            Country = country;
            Neighborhood = neighborhood;
            Complement = complement;
            State = state;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }

        public string Name { get; private set; }

        public string DocumentNumber { get; private set; }

        public string Phone { get; private set; }

        public string ZipCode { get; private set; }

        public string Country { get; private set; }

        public string Neighborhood { get; private set; }
        
        public string Complement { get; private set; }

        public string State { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }
    }
}
