using EatZ.Domain.Entities.Base;
using EatZ.Infra.CrossCutting.Enums;

namespace EatZ.Domain.Entities
{
    public class StoreOffers : Entity<string>
    {
        public StoreOffers(string storeId, string description, decimal netUnitPrice, decimal grossUnitPrice, int initQuantity, EFoodTaste taste, DateTime expirationDate, DateTime pickUpDate)
        {
            StoreId = storeId;
            Description = description;
            NetUnitPrice = netUnitPrice;
            GrossUnitPrice = grossUnitPrice;
            InitQuantity = QuantityAvaible = initQuantity;
            Taste = taste;
            CreationDate = DateTime.Now;
            ExpirationDate = expirationDate;
            PickUpDate = pickUpDate;
        }

        public string StoreId { get; private set; }

        public Store Store { get; private set; }

        public string Description { get; private set; }

        public decimal NetUnitPrice { get; private set; }

        public decimal GrossUnitPrice { get; private set; }

        public int InitQuantity { get; private set; }

        public int QuantityAvaible { get; private set; }

        public EFoodTaste Taste { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public DateTime PickUpDate { get; private set; }

        public ICollection<Order> Orders { get; private set; }

        public void Update(string description, decimal netUnitPrice, decimal grossUnitPrice, int initQuantity, EFoodTaste taste, DateTime expirationDate, DateTime pickUpDate)
        {
            Description = description;
            NetUnitPrice = netUnitPrice;
            GrossUnitPrice = grossUnitPrice;
            InitQuantity = initQuantity;
            Taste = taste;
            ExpirationDate = expirationDate;
            PickUpDate = pickUpDate;
        }

        internal void DiscountQuantityAvaible(int quantity)
        {
            QuantityAvaible -= quantity;
        }
    }
}