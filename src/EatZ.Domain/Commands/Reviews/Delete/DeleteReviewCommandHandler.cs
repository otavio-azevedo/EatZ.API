using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Reviews.Delete
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(request.Id);

            if (review == default)
                _notificationContext.AddNotification("Avaliação não encontrada.");

            _reviewRepository.RemoveReview(review);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
