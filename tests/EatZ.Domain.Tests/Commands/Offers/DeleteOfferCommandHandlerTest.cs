using EatZ.Domain.Commands.Offers.Create;
using EatZ.Domain.Commands.Offers.Delete;
using EatZ.Domain.Commands.Stores.Delete;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatZ.Domain.Tests.Commands.Offers
{
    public class DeleteOfferCommandHandlerTest
    {
        private readonly DeleteOfferCommandHandler _handler;

        private readonly Mock<IStoreOfferRepository> _storeOfferRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public DeleteOfferCommandHandlerTest()
        {
            _storeOfferRepository = new Mock<IStoreOfferRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            _handler = new DeleteOfferCommandHandler(_storeOfferRepository.Object, _notificationContext, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var storeOffer = new StoreOffers(default, default, default, default, default, default, default, default);
            _storeOfferRepository.Setup(x => x.GetOfferByIdAsync(It.IsAny<string>())).ReturnsAsync(storeOffer).Verifiable();
            _storeOfferRepository.Setup(x => x.DeleteOffer(It.IsAny<StoreOffers>())).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new DeleteOfferCommand(default);
            await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeOfferRepository.Setup(x => x.GetOfferByIdAsync(It.IsAny<string>())).ReturnsAsync(default(StoreOffers)).Verifiable();

            var command = new DeleteOfferCommand(default);
            await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
