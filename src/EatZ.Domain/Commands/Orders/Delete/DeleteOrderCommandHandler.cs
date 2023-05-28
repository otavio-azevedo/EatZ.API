using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }
        
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(request.Id);

            if (order == default)
            {
                _notificationContext.AddNotification("Loja não encontrada.");
                return;
            }

            _orderRepository.RemoveOrder(order);
            
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
