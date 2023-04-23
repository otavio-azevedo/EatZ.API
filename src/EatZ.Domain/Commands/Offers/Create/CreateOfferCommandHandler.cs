using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Create
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, string>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOfferCommandHandler(IStoreOfferRepository storeOfferRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeOfferRepository = storeOfferRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var storeOffer = new StoreOffers(
                request.StoreId,
                request.Description,
                request.NetUnitPrice,
                request.GrossUnitPrice,
                request.Quantity,
                request.Taste,
                request.ExpirationDate,
                request.PickUpDate);

            await _storeOfferRepository.InsertOfferAsync(storeOffer);

            await _unitOfWork.SaveChangesAsync();

            if (_notificationContext.HasNotifications)
                return default;

            return storeOffer.Id;
        }
    }
}