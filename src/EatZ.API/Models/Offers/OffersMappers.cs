using EatZ.API.Models.Offers.Responses;
using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.API.Models.Offers
{
    public static class OffersMappers
    {
        public static IEnumerable<SearchOffersByCityResponse> Map(IEnumerable<StoreOffers> storeOffers)
        {
            if (storeOffers.IsNullOrEmpty())
                return Enumerable.Empty<SearchOffersByCityResponse>();

            return storeOffers.Select(x => new SearchOffersByCityResponse(
                    x.StoreId,
                    x.Store.Name,
                    Map(x.Store.Images),
                    x.Description,
                    x.NetUnitPrice,
                    x.GrossUnitPrice,
                    x.Quantity,
                    x.Taste,
                    x.ExpirationDate,
                    x.PickUpDate
                ));
        }

        private static IEnumerable<StoreImageDto> Map(ICollection<StoreImages> images)
        {
            if (images.IsNullOrEmpty())
                return Enumerable.Empty<StoreImageDto>();

            return images.Select(x => new StoreImageDto(x.Title, Convert.ToBase64String(x.Content)));
        }
    }
}
