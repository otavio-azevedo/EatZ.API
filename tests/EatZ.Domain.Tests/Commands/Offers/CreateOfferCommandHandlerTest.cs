using EatZ.Domain.Commands.Offers.Create;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Offers
{
    public class CreateOfferCommandHandlerTest
    {
        private readonly CreateOfferCommandHandler _handler;

        private readonly Mock<IStoreOfferRepository> _storeOfferRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public CreateOfferCommandHandlerTest()
        {
            _storeOfferRepository = new Mock<IStoreOfferRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            _handler = new CreateOfferCommandHandler(_storeOfferRepository.Object,_notificationContext,_unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _storeOfferRepository.Setup(x => x.InsertOfferAsync(It.IsAny<StoreOffers>())).Returns(Task.CompletedTask).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new CreateOfferCommand();
            var result = await _handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
