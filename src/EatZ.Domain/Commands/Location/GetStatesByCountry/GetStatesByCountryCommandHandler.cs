using MediatR;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;

namespace EatZ.Domain.Commands.Location.GetStatesByCountry
{
    public class GetStatesByCountryCommandHandler : IRequestHandler<GetStatesByCountryCommand, IEnumerable<State>>
    {
        private readonly IStateRepository _stateRepository;

        public GetStatesByCountryCommandHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<IEnumerable<State>> Handle(GetStatesByCountryCommand request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetStatesByCountryIdAsync(request.CountryId);
        }
    }
}
