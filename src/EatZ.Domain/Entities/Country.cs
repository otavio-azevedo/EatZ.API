using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class Country : Entity<long>
    {
        public Country(string name, string acronym)
        {
            Name = name;
            Acronym = acronym;
        }

        public string Name { get; private set; }

        public string Acronym { get; private set; }

        public ICollection<State> States { get; private set; }
    }
}
