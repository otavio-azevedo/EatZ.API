using MediatR;

namespace EatZ.Domain.Commands.Reviews.Create
{
    public class CreateReviewCommand :IRequest<string>
    {
        public CreateReviewCommand(string orderId, string comment, short rating)
        {
            OrderId = orderId;
            Comment = comment;
            Rating = rating;
        }

        public string OrderId { get; private set; }

        public string Comment { get; private set; }

        public short Rating { get; private set; }
    }
}
