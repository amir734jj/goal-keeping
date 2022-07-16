using Microsoft.AspNetCore.Identity;

namespace Models;

public class Role : IdentityRole<int>
{
    public Role() { }

    public Role(string roleName) : base(roleName)
    {

    }
}