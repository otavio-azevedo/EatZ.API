using EatZ.Domain.DTOs;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Create
{
    public class CreateStoreCommand : IRequest<string>
    {
        public CreateStoreCommand(string name, string documentNumber, string phone, string zipCode, string neighborhood, string complement, long cityId, string street, int streetNumber, string description, string logoImage)
        {
            Name = name;
            DocumentNumber = documentNumber;
            Phone = phone;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            Complement = complement;
            CityId = cityId;
            Street = street;
            StreetNumber = streetNumber;
            Description = description;
            LogoImage = logoImage;
        }

        public string Name { get; private set; }

        public string DocumentNumber { get; private set; }

        public string Phone { get; private set; }

        public string ZipCode { get; private set; }

        public string Neighborhood { get; private set; }

        public string Complement { get; private set; }

        public long CityId { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }

        public string Description { get; private set; }

        public string LogoImage { get; private set; }
    }
}
