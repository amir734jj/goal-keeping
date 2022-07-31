using System.ComponentModel.DataAnnotations;
using Models.Interfaces;

namespace Models;

public class Goal : IEntityUserBound
{
    public int Id { get; set; }

    public DateTimeOffset AddedDate { get; set; }

    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Text)]
    public string Text { get; set; }
    
    public User UserRef { get; set; }
    
    public int UserRefId { get; set; }
}