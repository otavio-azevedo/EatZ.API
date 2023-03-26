using EatZ.Infra.CrossCutting.Enums;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Edit
{
    public class EditOfferCommand : IRequest
    {
        public string OfferId { get; set; }

        public string Description { get; set; }

        public decimal NetUnitPrice { get; set; }

        public decimal GrossUnitPrice { get; set; }

        public int Quantity { get; set; }

        public EFoodTaste Taste { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime PickUpDate { get; set; }
    }
}
