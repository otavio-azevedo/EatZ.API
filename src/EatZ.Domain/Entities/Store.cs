using EatZ.Domain.DTOs;
using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class Store : Entity<string>
    {
        public Store(string name, string documentNumber, string phone, string zipCode, long cityId, string neighborhood, string street, int streetNumber, string complement, string description, double latitude, double longitude, byte[] logoImage)
        {
            Name = name;
            DocumentNumber = documentNumber;
            Phone = phone;
            ZipCode = zipCode;
            CityId = cityId;
            Neighborhood = neighborhood;
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
            CreatedAt = DateTime.Now;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            LogoImage = logoImage;
        }

        public string Name { get; private set; }

        public string DocumentNumber { get; private set; }

        public string Phone { get; private set; }

        public string ZipCode { get; private set; }

        public long CityId { get; private set; }

        public City City { get; private set; }

        public string Neighborhood { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }

        public string Complement { get; private set; }

        public string AdminId { get; private set; }

        public User Admin { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string Description { get; private set; }

        public ICollection<StoreImages> Images { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public ICollection<StoreOffers> Offers { get; private set; }

        public ICollection<Order> Orders { get; private set; }

        public StoreAverageReviewDto AverageReview { get; private set; }

        public byte[] LogoImage { get; private set; }

        public void SetAdmin(User admin)
        {
            Admin = admin;
            AdminId = admin.Id;
        }

        public void SetImages(ICollection<StoreImages> images)
        {
            Images = images;
        }

        public void SetAverageReview(StoreAverageReviewDto averageReview)
        {
            AverageReview = averageReview;
        }
    }
}