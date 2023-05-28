using EatZ.Domain.Commands.Offers.Edit;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Offers
{
    public class EditOfferCommandHandlerTest
    {
        private readonly EditOfferCommandHandler _handler;

        private readonly Mock<IStoreOfferRepository> _storeOfferRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public EditOfferCommandHandlerTest()
        {
            _storeOfferRepository = new Mock<IStoreOfferRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            _handler = new EditOfferCommandHandler(_storeOfferRepository.Object, _notificationContext, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var storeOffer = new StoreOffers(default, default, default, default, default, default, default, default);
            _storeOfferRepository.Setup(x => x.GetOfferByIdAsync(It.IsAny<string>())).ReturnsAsync(storeOffer).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new EditOfferCommand();
            await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeOfferRepository.Setup(x => x.GetOfferByIdAsync(It.IsAny<string>())).ReturnsAsync(default(StoreOffers)).Verifiable();

            var command = new EditOfferCommand();
            await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
