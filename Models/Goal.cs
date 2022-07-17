using Models.Interfaces;

namespace Models;

public class Goal : IEntity
{
    public int Id { get; set; }

    public DateTimeOffset AddedDate { get; set; }
    
    public DateTimeOffset RenewedDate { get; set; }
    
    public List<GoalItem> Items { get; set; }
    
    public User UserRef { get; set; }
    
    public int UserRefId { get; set; }
}