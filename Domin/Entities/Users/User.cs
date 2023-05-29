using Domin.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Domin.Entities.Users
{
    [Auditable]
    public class User:IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
