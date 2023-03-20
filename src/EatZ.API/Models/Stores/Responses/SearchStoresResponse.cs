namespace EatZ.API.Models.Stores.Responses
{
    public class SearchStoresByCityResponse
    {
        public SearchStoresByCityResponse(string storeId, string storeName, double latitude, double longitude)
        {
            StoreId = storeId;
            StoreName = storeName;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string StoreId { get; private set; }

        public string StoreName { get; private set; }

        public double Latitude { get; private set; }
        
        public double Longitude { get; private set; }
    }
}
