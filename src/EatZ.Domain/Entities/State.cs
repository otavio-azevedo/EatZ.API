using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class State : Entity<long>
    {
        public State(long countryId, string name, string acronym)
        {
            CountryId = countryId;
            Name = name;
            Acronym = acronym;
        }

        public long CountryId { get; private set; }

        public Country Country { get; private set; }

        public string Name { get; private set; }
        
        public string Acronym { get; private set; }

        public ICollection<City> Cities { get; private set; }
    }
}
