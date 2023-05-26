using EatZ.Domain.Entities.Base;
using EatZ.Infra.CrossCutting.Enums;

namespace EatZ.Domain.Entities
{
    public class Order : Entity<long>
    {
        public Order(string storeId, string clientUserId, string offerId, DateTime creationDate, EOrderStatus status, decimal netUnitPrice, int quantity)
        {
            StoreId = storeId;
            ClientUserId = clientUserId;
            OfferId = offerId;
            CreationDate = creationDate;
            Status = status;
            NetUnitPrice = netUnitPrice;
            Quantity = quantity;
            Total = Math.Round(Quantity * netUnitPrice,2);
        }

        public string StoreId { get; private set; }

        public Store Store { get; private set; }

        public string ClientUserId { get; private set; }

        public User Client { get; private set; }

        public string OfferId { get; private set; }

        public StoreOffers Offer { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime? ConfirmationDate { get; private set; }

        public DateTime? PickUpDate { get; private set; }

        public EOrderStatus Status { get; private set; }
        
        public Review Review { get; private set; }
        
        public decimal NetUnitPrice { get; private set; }

        public int Quantity { get; private set; }
        
        public decimal Total { get; private set; }


        public void UpdateStatus(EOrderStatus status)
        {
            Status = status;
        }

        public void SetConfirmationDate()
        {
            ConfirmationDate = DateTime.Now;
        }

        public void SetPickUpDate()
        {
            PickUpDate = DateTime.Now;
        }
    }
}
