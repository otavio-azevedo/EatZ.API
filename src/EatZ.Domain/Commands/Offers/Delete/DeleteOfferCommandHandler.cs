using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Delete
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOfferCommandHandler(IStoreOfferRepository storeOfferRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeOfferRepository = storeOfferRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            StoreOffers offer = await _storeOfferRepository.GetOfferByIdAsync(request.Id);

            if (offer == default)
            {
                _notificationContext.AddNotification("Oferta não encontrada.");
                return;
            }

            _storeOfferRepository.DeleteOffer(offer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
