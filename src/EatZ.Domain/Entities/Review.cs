using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class Review : Entity<string>
    {
        public Review(string orderId, string comment, short rating)
        {
            OrderId = orderId;
            Comment = comment;
            Rating = rating;
            CreationDate = DateTime.Now;
        }

        public string OrderId { get; private set; }

        public Order Order { get; private set; }

        public string Comment { get; private set; }
        
        public short Rating { get; private set; }
        
        public DateTime CreationDate { get; private set; }
    }
}
