﻿using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Create
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, string>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreCommandHandler(IStoreRepository storeRepository, IAuthenticationService authenticationService, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _authenticationService = authenticationService;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            string userId = _authenticationService.GetUserIdFromToken();
            User user = await _authenticationService.GetUserByIdAsync(userId);

            if (_notificationContext.HasNotifications)
                return default;

            Store store = new(
                request.Name,
                request.DocumentNumber,
                request.Phone,
                request.ZipCode,
                request.Country,
                request.State,
                request.City,
                request.Neighborhood,
                request.Street,
                request.StreetNumber,
                request.Complement);

            store.SetAdmin(user);

            await _storeRepository.InsertStoreAsync(store);

            await _unitOfWork.SaveChangesAsync();

            if (_notificationContext.HasNotifications)
                return default;

            return store.Id;
        }
    }
}
