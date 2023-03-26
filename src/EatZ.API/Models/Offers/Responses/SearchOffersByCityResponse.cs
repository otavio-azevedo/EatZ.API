using EatZ.Domain.DTOs;
using EatZ.Infra.CrossCutting.Enums;

namespace EatZ.API.Models.Offers.Responses
{
    public class SearchOffersByCityResponse
    {
        public SearchOffersByCityResponse(string storeId, string storeName, IEnumerable<StoreImageDto> images, string description, decimal netUnitPrice, decimal grossUnitPrice, int quantity, EFoodTaste taste, DateTime expirationDate, DateTime pickUpDate)
        {
            StoreId = storeId;
            StoreName = storeName;
            Images = images;
            Description = description;
            NetUnitPrice = netUnitPrice;
            GrossUnitPrice = grossUnitPrice;
            Quantity = quantity;
            Taste = taste;
            ExpirationDate = expirationDate;
            PickUpDate = pickUpDate;
        }

        public string StoreId { get; private set; }

        public string StoreName { get; private set; }

        public IEnumerable<StoreImageDto> Images { get; private set; }

        public string Description { get; private set; }

        public decimal NetUnitPrice { get; private set; }

        public decimal GrossUnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public EFoodTaste Taste { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public DateTime PickUpDate { get; private set; }
    }
}
