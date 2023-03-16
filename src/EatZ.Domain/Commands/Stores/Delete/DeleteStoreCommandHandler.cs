using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Delete
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreCommandHandler(IStoreRepository storeRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            Store store = await _storeRepository.GetStoreByIdAsync(request.Id);

            if (store == default)
            {
                _notificationContext.AddNotification("Loja não encontrada.");
                return;
            }

            _storeRepository.DeleteStore(store);
            
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
