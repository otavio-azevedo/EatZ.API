using EatZ.Domain.Entities.Base;

namespace EatZ.Domain.Entities
{
    public class StoreImages : Entity<string>
    {
        public StoreImages(string storeId, string title, byte[] content)
        {
            StoreId = storeId;
            Title = title;
            Content = content;
        }

        public string StoreId { get; private set; }
        
        public Store Store { get; private set; }
        
        public string Title { get; private set; }
        
        public byte[] Content { get; private set; }
    }
}
