namespace EatZ.Domain.DTOs
{
    public class GetCoordinatesDto
    {
        public GetCoordinatesDto(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}