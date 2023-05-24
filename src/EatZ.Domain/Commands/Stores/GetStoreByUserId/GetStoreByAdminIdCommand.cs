using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Stores.GetStoreByUserId
{
    public class GetStoreByAdminIdCommand : IRequest<Store>
    {
    }
}
