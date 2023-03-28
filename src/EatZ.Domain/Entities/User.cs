using Microsoft.AspNetCore.Identity;

namespace EatZ.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {

        }

        public string Name { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public ICollection<Order> Orders { get; private set; }
    }
}
