using System.Text.Json.Serialization;

namespace EatZ.ExternalServices.Google.Services.Geocoding.Responses
{
    public class GetCoordinatesResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<Result> Results { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class AddressComponent
    {
        [JsonPropertyName("long_name")]
        public string LongName { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<string> Types { get; set; }
    }

    public class Bounds
    {
        [JsonPropertyName("northeast")]
        public Northeast Northeast { get; set; }

        [JsonPropertyName("southwest")]
        public Southwest Southwest { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("bounds")]
        public Bounds Bounds { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }

        [JsonPropertyName("viewport")]
        public Viewport Viewport { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Northeast
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("address_components")]
        public IEnumerable<AddressComponent> AddressComponents { get; set; }

        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<string> Types { get; set; }
    }

    public class Southwest
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Viewport
    {
        [JsonPropertyName("northeast")]
        public Northeast Northeast { get; set; }

        [JsonPropertyName("southwest")]
        public Southwest Southwest { get; set; }
    }


}
