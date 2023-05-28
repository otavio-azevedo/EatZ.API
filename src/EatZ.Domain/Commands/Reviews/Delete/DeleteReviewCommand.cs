using MediatR;

namespace EatZ.Domain.Commands.Reviews.Delete
{
    public class DeleteReviewCommand : IRequest
    {
        public DeleteReviewCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
