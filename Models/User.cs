using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Models.Enums;
using Models.Interfaces;

namespace Models;

public class User : IdentityUser<int>, IEntity
{
    public string Name { get; set; }

    public virtual DateTimeOffset LastLoginTime { get; set; }  = DateTimeOffset.MinValue;
        
    public RoleEnum Role { get; set; }
        
    [Column(TypeName = "text")]
    public string Description { get; set; }

    public List<Goal> Goals { get; set; } = new();

    public string Photo { get; set; }
}