using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Stores.GetStoreByCurrentUser
{
    public class GetStoreByCurrentUserCommand : IRequest<Store>
    {
    }
}
