namespace EatZ.Domain.DTOs
{
    public class StoreImageDto
    {
        public StoreImageDto(string title, string base64Content)
        {
            Title = title;
            Base64Content = base64Content;
        }

        public string Title { get; private set; }

        public string Base64Content { get; private set; }

        public byte[] Content => Base64Content != default ? Convert.FromBase64String(Base64Content) : Array.Empty<byte>();
    }
}
