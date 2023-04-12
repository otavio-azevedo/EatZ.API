namespace EatZ.API.Models.Location.Responses
{
    public class GetCitiesByStateResponse
    {
        public GetCitiesByStateResponse(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }
        public string Name { get; set; }
    }
}
