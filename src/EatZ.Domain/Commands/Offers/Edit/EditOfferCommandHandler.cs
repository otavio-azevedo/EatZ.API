using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Edit
{
    public class EditOfferCommandHandler : IRequestHandler<EditOfferCommand>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public EditOfferCommandHandler(IStoreOfferRepository storeOfferRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeOfferRepository = storeOfferRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditOfferCommand request, CancellationToken cancellationToken)
        {
            StoreOffers offer = await _storeOfferRepository.GetOfferByIdAsync(request.OfferId);

            if (offer == default)
            {
                _notificationContext.AddNotification("Oferta não localizada.");
                return;
            }
            
            offer.Update(request.Description, request.NetUnitPrice, request.GrossUnitPrice, request.Quantity, request.Taste, request.ExpirationDate, request.PickUpDate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
