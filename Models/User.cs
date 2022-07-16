using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
    [AllowNull]
    public string Description { get; set; }

    public List<Goal> Goals { get; set; } = new();

    [AllowNull]
    public string Photo { get; set; }
}