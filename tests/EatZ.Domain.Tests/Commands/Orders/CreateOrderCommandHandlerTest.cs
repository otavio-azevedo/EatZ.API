using EatZ.Domain.Commands.Orders.Create;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Orders
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly CreateOrderCommandHandler _handler;

        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public CreateOrderCommandHandlerTest()
        {
            _authenticationService = new Mock<IAuthenticationService>();
            _orderRepository = new Mock<IOrderRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            
            _handler = new CreateOrderCommandHandler(_authenticationService.Object, _orderRepository.Object, _notificationContext, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _authenticationService.Setup(x => x.GetUserIdFromToken()).Returns(Guid.NewGuid().ToString()).Verifiable();
            _orderRepository.Setup(x => x.InsertOrderAsync(It.IsAny<Order>())).Returns(Task.CompletedTask).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new CreateOrderCommand();
            var result = await _handler.Handle(command, default);

            Assert.False(string.IsNullOrEmpty(result));
            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll(_authenticationService, _orderRepository, _unitOfWork);
        }
    }
}
