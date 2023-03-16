namespace EatZ.Domain.Entities.Base
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        protected Entity()
        {
            if (typeof(TKey).IsAssignableFrom(typeof(string)) && Id == null)
            {
                string value = Guid.NewGuid().ToString();
                Id = (TKey)Convert.ChangeType(value, typeof(TKey));
            }
        }
    }
}
