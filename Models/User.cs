using Microsoft.AspNetCore.Identity;
using Models.Interfaces;

namespace Models;

public class User : IdentityUser<int>, IEntity
{
}