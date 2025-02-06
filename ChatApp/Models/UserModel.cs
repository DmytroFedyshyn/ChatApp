using Microsoft.AspNetCore.Identity;

namespace ChatApp.Models
{
    public class UserModel : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
