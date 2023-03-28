using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Enums;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatZ.Domain.Commands.Orders.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == default)
            {
                _notificationContext.AddNotification("Pedido não localizado.");
                return;
            }

            if (request.Status == EOrderStatus.Confirmed)
                order.SetConfirmationDate();

            if (request.Status == EOrderStatus.PickedUp)
                order.SetPickUpDate();

            order.UpdateStatus(request.Status);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
