using EatZ.Infra.CrossCutting.Enums;

namespace EatZ.API.Models.Offers.Responses
{
    public class SearchOffersByCityResponse
    {
        public SearchOffersByCityResponse(string storeId, string storeName, double storeAverageRating, int storeNumberOfReviews, byte[] storeLogoImage, string offerId, string description, decimal netUnitPrice, decimal grossUnitPrice, int initQuantity, int quantityAvaible, EFoodTaste taste, DateTime expirationDate, DateTime pickUpDate)
        {
            StoreId = storeId;
            StoreName = storeName;
            StoreAverageRating = storeAverageRating;
            StoreNumberOfReviews = storeNumberOfReviews;
            StoreLogoImage = Convert.ToBase64String(storeLogoImage);
            OfferId = offerId;
            Description = description;
            NetUnitPrice = netUnitPrice;
            GrossUnitPrice = grossUnitPrice;
            InitQuantity = initQuantity;
            QuantityAvaible = quantityAvaible;
            Taste = taste;
            ExpirationDate = expirationDate;
            PickUpDate = pickUpDate;
        }

        public string StoreId { get; private set; }

        public string StoreName { get; private set; }

        public double StoreAverageRating { get; private set; }

        public int StoreNumberOfReviews { get; private set; }

        public string StoreLogoImage { get; private set; }

        public string OfferId { get; private set; }

        public string Description { get; private set; }

        public decimal NetUnitPrice { get; private set; }

        public decimal GrossUnitPrice { get; private set; }

        public int InitQuantity { get; private set; }
        public int QuantityAvaible { get; private set; }

        public EFoodTaste Taste { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public DateTime PickUpDate { get; private set; }
    }
}
