using Microsoft.AspNetCore.Identity;

namespace IT_EComm.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

    }

}
