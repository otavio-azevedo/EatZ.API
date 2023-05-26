using EatZ.Domain.Commands.Orders.Update;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Enums;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Orders
{
    public class UpdateOrderCommandHandlerTest
    {
        private readonly UpdateOrderCommandHandler _handler;

        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public UpdateOrderCommandHandlerTest()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();

            _handler = new UpdateOrderCommandHandler(_orderRepository.Object, _notificationContext, _unitOfWork.Object);
        }

        [Theory]
        [InlineData(EOrderStatus.Confirmed)]
        [InlineData(EOrderStatus.PickedUp)]
        public async Task Handle_Success(EOrderStatus status)
        {
            var mockOrder = new Order(default, default, default, default, default, default, default);
            _orderRepository.Setup(x => x.GetOrderByIdAsync(default)).ReturnsAsync(mockOrder).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new UpdateOrderCommand();
            command.Status = status;
            await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll(_orderRepository, _unitOfWork);
        }

        [Fact]
        public async Task Handle_Error_OrderId()
        {
            _orderRepository.Setup(x => x.GetOrderByIdAsync(default)).ReturnsAsync(default(Order)).Verifiable();

            var command = new UpdateOrderCommand();
            await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll(_orderRepository);
        }

        [Fact]
        public async Task Handle_Error_Status()
        {
            var mockOrder = new Order(default, default, default, default, default, default, default);
            _orderRepository.Setup(x => x.GetOrderByIdAsync(default)).ReturnsAsync(mockOrder).Verifiable();

            var command = new UpdateOrderCommand();
            await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll(_orderRepository, _unitOfWork);
        }
    }
}
