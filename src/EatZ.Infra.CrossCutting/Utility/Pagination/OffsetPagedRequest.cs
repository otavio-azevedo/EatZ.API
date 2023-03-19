namespace EatZ.Infra.CrossCutting.Utility.Pagination
{
    public  class OffsetPagedRequest : IOffsetPagedRequest
    {
        public int Limit { get; set; } = 10;

        public int Offset { get; set; }

        public OffsetPagedRequest()
        {
        }

        public OffsetPagedRequest(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
