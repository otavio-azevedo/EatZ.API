namespace EatZ.Infra.CrossCutting.Utility.Pagination
{
    public interface IOffsetPagedRequest
    {
        int Limit { get; }

        int Offset { get; }
    }
}
