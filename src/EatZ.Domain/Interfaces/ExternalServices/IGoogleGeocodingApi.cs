using EatZ.Domain.DTOs;

namespace EatZ.Domain.Interfaces.ExternalServices
{
    public interface IGoogleGeocodingApi
    {
        Task<GetCoordinatesDto> GetCoordinatesAsync(string zipCode,string neighborhood, string street, int streetNumber);
    }
}
