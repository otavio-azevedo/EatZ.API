using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class City : Entity<long>
    {
        public City(long stateId, string name, double latitude, double longitude)
        {
            StateId = stateId;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public long StateId { get; private set; }
        
        public State State { get; private set; }

        public string Name { get; private set; }
        
        public double Latitude { get; private set; }
        
        public double Longitude { get; private set; }
    }
}
