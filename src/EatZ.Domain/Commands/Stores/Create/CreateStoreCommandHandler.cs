using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.ExternalServices;
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
        private readonly IGoogleGeocodingApi _googleGeocodingApi;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreCommandHandler(IStoreRepository storeRepository, IAuthenticationService authenticationService, IGoogleGeocodingApi googleGeocodingApi, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _authenticationService = authenticationService;
            _googleGeocodingApi = googleGeocodingApi;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            string userId = _authenticationService.GetUserIdFromToken();
            User user = await _authenticationService.GetUserByIdAsync(userId);

            if (_notificationContext.HasNotifications)
                return default;

            var coordinates = await _googleGeocodingApi.GetCoordinatesAsync(request.ZipCode, request.Neighborhood, request.Street, request.StreetNumber);

            var store = new Store(
                request.Name,
                request.DocumentNumber,
                request.Phone,
                request.ZipCode,
                request.CityId,
                request.Neighborhood,
                request.Street,
                request.StreetNumber,
                request.Complement,
                request.Description,
                coordinates.Latitude,
                coordinates.Longitude);

            store.SetAdmin(user);

            var storeImages = request.Images.Select(x => new StoreImages(store.Id, x.Title, x.Content)).ToList();
            store.SetImages(storeImages);

            await _storeRepository.InsertStoreAsync(store);

            await _unitOfWork.SaveChangesAsync();

            if (_notificationContext.HasNotifications)
                return default;

            return store.Id;
        }
    }
}
