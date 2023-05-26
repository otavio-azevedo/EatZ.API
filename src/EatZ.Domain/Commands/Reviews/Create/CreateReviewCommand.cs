using MediatR;

namespace EatZ.Domain.Commands.Reviews.Create
{
    public class CreateReviewCommand :IRequest<string>
    {
        public CreateReviewCommand(long orderId, string comment, short rating)
        {
            OrderId = orderId;
            Comment = comment;
            Rating = rating;
        }

        public long OrderId { get; private set; }

        public string Comment { get; private set; }

        public short Rating { get; private set; }
    }
}
