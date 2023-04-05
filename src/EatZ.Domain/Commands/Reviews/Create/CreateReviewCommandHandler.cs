using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using MediatR;

namespace EatZ.Domain.Commands.Reviews.Create
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, string>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review(request.OrderId, request.Comment, request.Rating);

            await _reviewRepository.InsertReviewAsync(review);

            await _unitOfWork.SaveChangesAsync();

            return review.Id;
        }
    }
}
