using Microsoft.AspNetCore.Identity;

namespace TantaWebAp.Models
{
    public class ApplicationUser:IdentityUser
    {
        //Open extend close modification
        public string? Address { get; set; }
        
        //public Order MyProperty { get; set; }
    }
}
