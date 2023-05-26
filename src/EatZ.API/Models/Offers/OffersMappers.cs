using EatZ.API.Models.Offers.Responses;
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
                    x.Store.AverageReview.AverageRating,
                    x.Store.AverageReview.NumberOfReviews,
                    x.Store.LogoImage,
                    x.Id,
                    x.Description,
                    x.NetUnitPrice,
                    x.GrossUnitPrice,
                    x.InitQuantity,
                    x.Taste,
                    x.ExpirationDate,
                    x.PickUpDate
                ));
        }
    }
}
